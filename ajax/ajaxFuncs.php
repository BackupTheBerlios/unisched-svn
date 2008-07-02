<?php
require_once '../lib/funcs.php';
require ("../lib/xajax.inc.php");
require('common.php');

function moveLesson($curriculumID,$zeit) {
  $objResponse = new xajaxResponse();
  mysql_query("INSERT INTO booking (cur_id,room_id,book_begin,book_end) VALUES ('".$curriculumID."',(SELECT room_id FROM defaultrooms WHERE class_id=(SELECT class_id FROM curriculum WHERE cur_id='".$curriculumID."') ORDER BY priority LIMIT 1),'".date('Y-m-d H:i:00',$zeit)."','".date('Y-m-d H:i:00',$zeit+90*60)."')");
  
  $book_id = mysql_insert_id();
  $rs = mysql_query("SELECT 1 FROM booking WHERE book_begin='".date('Y-m-d H:i:00',$zeit)."' AND room_id=(SELECT room_id FROM booking WHERE book_id='".$book_id."') AND book_id!='".$book_id."'");
  if(mysql_num_rows($rs)>0) {
    // Raum bereits belegt zu diesem Termin
    $objResponse->addAlert(utf8_encode("Der Standardraum für diese Vorlesung ist zu diesem Termin leider bereits von einer anderen Seminargruppe belegt."));
  }
  return $objResponse;
}

function deleteBooking($curriculumID,$zeit) {
  $objResponse = new xajaxResponse();
  mysql_query("DELETE FROM booking WHERE cur_id='".$curriculumID."' AND book_begin='".date('Y-m-d H:i:00',$zeit)."'");
  return $objResponse;
}

function changeRoom($bookID,$room_nr) {
  $objResponse = new xajaxResponse();
  mysql_query("UPDATE booking SET room_id=(SELECT room_id FROM room WHERE room_nr='".$room_nr."') WHERE book_ID='".$bookID."'");
  return $objResponse;
}

$xajax->processRequests();
?>