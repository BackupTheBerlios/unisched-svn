<?php
//ini_set('session.use_trans_sid', false);
//ini_set("session.save_path","/kunden/wedosys.de/rp-hosting/298/537/sessions");

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
$wochentage = array("Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday");
  
  
function connectDB() {
  $dbh=mysql_connect ("localhost", "root", "")
		or die ('Die Datenbank ist gerade nicht aufrufbar.');

	mysql_select_db ("timetable");
}
connectDB();

function getLessonAtTime($timestamp,$bookArr) {
  for($i=0;$i<count($bookArr);$i++) {
    if($bookArr[$i][1]==$timestamp) {
      return $i;
    }
  }
  return false;
}

function getLessonAtRoomAndTime($timestamp,$room,$bookArr) {
  for($i=0;$i<count($bookArr);$i++) { 
    if($bookArr[$i][2]==$timestamp && $bookArr[$i][1]==$room) return $i;
  }
  return false;
}

function getTerminatedLessonCnt($curID,$bookArr) {
  global $startdate,$enddate;
  $cnt = 0;
  for($i=0;$i<count($bookArr);$i++) {
    if($bookArr[$i][0]==$curID && $bookArr[$i][1]>=$startdate && $bookArr[$i][1]<=$enddate) $cnt++;
  }
  return $cnt;
}

function getContrastColor($r,$g,$b) {
  $r = ($r>150)?0:255;
  $g = ($g>150)?0:255;
  $b = ($b>150)?0:255;

  return $r.",".$g.",".$b;
}

function isRoomAndTimeUsed($room_nr,$time,$roomsArr) {
  for($i=0;$i<count($roomsArr);$i++) {
    if($roomsArr[$i][0]==$room_nr && $roomsArr[$i][1]==$time) return $i;
  }
  return false;
}
?>