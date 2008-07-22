<?php
require 'lib/funcs.php';

require ("lib/xajax.inc.php");
require('ajax/common.php');

$startdate = $_GET['startdate'];
if(!empty($_GET['enddate'])) $enddate = $_GET['enddate'];
?>
<!DOCTYPE html 
     PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head>
<title>University Scheduling System: <?php echo getTranslation(518,$_GET['lang']); ?></title>
<link rel="stylesheet" href="css/dateslider.css" type = "text/css" />
<link rel="stylesheet" href="css/tabs.css" type = "text/css" />
<link rel="stylesheet" href="css/style.css" type = "text/css" />
<meta http-equiv="content-type" content="text/html; charset=iso-8859-1" />
</head>	
<body>
<?
$colors = array();
if(!empty($_GET['class']) && !empty($_GET['semester'])) {
  // Select all units within the selected period
  $rs = mysql_query("SELECT curriculum.cur_id,UNIX_TIMESTAMP(book_begin) AS begin,sub_name FROM booking INNER JOIN curriculum ON booking.cur_id=curriculum.cur_id INNER JOIN subject ON curriculum.sub_id=subject.sub_id INNER JOIN class_period ON curriculum.class_period_id=class_period.class_period_id WHERE mod_group_id IS NULL AND term_id='".$_GET['semester']."' AND curriculum.class_id='".$_GET['class']."'");
  while($data = mysql_fetch_assoc($rs)) {
    $bookings[] = array($data['cur_id'],$data['begin'],$data['sub_name']);
  }
  $rs = mysql_query("SELECT curriculum.cur_id,mod_group_id,UNIX_TIMESTAMP(book_begin) AS begin,sub_name FROM booking INNER JOIN curriculum ON booking.cur_id=curriculum.cur_id INNER JOIN subject ON curriculum.mod_group_id=subject.mod_id INNER JOIN class_period ON curriculum.class_period_id=class_period.class_period_id WHERE mod_group_id IS NOT NULL AND term_id='".$_GET['semester']."' AND curriculum.class_id='".$_GET['class']."' GROUP BY mod_group_id,book_begin");
  while($data = mysql_fetch_assoc($rs)) {
    $rsOtherModules = mysql_query("SELECT DISTINCT sub_name FROM booking INNER JOIN curriculum ON booking.cur_id=curriculum.cur_id INNER JOIN subject ON curriculum.mod_group_id=subject.mod_id INNER JOIN class_period ON curriculum.class_period_id=class_period.class_period_id WHERE mod_group_id='".$data['mod_group_id']."' AND sub_name!='".$data['sub_name']."' AND term_id='".$_GET['semester']."' AND curriculum.class_id='".$_GET['class']."'");
    $otherModules = "";
    while($module = mysql_fetch_assoc($rsOtherModules)) {
      $otherModules .= ", ".$module['sub_name'];
    }
    $bookings[] = array($data['cur_id'],$data['begin'],$data['sub_name'].$otherModules);
  }
  
  
  $rs = mysql_query("SELECT cur_id,sub_long_name,sub_name,cur_cnt_sub,lec_gname,lec_lname,lec_tel FROM curriculum INNER JOIN class_period ON curriculum.class_period_id=class_period.class_period_id INNER JOIN subject ON curriculum.sub_id=subject.sub_id INNER JOIN lecturer ON curriculum.lec_id=lecturer.lec_id WHERE term_id='".$_GET['semester']."' AND curriculum.class_id='".$_GET['class']."'");
  $r = 255;
  $g = 255;
  $b = 0;
  
  while($data = mysql_fetch_assoc($rs)) {
    
    $colors[$data['cur_id']] = array($r,$g,$b);
    $r = ($r+33)%256;
    $g = ($g+66)%256;
    $b = ($b+99)%256;
  }
  
  
  $rs = mysql_query("SELECT cur_id,mod_group_id,sub_name,sub_long_name,cur_cnt_sub FROM curriculum INNER JOIN class_period ON curriculum.class_period_id=class_period.class_period_id INNER JOIN subject ON curriculum.mod_group_id=subject.mod_id WHERE mod_group_id IS NOT NULL AND term_id='".$_GET['semester']."' AND curriculum.class_id='".$_GET['class']."' GROUP BY mod_group_id");
  if(mysql_num_rows($rs)>0) {
    while($data = mysql_fetch_assoc($rs)) {
      
      $otherModulesRS = mysql_query("SELECT sub_long_name,sub_name FROM curriculum INNER JOIN class_period ON curriculum.class_period_id=class_period.class_period_id INNER JOIN subject ON curriculum.mod_group_id=subject.mod_id WHERE mod_group_id='".$data['mod_group_id']."' AND term_id='".$_GET['semester']."' AND curriculum.class_id='".$_GET['class']."'");
      $otherModules = array();
      $otherModulesShort = array();
      while($otherModule = mysql_fetch_assoc($otherModulesRS)) {
        $otherModules[] = $otherModule['sub_long_name'];
        $otherModulesShort[] = $otherModule['sub_name'];
      }
      
      $colors[$data['cur_id']] = array($r,$g,$b);
      $r = ($r+33)%256;
      $g = ($g+66)%256;
      $b = ($b+99)%256;
    }
  }
}

  $rsTimes = mysql_query("SELECT TU_START,TU_DURATION,TU_TYP FROM timeunits WHERE TU_TYP='1' ORDER BY TU_START");
  if($_GET['view']=="month" || $_GET['view']=="all") {
    echo '<table style="border-collapse:collapse;border:solid 2px #aaa;font-size:80%;width:100%" id="monatstable">';
    $spalteheute = -1;
    
    for($j=0;$j<6;$j++) {
      echo "<tr><th style=\"border-right:double 3px #bbb;border-bottom:double 3px #bbb;";
      if($wochentage[$j]!="Monday") echo "border-top:double 3px #bbb;";
      echo "\">".strtr($wochentage[$j],$trans)."</th>";

      // Woche des 1. des Monats
      if($_GET['view']=="all") $weekNrStart = date('W',$startdate);
      else $weekNrStart = date('W',strtotime(date('n',$startdate)."/1/".date('Y',$startdate),$startdate));
      if($_GET['view']=="all") $weekNrEnd = date('W',$enddate);
      else $weekNrEnd = $weekNrStart+ceil(date('t',$startdate)/7);
      
      
      $days = array();
      for($i=$weekNrStart;$i<=(($weekNrEnd<$weekNrStart)?52+$weekNrEnd:$weekNrEnd);$i++) {
        $timestamp = strtotime("1/1/".date('Y',$startdate)."+".($i)." week ".($j-1)." days");
        $timestamp = strtotime("last ".date('l',$timestamp),$timestamp);
        
        $jetzigeWoche = date('W.y');
        $tag = date('D',$timestamp);
        echo "<th style=\"border-bottom:double 3px #bbb;";
        if($tag!="Monday") echo "border-top:double 3px #bbb;";
        if($jetzigeWoche==date('W.y',$timestamp)) {
          echo "background:#FFC;";
          $spalteheute = $weekNrEnd-$weekNrStart-($weekNrEnd-$i);
        }
        echo "\">".date('d.m.',$timestamp)."</th>";
        $days[] = date('j_n_Y',$timestamp);
      }
      echo "</tr>";
      
      
      mysql_data_seek($rsTimes,0);
      //for($h=8*60;$h<=20*60;$h+=45) {
      while($data = mysql_fetch_assoc($rsTimes)) {
        echo "<tr>";
        echo "<td class=\"fullhour\" style=\"text-align:center;font-weight:900;background:#DEF;color:#019;border-right:double 3px #bbb;\"><div style=\"position:relative;margin-top:5px;\">";
        echo floor($data['TU_START']/60).":".str_pad(($data['TU_START']%60),2,"0",STR_PAD_LEFT)." - ".floor(($data['TU_START']+$data['TU_DURATION'])/60).":".str_pad((($data['TU_START']+$data['TU_DURATION'])%60),2,"0",STR_PAD_LEFT)."</div></td>";
        
        $cnt_weeks = $weekNrEnd-$weekNrStart;
        if($cnt_weeks<0) {
          $cnt_weeks = 52-$weekNrStart+$weekNrEnd;
        }
        
        for($i=0;$i<=$cnt_weeks;$i++) {
          echo "<td style=\"";
          $dateArr = explode("_",$days[$i]);
          $zeit = mktime(floor($data['TU_START']/60),$data['TU_START']%60,0,$dateArr[1],$dateArr[0],$dateArr[2]); 
          $lessonIndex = getLessonAtTime($zeit,$bookings);
          
          if($i==$spalteheute) echo "background:#FFC;";
          elseif($i<=$spalteheute || ($spalteheute==-1 && $timestamp<time())) echo "background:#f4f4f4;";
          echo "\"><div class=\"dropables";
          if($lessonIndex!==false && $colors[$bookings[$lessonIndex][0]]) echo " loadedSubjects";
          echo "\" id=\"date_".$days[$i]."_".floor($data['TU_START']/60)."_".str_pad(($data['TU_START']%60),2,"0",STR_PAD_LEFT)."\"";
          if($lessonIndex!==false) {
            echo " style=\"background:rgb(".((isset($colors[$bookings[$lessonIndex][0]][0]))?$colors[$bookings[$lessonIndex][0]][0]:200).",".((isset($colors[$bookings[$lessonIndex][0]][1]))?$colors[$bookings[$lessonIndex][0]][1]:200).",".((isset($colors[$bookings[$lessonIndex][0]][2]))?$colors[$bookings[$lessonIndex][0]][2]:200).");color:rgb(".getContrastColor($colors[$bookings[$lessonIndex][0]][0],$colors[$bookings[$lessonIndex][0]][1],$colors[$bookings[$lessonIndex][0]][2]).");\"";
          }
          echo ">";
          
          if($lessonIndex!==false) {
            echo $bookings[$lessonIndex][2];
          } else echo "&nbsp;";
          echo "</div></td>";
        }
        echo "</tr>";
      }
    }
    echo '</table>';
  }
  
  
  
  if($_GET['view']=="week") {
    echo '<table style="border-collapse:collapse;border:solid 2px #aaa;width:100%;font-size:80%;" id="wochentable">';
    echo "<tr><th style=\"border-right:double 3px #bbb;border-bottom:double 3px #bbb;\">&nbsp;</th>";
    
    $spalteheute = -1;
    
    $days = array();
    for($i=0;$i<count($wochentage);$i++) {
      $timestamp = strtotime("last ".$wochentage[$i],$startdate);
      $timestamp2 = strtotime("next ".$wochentage[$i],$startdate);
      if($timestamp2-$timestamp>604800) {
        $timestamp = strtotime("today",$startdate);
      } elseif(date('W',$timestamp)<date('W',$startdate)) $timestamp = $timestamp2;
      
      $heute = date('j.n.y');
      $tag = date('D',$timestamp);
      echo "<th style=\"border-bottom:double 3px #bbb;min-width:80px;";
      if($heute==date('j.n.y',$timestamp)) {
        echo "background:#FFC;";
        $spalteheute = $i;
      }
      echo "\">".strtr($tag, $trans)."<br />".date('d.m.',$timestamp)."</th>";
      $days[] = date('j_n_Y',$timestamp);
    }
    echo "</tr>";
    
    
    while($data = mysql_fetch_assoc($rsTimes)) {
      echo "<tr class=\"";
      /*if($data['TU_TYP']=="0") echo "break";
      else echo "lesson";*/
      echo "\">";
      echo "<td class=\"fullhour\" style=\"text-align:center;font-weight:900;background:#DEF;color:#019;border-right:double 3px #bbb;\"><div style=\"position:relative;margin-top:5px;\">";
      echo floor($data['TU_START']/60).":".str_pad(($data['TU_START']%60),2,"0",STR_PAD_LEFT)." - ".floor(($data['TU_START']+$data['TU_DURATION'])/60).":".str_pad((($data['TU_START']+$data['TU_DURATION'])%60),2,"0",STR_PAD_LEFT)."</div></td>";
      
      for($i=0;$i<count($wochentage);$i++) {
        echo "<td style=\"";
        $dateArr = explode("_",$days[$i]);
        $zeit = mktime(floor($data['TU_START']/60),$data['TU_START']%60,0,$dateArr[1],$dateArr[0],$dateArr[2]);
        $lessonIndex = getLessonAtTime($zeit,$bookings);

        if($i==$spalteheute) echo "background:#FFC;";
        elseif($i<=$spalteheute || ($spalteheute==-1 && $timestamp<time())) echo "background:#f4f4f4;";
        echo "\"><div class=\"dropables";
        if($lessonIndex!==false && $colors[$bookings[$lessonIndex][0]]) echo " loadedSubjects";
        echo "\" id=\"date_".$days[$i]."_".floor($data['TU_START']/60)."_".str_pad(($data['TU_START']%60),2,"0",STR_PAD_LEFT)."\"";
        if($lessonIndex!==false) echo " style=\"background:rgb(".((isset($colors[$bookings[$lessonIndex][0]][0]))?$colors[$bookings[$lessonIndex][0]][0]:200).",".((isset($colors[$bookings[$lessonIndex][0]][1]))?$colors[$bookings[$lessonIndex][0]][1]:200).",".((isset($colors[$bookings[$lessonIndex][0]][2]))?$colors[$bookings[$lessonIndex][0]][2]:200).");color:rgb(".getContrastColor($colors[$bookings[$lessonIndex][0]][0],$colors[$bookings[$lessonIndex][0]][1],$colors[$bookings[$lessonIndex][0]][2]).");\"";
        echo ">";
        
        if($lessonIndex!==false && isset($colors[$bookings[$lessonIndex][0]][0])) {
          echo $bookings[$lessonIndex][2];
        } else echo "&nbsp;";
        echo "</div></td>";
      }
      echo "</tr>";
    }
    echo '</table>';
  }
  ?>
</body>
</html>