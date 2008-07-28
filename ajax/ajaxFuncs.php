<?php
require_once '../lib/funcs.php';
require ("../lib/xajax.inc.php");
require('common.php');

/**

 @mainpage University Scheduling System (master data)
 @version 0.1
 @author Ivonne Seibt, Stephan Hilbrandt, Jan Walther
 @date 25-07-2008
 @brief source code documentation

 @defgroup AJAX Package AJAX functions
 @brief backend functions for communication with database and generating AJAX responses
*/


/**
* @ingroup AJAX
* @brief Function moveLesson.
*
* Move a lesson to a certain date-time-slot - if empty insert new booking, if $oldTime is set, move it to new time (while deleting it from old time) and if time is already used, show alert window
*
* @param curriculumID (int) unique ID from the database table Curriculum
* @param zeit (int) time a certain lesson shall be inserted at (Unix timestamp)
* @param oldTime (int) time the lesson to be moved has been before
* @return xajaxResponse object defining the actions to be executed on the client
*/ 
function moveLesson($curriculumID,$zeit,$oldTime=0) {
  $objResponse = new xajaxResponse();
  
  $rs = mysql_query("SELECT mod_group_id FROM curriculum WHERE cur_id='".$curriculumID."'");
  $mod_group_ID = @mysql_result($rs,0);
  $showRoomPlanning = false;
  if($mod_group_ID) {
    // Modul
    
    $rs = mysql_query("SELECT 1 FROM booking INNER JOIN curriculum ON booking.cur_id=curriculum.cur_id WHERE book_begin='".date('Y-m-d H:i:00',$zeit)."' AND class_id IN (SELECT class_id FROM booking INNER JOIN curriculum ON booking.cur_id=curriculum.cur_id WHERE mod_group_id='".$mod_group_ID."')");
    if(mysql_num_rows($rs)>0) {
      $domID = date('j_n_Y_G_i',$zeit);
      $objResponse->addScript("moveTermin(Date.parse('".date("d.m.Y H:i",$oldTime)."'),document.getElementById('date_".$domID."').style.backgroundColor,document.getElementById('date_".$domID."').lastChild.nodeValue,'".$domID."')");
      $objResponse->addScript("deleteLesson(Date.parse('".date("d.m.Y H:i",$zeit)."'))");
      $objResponse->addAlert(utf8_encode(getTranslation(537,$_COOKIE['lang'])));
      return $objResponse;
    }
    $rs = mysql_query("SELECT sub_id FROM subject WHERE mod_id='".$mod_group_ID."'");
    $book_ids = array();
    while($data = mysql_fetch_assoc($rs)) {
      $rs_roomID = mysql_query("SELECT room_id FROM booking WHERE cur_id='".$curriculumID."' AND book_begin='".date('Y-m-d H:i:00',$oldTime)."' AND module_sub_id='".$data['sub_id']."'");
      $room = @mysql_result($rs_roomID,0);
      if($oldTime && $room) {
        mysql_query("UPDATE booking SET room_id='".$room."',book_begin='".date('Y-m-d H:i:00',$zeit)."',book_end='".date('Y-m-d H:i:00',$zeit+90*60)."' WHERE cur_id IN (SELECT cur_id FROM curriculum WHERE mod_group_id='".$mod_group_ID."') AND book_begin='".date('Y-m-d H:i:00',$oldTime)."' AND module_sub_id='".$data['sub_id']."'");
        $rs_bookID = mysql_query("SELECT book_id FROM booking WHERE cur_id IN (SELECT cur_id FROM curriculum WHERE mod_group_id='".$mod_group_ID."') AND book_begin='".date('Y-m-d H:i:00',$zeit)."' AND module_sub_id='".$data['sub_id']."'");
        while($booking_ids = mysql_fetch_assoc($rs_bookID)) $book_ids[] = $booking_ids['book_id'];
      } elseif($oldTime) {
        mysql_query("UPDATE booking SET book_begin='".date('Y-m-d H:i:00',$zeit)."',book_end='".date('Y-m-d H:i:00',$zeit+90*60)."' WHERE cur_id IN (SELECT cur_id FROM curriculum WHERE mod_group_id='".$mod_group_ID."') AND book_begin='".date('Y-m-d H:i:00',$oldTime)."' AND module_sub_id='".$data['sub_id']."'");
        $rs_bookID = mysql_query("SELECT book_id FROM booking WHERE cur_id IN (SELECT cur_id FROM curriculum WHERE mod_group_id='".$mod_group_ID."') AND book_begin='".date('Y-m-d H:i:00',$zeit)."' AND module_sub_id='".$data['sub_id']."'");
        while($booking_ids = mysql_fetch_assoc($rs_bookID)) $book_ids[] = $booking_ids['book_id'];
        $showRoomPlanning = true;
      } else {
        $rs_module = mysql_query("SELECT cur_id FROM curriculum WHERE mod_group_id='".$mod_group_ID."'");
        while($module = mysql_fetch_assoc($rs_module)) {
          mysql_query("INSERT INTO booking (cur_id,room_id,book_begin,book_end,module_sub_id) VALUES ('".$module['cur_id']."',(SELECT room_id FROM defaultrooms WHERE class_id=(SELECT class_id FROM curriculum WHERE cur_id=(SELECT cur_id FROM curriculum WHERE mod_group_id='".$mod_group_ID."' LIMIT 1)) ORDER BY priority LIMIT 1),'".date('Y-m-d H:i:00',$zeit)."','".date('Y-m-d H:i:00',$zeit+90*60)."','".$data['sub_id']."')");
          $book_ids[] = mysql_insert_id();
        }
        $showRoomPlanning = true;
      }
    }
    if($showRoomPlanning && mysql_num_rows($rs)>1) {
      $objResponse->addAlert(utf8_encode(getTranslation(531,$_COOKIE['lang'])));
      $objResponse->addScript("openRoomPlanning('roomplanning.php?lang=".$_COOKIE['lang']."&curriculumID=".$curriculumID."&date=".$zeit."')");
      return $objResponse;
    } else {
      $rs = mysql_query("SELECT 1 FROM booking WHERE book_begin='".date('Y-m-d H:i:00',$zeit)."' AND room_id IN (SELECT room_id FROM booking WHERE book_id IN ('".implode("','",$book_ids)."')) AND book_id NOT IN ('".implode("','",$book_ids)."')");
      if(mysql_num_rows($rs)>0) {
        // Raum bereits belegt zu diesem Termin
        $objResponse->addAlert(utf8_encode(getTranslation(532,$_COOKIE['lang'])));
      }
    }
  } else {
    $rs = mysql_query("SELECT room_id FROM booking WHERE cur_id='".$curriculumID."' AND book_begin='".date('Y-m-d H:i:00',$oldTime)."'");
    $room = @mysql_result($rs,0);
    if($oldTime && $room) {
      mysql_query("UPDATE booking SET room_id='".$room."',book_begin='".date('Y-m-d H:i:00',$zeit)."',book_end='".date('Y-m-d H:i:00',$zeit+90*60)."' WHERE cur_id='".$curriculumID."' AND book_begin='".date('Y-m-d H:i:00',$oldTime)."'");
      $rs = mysql_query("SELECT book_id FROM booking WHERE cur_id='".$curriculumID."' AND book_begin='".date('Y-m-d H:i:00',$zeit)."'");
      $book_id = @mysql_result($rs,0);
    } elseif($oldTime) {
      mysql_query("UPDATE booking SET book_begin='".date('Y-m-d H:i:00',$zeit)."',book_end='".date('Y-m-d H:i:00',$zeit+90*60)."' WHERE cur_id='".$curriculumID."' AND book_begin='".date('Y-m-d H:i:00',$oldTime)."'");
      $rs = mysql_query("SELECT book_id FROM booking WHERE cur_id='".$curriculumID."' AND book_begin='".date('Y-m-d H:i:00',$zeit)."'");
      $book_id = @mysql_result($rs,0);
    } else {
      mysql_query("INSERT INTO booking (cur_id,room_id,book_begin,book_end) VALUES ('".$curriculumID."',(SELECT room_id FROM defaultrooms WHERE class_id=(SELECT class_id FROM curriculum WHERE cur_id='".$curriculumID."') ORDER BY priority LIMIT 1),'".date('Y-m-d H:i:00',$zeit)."','".date('Y-m-d H:i:00',$zeit+90*60)."')");
      $book_id = mysql_insert_id();
    }
 
 
    $rs = mysql_query("SELECT 1 FROM booking WHERE book_begin='".date('Y-m-d H:i:00',$zeit)."' AND room_id=(SELECT room_id FROM booking WHERE book_id='".$book_id."') AND book_id!='".$book_id."'");
    if(mysql_num_rows($rs)>0) {
      // Raum bereits belegt zu diesem Termin
      $objResponse->addAlert(utf8_encode(getTranslation(533,$_COOKIE['lang'])));
    }
  }
  return $objResponse;
}

