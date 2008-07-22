<?php
/**

 @mainpage University Scheduling System (master data)
 @version 0.1
 @author Ivonne Seibt, Stephan Hilbrandt, Jan Walther
 @date 25-07-2008
 @brief source code documentation

 @defgroup PHP Package PHP functions
 @brief server-side functions for date calculations and databse operations
*/

if($_GET['lang']=="1") {
  $trans = array(
      'Monday'    => 'Montag',
      'Tuesday'   => 'Dienstag',
      'Wednesday' => 'Mittwoch',
      'Thursday'  => 'Donnerstag',
      'Friday'    => 'Freitag',
      'Saturday'  => 'Samstag',
      'Sunday'    => 'Sonntag',
      'Mon'       => 'Mo',
      'Tue'       => 'Di',
      'Wed'       => 'Mi',
      'Thu'       => 'Do',
      'Fri'       => 'Fr',
      'Sat'       => 'Sa',
      'Sun'       => 'So',
      'January'   => 'Januar',
      'February'  => 'Februar',
      'March'     => 'März',
      'May'       => 'Mai',
      'June'      => 'Juni',
      'July'      => 'Juli',
      'October'   => 'Oktober',
      'December'  => 'Dezember',
  );
} else $trans = array();

$wochentage = array("Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday");


/**
* @ingroup PHP
* @brief Function connectDB.
*
* connect to database
*
* @return DB-Handler resource / object of the connection to the database
*/
function connectDB() {
  $dbh=mysql_connect ("localhost", "root", "")
		or die ('Die Datenbank ist gerade nicht aufrufbar.');

	mysql_select_db ("timetable");
  return $dbh;
}
connectDB();

/**
* @ingroup PHP
* @brief Function getLessonAtTime.
*
* return array index of the lesson which is at the given time
*
* @param $timestamp (int) UNIX timestamp of the lesson start time
* @param $bookArr (Array) Array which is generated in timetable.php
* @return boolean/int if $timestamp has been found in $bookArr, the array index will be returned. Otherwise false
*/
function getLessonAtTime($timestamp,$bookArr) {
  for($i=0;$i<count($bookArr);$i++) {
    if($bookArr[$i][1]==$timestamp) {
      return $i;
    }
  }
  return false;
}

/**
* @ingroup PHP
* @brief Function getLessonAtRoomAndTime.
*
* get the lesson of given room and time
*
* @param $timestamp (int) UNIX timestamp of the lesson start time
* @param $room (int) room number where the lesson takes place
* @param $bookArr (Array) Array which is generated in timetable.php
* @return boolean/int if $timestamp and $room has been found in $bookArr, the array index will be returned. Otherwise false
*/
function getLessonAtRoomAndTime($timestamp,$room,$bookArr) {
  for($i=0;$i<count($bookArr);$i++) { 
    if($bookArr[$i][2]==$timestamp && $bookArr[$i][1]==$room) return $i;
  }
  return false;
}

/**
* @ingroup PHP
* @brief Function getTerminatedLessonCnt.
*
* count number of lessons of a certain subject which are already planned
*
* @param $curID (int) unique ID of the subject in the curriculum table
* @param $bookArr (Array) Array which is generated in timetable.php
* @return number of lessons of a certain subject that are already planned in this semester
*/
function getTerminatedLessonCnt($curID,$bookArr) {
  global $startdate,$enddate;
  $cnt = 0;
  for($i=0;$i<count($bookArr);$i++) {
    if($bookArr[$i][0]==$curID/* && $bookArr[$i][1]>=$startdate && $bookArr[$i][1]<=$enddate*/) $cnt++;
  }
  return $cnt;
}

/**
* @ingroup PHP
* @brief Function getContrastColor.
*
* get a contrast color to given RGB values
*
* @param $r (int) value for red (0-255)
* @param $g (int) value for green (0-255)
* @param $b (int) value for blue (0-255)
* @return color string of the RGB values separated by commas -> ready for use in CSS rgb() function
*/
function getContrastColor($r,$g,$b) {
  $r = ($r>150)?0:255;
  $g = ($g>150)?0:255;
  $b = ($b>150)?0:255;

  return $r.",".$g.",".$b;
}

/**
* @ingroup PHP
* @brief Function isRoomAndTimeUsed.
*
* check if room is used at certain time
*
* @param $room_nr (int) room number to be checked
* @param $time (int) UNIX timestamp to check
* @param $roomsArr (Array) Array of all terminated lessons which is generated in timetable.php
* @return boolean whether room is free or not
*/
function isRoomAndTimeUsed($room_nr,$time,$roomsArr) {
  for($i=0;$i<count($roomsArr);$i++) {
    if($roomsArr[$i][0]==$room_nr && $roomsArr[$i][1]==$time) return $i;
  }
  return false;
}

/**
* @ingroup PHP
* @brief Function getTranslation.
*
* get a translation
*
* @param $id (int) ID of the string in the language table
* @param $lang (int) 1=german, 2=english
* @return translated string
*/
function getTranslation($id,$lang) {
  $rs = mysql_query("SELECT lan_txt FROM language WHERE ID='".$id."' AND lan_id='".$lang."'");
  return @mysql_result($rs,0);
}
?>