/**
* @ingroup AJAX
* @brief Function deleteBooking.
*
* Delete a booked lesson
*
* @param curriculumID (int) unique ID from the database table Curriculum
* @param time (int) time a certain lesson shall be inserted at (Unix timestamp)
* @return xajaxResponse object defining the actions to be executed on the client
*/
function deleteBooking($curriculumID,$time) {
  $objResponse = new xajaxResponse();
  $curriculumID = str_replace("_mod","",$curriculumID);
  
  $rs = mysql_query("SELECT cur_id FROM curriculum WHERE mod_group_id=(SELECT mod_group_id FROM curriculum WHERE cur_id='".$curriculumID."')");
  if(mysql_num_rows($rs)>0) {
    // Modul
    while($data = mysql_fetch_assoc($rs)) {
      mysql_query("DELETE FROM booking WHERE cur_id='".$data['cur_id']."' AND book_begin='".date('Y-m-d H:i:00',$time)."'");
    }
  } else {
    mysql_query("DELETE FROM booking WHERE cur_id='".$curriculumID."' AND book_begin='".date('Y-m-d H:i:00',$time)."'");
  }
  return $objResponse;
}

/**
* @ingroup AJAX
* @brief Function changeRoom.
*
* Change the room of a booked lesson
*
* @param bookID (int) unique ID from the database table Booking determing a certain lesson
* @param room_nr (int) room number where the lesson shall take place
* @return xajaxResponse object defining the actions to be executed on the client
*/
function changeRoom($bookID,$room_nr) {
  $objResponse = new xajaxResponse();
  $rs = mysql_query("SELECT book_id FROM booking WHERE cur_id=(SELECT cur_id FROM booking WHERE book_ID='".$bookID."' AND module_sub_id>0) AND book_begin=(SELECT book_begin FROM booking WHERE book_ID='".$bookID."')");
  if(mysql_num_rows($rs)>0) {
    //Modul
    while($data = mysql_fetch_assoc($rs)) {
      mysql_query("UPDATE booking SET room_id=(SELECT room_id FROM room WHERE room_nr='".$room_nr."') WHERE book_ID='".$data['book_id']."'");
    }
  } else {
    mysql_query("UPDATE booking SET room_id=(SELECT room_id FROM room WHERE room_nr='".$room_nr."') WHERE book_ID='".$bookID."'");
  }
  return $objResponse;
}

$xajax->processRequests();
?>