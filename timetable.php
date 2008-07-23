<?php
/**

 @mainpage University Scheduling System (master data)
 @version 0.1
 @author Ivonne Seibt, Stephan Hilbrandt, Jan Walther
 @date 25-07-2008
 @brief source code documentation

 @defgroup Main Package Main functions
 @brief Scripts to be executed at startup
*/

require 'lib/funcs.php';

require ("lib/xajax.inc.php");
require('ajax/common.php');

if(empty($_GET['startdate']) && !empty($_GET['class']) && !empty($_GET['semester'])) {
  $rs = mysql_query("SELECT UNIX_TIMESTAMP(MIN(class_period_begin)) AS start,UNIX_TIMESTAMP(MAX(class_period_end)) AS end FROM class_period WHERE term_id='".$_GET['semester']."' AND class_id='".$_GET['class']."'");
  $data = mysql_fetch_assoc($rs);
  $_GET['startdate'] = $data['start'];
  $_GET['enddate'] = $data['end'];
}

if(!empty($_GET['lang'])) {
  setcookie("lang",$_GET['lang']);
} else $_GET['lang'] = $_COOKIE['lang'];
if(!$_GET['lang']) {
  $_GET['lang'] = "1";
  setcookie("lang",$_GET['lang']);
}

// Prüfung der GET-Parameter auf Korrektheit
if($_GET['view']!="week") {
  if(empty($_GET['startdate'])) $startdate = time();
  else $startdate = $_GET['startdate'];
} elseif($_GET['view']=="week") {
  if(empty($_GET['startdate'])) $startdate = time();
  else $startdate = $_GET['startdate'];
  $timestamp = strtotime("last Monday",$startdate);
  $timestamp2 = strtotime("next Monday",$startdate);
  if($timestamp2-$timestamp>604800) $timestamp = strtotime("today",$startdate);
  elseif(date('W',$timestamp)<date('W',$startdate)) $timestamp = $timestamp2;
  $startdate = $timestamp;
} else $startdate = $_GET['startdate'];

if(empty($_GET['enddate'])) {
  if($_GET['view']=="all" || $_GET['view']=="month") {
    $enddate = time()+90*24*3600;
    if($_GET['view']=="all") $weekNrStart = date('W',$startdate);
    else $weekNrStart = date('W',strtotime(date('n',$startdate)."/1/".date('Y',$startdate),$startdate));
    if($_GET['view']=="all") $weekNrEnd = date('W',$enddate);
    else $weekNrEnd = $weekNrStart+ceil(date('t',$startdate)/7);
    
    $timestamp = strtotime("1/1/".date('Y',$enddate)."+".$weekNrEnd." week 5 days");
    $enddate = strtotime("last ".date('l',$timestamp),$timestamp);
    
  } elseif($_GET['view']=="week") {
    $timestamp = strtotime("last sunday",$startdate);
    $timestamp2 = strtotime("next sunday",$startdate);
    if($timestamp2-$timestamp>604800) {
      $enddate = strtotime("today",$startdate);
    } elseif(date('W',$timestamp)<date('W',$startdate)) $enddate = $timestamp2;
  } else $enddate = time()+90*24*3600;
} else {
  $enddate = $_GET['enddate'];
  if(!empty($_GET['semester']) && !empty($_GET['class'])) {
    $rs = mysql_query("SELECT UNIX_TIMESTAMP(MIN(class_period_begin)) AS start,UNIX_TIMESTAMP(MAX(class_period_end)) AS end FROM class_period WHERE term_id='".$_GET['semester']."' AND class_id='".$_GET['class']."'");
    $data = mysql_fetch_assoc($rs);
    if($data['end']-$data['start']>$enddate-$startdate && !empty($_GET['changeview'])) {
      $enddate = $data['end'];
      $startdate = $data['start'];
    }
  }
}

if(empty($_GET['view'])) $_GET['view'] = "all";
?><!DOCTYPE html 
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

<div style="position:absolute;top:10px;left:210px;min-width:800px;">
  <div id = "slider-container" style="float:left;">
  	<div id = "sliderbar"></div>
  </div>
  <div style="float:right;margin-right:5px;font-size:90%;text-align:center;">
    <a href="index.html"><?php echo getTranslation(521,$_GET['lang']); ?></a><br /><br />
    <a href="<?php echo $_SERVER['REQUEST_URI'].((strpos($_SERVER['REQUEST_URI'],"?")!==false)?"&":"?"); ?>lang=1"><img src="img/flag_germany.png" alt="Deutsch" title="Deutsch" border="0" /></a> <a href="<?php echo $_SERVER['REQUEST_URI'].((strpos($_SERVER['REQUEST_URI'],"?")!==false)?"&":"?"); ?>lang=2"><img src="img/flag_great_britain.png" alt="English" title="English" border="0" /></a>
  </div>
  <div>
  <label for = "datestart" style="width:40px;float:left;margin-top:3px;padding-right:5px;text-align:right;"><?php echo getTranslation(513,$_GET['lang']); ?>:</label>  <input type = "text" id = "datestart" style="margin-bottom:3px;" /><br />
  <label for = "dateend" style="width:40px;float:left;margin-top:3px;padding-right:5px;text-align:right;"><?php echo getTranslation(514,$_GET['lang']); ?>:</label> <input type = "text" id = "dateend" /> <input type="button" value="<?php echo getTranslation(501,$_GET['lang']); ?>" onclick="showAll()" />
  </div>
</div>
<div>
  <select id="class"><option value="0">-- <?php echo getTranslation(520,$_GET['lang']); ?> --</option><?php
  $rs = mysql_query("SELECT DISTINCT class.class_id,class_name FROM class_period INNER JOIN class ON class_period.class_id=class.class_id WHERE class_period_end>NOW() ORDER BY class_name");
  while($data = mysql_fetch_assoc($rs)) {
    echo "<option value=\"".$data['class_id']."\"";
    if($_GET['class']==$data['class_id']) echo "selected=\"selected\"";
    echo ">".$data['class_name']."</option>";
  }
  ?></select><br />
  <select id="semester"><option value="0">-- <?php echo getTranslation(512,$_GET['lang']); ?> --</option><?php
  $rs = mysql_query("SELECT MAX(term_id) FROM class_period");
  $maxTerms = mysql_result($rs,0);
  for($i=1;$i<=$maxTerms;$i++) {
    echo "<option value=\"".$i."\"";
    if($_GET['semester']==$i) echo "selected=\"selected\"";
    echo ">".$i.". Semester</option>";
  }
  ?></select>
  <input type="button" value="<?php echo getTranslation(500,$_GET['lang']); ?>" onclick="window.location.href='<?php echo $_SERVER['PHP_SELF']; ?>?class='+$('class').value+'&semester='+$('semester').value" />
</div>

<div style="position:absolute;top:94px;left:0px;width:195px;"><h3 style="margin:0 3px 12px;"><?php echo getTranslation(502,$_GET['lang']); ?></h3>
<?php

$bookings = array();




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
    echo '<div class="lesson" title="Tel.: '.$data['lec_tel'].'"><a href="#"><img src="img/edit.gif" style="float:right;margin:0 4px;border:none;" alt="'.getTranslation(524,$_GET['lang']).'" title="'.getTranslation(524,$_GET['lang']).'" /></a><div class="loadedSubjects" id="subject_'.$data['cur_id'].'" style="width:130px"><div style="width:13px;height:13px;background-color:rgb('.$r.','.$g.','.$b.');border:solid 1px #222;float:left;margin-right:3px;"></div>'.$data['sub_name'].'</div>'.$data['sub_long_name'].'<br />'.$data['lec_lname'].(($data['lec_gname'])?', '.$data['lec_gname']:'').' - <span id="rest'.$data['cur_id'].'">'.($data['cur_cnt_sub']-getTerminatedLessonCnt($data['cur_id'],$bookings)*2).'</span> h</div>';
    $colors[$data['cur_id']] = array($r,$g,$b);
    $r = ($r+33)%256;
    $g = ($g+66)%256;
    $b = ($b+99)%256;
  }
  
  
  $rs = mysql_query("SELECT cur_id,mod_group_id,sub_name,sub_long_name,cur_cnt_sub FROM curriculum INNER JOIN class_period ON curriculum.class_period_id=class_period.class_period_id INNER JOIN subject ON curriculum.mod_group_id=subject.mod_id WHERE mod_group_id IS NOT NULL AND term_id='".$_GET['semester']."' AND curriculum.class_id='".$_GET['class']."' GROUP BY mod_group_id");
  if(mysql_num_rows($rs)>0) {
    echo "<h3 style=\"margin-top:50px;\">Module</h3>";
    while($data = mysql_fetch_assoc($rs)) {
      echo '<div class="lesson"><a href="#"><img src="img/edit.gif" style="float:right;margin:0 4px;border:none;" alt="'.getTranslation(525,$_GET['lang']).'" title="'.getTranslation(525,$_GET['lang']).'" /></a><div class="loadedSubjects" id="subject_'.$data['cur_id'].'" style="width:130px"><div style="width:13px;height:13px;background-color:rgb('.$r.','.$g.','.$b.');border:solid 1px #222;float:left;margin-right:3px;"></div>';
      $otherModulesRS = mysql_query("SELECT sub_long_name,sub_name FROM curriculum INNER JOIN class_period ON curriculum.class_period_id=class_period.class_period_id INNER JOIN subject ON curriculum.mod_group_id=subject.mod_id WHERE mod_group_id='".$data['mod_group_id']."' AND term_id='".$_GET['semester']."' AND curriculum.class_id='".$_GET['class']."'");
      $otherModules = array();
      $otherModulesShort = array();
      while($otherModule = mysql_fetch_assoc($otherModulesRS)) {
        $otherModules[] = $otherModule['sub_long_name'];
        $otherModulesShort[] = $otherModule['sub_name'];
      }
      echo implode(", ",$otherModulesShort);
      echo '</div>'.implode(", ",$otherModules).'<br />'.$data['lec_lname'].(($data['lec_gname'])?', '.$data['lec_gname']:'').' - <span id="rest'.$data['cur_id'].'">'.($data['cur_cnt_sub']-getTerminatedLessonCnt($data['cur_id'],$bookings)*2).'</span> h</div>';
      $colors[$data['cur_id']] = array($r,$g,$b);
      $r = ($r+33)%256;
      $g = ($g+66)%256;
      $b = ($b+99)%256;
    }
  }
}/* else {
  // Select all units within the selected period
  $rs = mysql_query("SELECT curriculum.cur_id,UNIX_TIMESTAMP(book_begin) AS begin,sub_name FROM booking INNER JOIN curriculum ON booking.cur_id=curriculum.cur_id INNER JOIN subject ON curriculum.sub_id=subject.sub_id WHERE book_begin>='".date('Y-m-d H:i:00',$startdate)."'");
  while($data = mysql_fetch_assoc($rs)) {
    $bookings[] = array($data['cur_id'],$data['begin'],$data['sub_name']);
  }
  for($i=0;$i<=1000;$i++) {
    $colors[] = array(150,150,150);
  }
}*/
?></div>

<div style="padding-left:200px;margin-top:49px;">
  <div style="float:right;width:50%;text-align:center;">
    <div style="float:left;"><a href="<?php echo $_SERVER['PHP_SELF']; ?>?view=<?php echo $_GET['view']; ?>&semester=<?php echo $_GET['semester']; ?>&class=<?php echo $_GET['class']; ?>&startdate=<?php 
  if($_GET['view']=="all" || $_GET['view']=="month") {
    if($_GET['view']=="all") $weekNrStart = date('W',$startdate);
    else $weekNrStart = date('W',strtotime(date('n',$startdate)."/1/".date('Y',$startdate),$startdate));
    
    if($_GET['view']=="all") $weekNrEnd = date('W',$enddate);
    else $weekNrEnd = $weekNrStart+ceil(date('t',$startdate)/7);
    
    $timestamp = strtotime("1/1/".date('Y',$startdate)."+".$weekNrStart." week -1 days");
    $timestamp1 = strtotime("last ".date('l',$timestamp),$timestamp);
    $periodStart = date('d.m.y',$timestamp1);
    
    $timestamp = strtotime("1/1/".date('Y',$enddate)."+".$weekNrEnd." week 5 days");
    $timestamp2 = strtotime("last ".date('l',$timestamp),$timestamp);
    $periodEnd = date('d.m.y',$timestamp2);
    
    $cnt_weeks = $weekNrEnd-$weekNrStart;
    if($cnt_weeks<0) $cnt_weeks = 52-$weekNrStart+$weekNrEnd;
    $delta = $cnt_weeks*7*24*3600;
    $timestamp2 = $startdate-7*24*3600;
    $timestamp1 = $timestamp2-$delta;
    
    
    echo $timestamp1."&enddate=".$timestamp2;
  } else {
    $timestamp = strtotime("last monday",$startdate);
    $timestamp2 = strtotime("next monday",$startdate);
    if($timestamp2-$timestamp>604800) {
      $timestamp1 = strtotime("today",$startdate);
    } elseif(date('W',$timestamp)<date('W',$startdate)) $timestamp1 = $timestamp2;
    $periodStart = date('d.m.y',$timestamp1);
    
    $timestamp = strtotime("last sunday",$startdate);
    $timestamp2 = strtotime("next sunday",$startdate);
    if($timestamp2-$timestamp>604800) {
      $timestamp2 = strtotime("today",$startdate);
    } elseif(date('W',$timestamp)<date('W',$startdate)) $timestamp2 = $timestamp2;
    $periodEnd = date('d.m.y',$timestamp2);
    
    $delta = $timestamp2-$timestamp1;
    $timestamp2 = $startdate-24*3600;
    $timestamp1 = $timestamp2-$delta;
    echo $timestamp1."&enddate=".$timestamp2;
  }
 ?>"><img src="img/pfeil_links.gif" border="0" alt="<?php echo getTranslation(529,$_GET['lang']); ?>" /></a></div><div style="float:right;"><a href="<?php echo $_SERVER['PHP_SELF']; ?>?view=<?php echo $_GET['view']; ?>&semester=<?php echo $_GET['semester']; ?>&class=<?php echo $_GET['class']; ?>&startdate=<?php 

  if($_GET['view']=="all" || $_GET['view']=="month") $timestamp1 = $enddate+7*24*3600;
  else $timestamp1 = $enddate+24*3600;
  
  $timestamp2 = $timestamp1+$delta;
  echo $timestamp1;
  if($_GET['view']=="all") echo "&enddate=".$timestamp2;
  ?>"><img src="img/pfeil.gif" border="0" alt="<?php echo getTranslation(530,$_GET['lang']); ?>" /></a></div>
 <?php
  echo getTranslation(522,$_GET['lang']).": ".$periodStart." - ".$periodEnd;
 ?>
  </div>
  <div id="slidetabsmenu">
    <ul>
      <li<?php if($_GET['view']=="week") echo ' id="current"'; ?>><a href="<?php echo $_SERVER['PHP_SELF']; ?>?view=week&changeview=1&semester=<?php echo $_GET['semester']; ?>&class=<?php echo $_GET['class']; ?>&startdate=<?php echo $startdate; ?>"><span><?php echo getTranslation(503,$_GET['lang']); ?></span></a></li>
      <li<?php if($_GET['view']=="month") echo ' id="current"'; ?>><a href="<?php echo $_SERVER['PHP_SELF']; ?>?view=month&changeview=1&semester=<?php echo $_GET['semester']; ?>&class=<?php echo $_GET['class']; ?>&startdate=<?php echo $startdate; ?>"><span><?php echo getTranslation(504,$_GET['lang']); ?></span></a></li>
      <li<?php if($_GET['view']=="all") echo ' id="current"'; ?>><a href="#" onclick="showAll()"><span><?php echo getTranslation(505,$_GET['lang']); ?></span></a></li>
    </ul>
  </div>
  <br style="clear: both;" />
  
  <?php
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
            if(!empty($_GET['class']) && !empty($_GET['semester'])) echo "<div id=\"plan_".$bookings[$lessonIndex][0]."\" style=\"float:right;cursor:pointer;margin:0;padding:0;color:red;\" onclick=\"deleteLessonById('".$days[$i]."_".floor($data['TU_START']/60)."_".str_pad(($data['TU_START']%60),2,"0",STR_PAD_LEFT)."')\">x</div>";
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
          if(!empty($_GET['class']) && !empty($_GET['semester'])) echo "<div id=\"plan_".$bookings[$lessonIndex][0]."\" style=\"float:right;cursor:pointer;margin:0;padding:0;color:red;\" onclick=\"deleteLessonById('".$days[$i]."_".floor($data['TU_START']/60)."_".str_pad(($data['TU_START']%60),2,"0",STR_PAD_LEFT)."')\">x</div>";
          echo $bookings[$lessonIndex][2];
        } else echo "&nbsp;";
        echo "</div></td>";
      }
      echo "</tr>";
    }
    echo '</table>';
  }
  ?>
  
  
</div>

<script type="text/javascript" src="lib/prototype.js"></script>
<script type="text/javascript" src="lib/scriptaculous.js"></script>
<script type='text/javascript' src='lib/datejs/globalization/de-DE.js'></script>
<script type='text/javascript' src='lib/datejs/core.js'></script>
<script type='text/javascript' src='lib/datejs/sugarpak.js'></script>
<script type='text/javascript' src='lib/datejs/parser.js'></script>
<script type="text/javascript" src="lib/dateslider.js"></script>
<script type="text/javascript" src="lib/funcs.js"></script>
<script type="text/javascript">
// <![CDATA[
p_oDateSlider = new DateSlider('sliderbar', '<?php echo date('j.n.Y',$startdate); ?>', '<?php echo date('j.n.Y',$enddate); ?>', 2000, 2015);		
p_oDateSlider.attachFields($('datestart'), $('dateend'));

<?php
if(!empty($_GET['class']) && !empty($_GET['semester'])) {
?>
var dragables = document.getElementsByClassName('loadedSubjects');
for(var i=0;i<dragables.length;i++) {
  new Draggable( dragables[i], {revert:true });
}

var dropables = document.getElementsByClassName('dropables');
for(var i=0;i<dropables.length;i++) {
  dropables[i].ondblclick = function() {
    var droppedIntoDateIDArray = this.id.replace('date_','').split("_");
    var droppedIntoDate = Date.parse(droppedIntoDateIDArray[0]+"."+droppedIntoDateIDArray[1]+"."+droppedIntoDateIDArray[2]+" "+droppedIntoDateIDArray[3]+":"+droppedIntoDateIDArray[4]);

    var url = "";
    if(this.firstChild.nodeName=="DIV") {
      // chose a lesson
      url = 'roomplanning.php?lang=<?php echo $_GET['lang']; ?>&curriculumID='+this.firstChild.id.replace('plan_','')+'&date='+Math.floor(droppedIntoDate.getTime()/1000);
    } else {
      // chose a free date & time
      url = 'roomplanning.php?lang=<?php echo $_GET['lang']; ?>&date='+Math.floor(droppedIntoDate.getTime()/1000);
    }
    openRoomPlanning(url);
  }
  
  dropables[i].title = "<?php echo getTranslation(523,$_GET['lang']); ?>";
  
  Droppables.add(dropables[i], {hoverclass:"dropHover",accept:"loadedSubjects",onDrop:function(draggable,droparea) {    
    var color;
    var oldDropDate;
    var lesson = draggable.lastChild.nodeValue;
    
    if(draggable.firstChild.style.backgroundColor!="") {
      // add lesson to timetable
      color = draggable.firstChild.style.backgroundColor;
    } else {
      // move lesson within timetable
      color = draggable.style.backgroundColor;
      var fetchedFromDateIDArray = draggable.id.replace('date_','').split("_");
      var oldDropDate = Date.parse(fetchedFromDateIDArray[0]+"."+fetchedFromDateIDArray[1]+"."+fetchedFromDateIDArray[2]+" "+fetchedFromDateIDArray[3]+":"+fetchedFromDateIDArray[4]);
    }
    
    var droppedIntoDateIDArray = droparea.id.replace('date_','').split("_");
    var droppedIntoDate = Date.parse(droppedIntoDateIDArray[0]+"."+droppedIntoDateIDArray[1]+"."+droppedIntoDateIDArray[2]+" "+droppedIntoDateIDArray[3]+":"+droppedIntoDateIDArray[4]);

    if(draggable.id.indexOf("subject_")>-1) {
      // new lesson in timetable
      if(!moveTermin(droppedIntoDate,color,lesson,draggable.id.replace('subject_',''))) {
        alert("<?php echo getTranslation(534,$_GET['lang']); ?>");
        //deleteLesson(droppedIntoDate);
        return false;
      }
      if($('rest'+draggable.id.replace('subject_','')).innerHTML<=0) {
        alert("<?php echo getTranslation(535,$_GET['lang']); ?>");
        deleteLesson(droppedIntoDate);
        return false;
      }
      
      xajax_moveLesson(draggable.id.replace('subject_',''),Math.floor(droppedIntoDate.getTime()/1000));
      $('rest'+draggable.id.replace('subject_','')).innerHTML = parseInt($('rest'+draggable.id.replace('subject_','')).innerHTML) - 2;
    } else {
      // moved old lesson
      if(!moveTermin(droppedIntoDate,color,lesson,draggable.firstChild.id.replace('plan_',''))) {
        alert("<?php echo getTranslation(536,$_GET['lang']); ?>");
        //deleteLesson(droppedIntoDate);
        return false;
      }
      xajax_moveLesson(draggable.firstChild.id.replace('plan_',''),Math.floor(droppedIntoDate.getTime()/1000),Math.floor(oldDropDate.getTime()/1000));
    }
    
    if(oldDropDate) {
      deleteLesson(oldDropDate);
    }
  }});
}
<?php
}
?>

function showAll() {
  var start = Date.parse($('datestart').value);
  var end = Date.parse($('dateend').value);
  
  window.location.href = "<?php echo $_SERVER['PHP_SELF']; ?>?view=all&changeview=1&semester=<?php echo $_GET['semester']; ?>&class=<?php echo $_GET['class']; ?>&startdate="+Math.floor(start.getTime()/1000)+"&enddate="+Math.floor(end.getTime()/1000);
}

function moveTermin(firstGoal,color,lesson,curriculum_id) {
  var terminid = firstGoal.toString("d_M_yyyy_H_mm");
  if($('date_'+terminid).innerHTML!="&nbsp;") return false;
  $('date_'+terminid).style.backgroundColor = color;
  $('date_'+terminid).style.color = "rgb("+getContrast(color.substring(4,color.length-1))+")";
  $('date_'+terminid).innerHTML = "<div id=\"plan_"+curriculum_id+"\" style=\"float:right;cursor:pointer;margin:0;padding:0;color:red;\" onclick=\"deleteLessonById('"+terminid+"');\">x</div>"+lesson;
  new Draggable( $('date_'+terminid), {revert:true });
  $('date_'+terminid).className = "dropables loadedSubjects";
  return true;
}

function deleteLesson(firstOldTime,writetoDB) {
  if(firstOldTime) { 
  // xajax_deleteBooking($('date_'+firstOldTime.toString("d_M_yyyy_H_mm")).firstChild.id.replace('plan_',''),Math.floor(firstOldTime.getTime()/1000));
    $('date_'+firstOldTime.toString("d_M_yyyy_H_mm")).style.backgroundColor = "transparent";
    $('date_'+firstOldTime.toString("d_M_yyyy_H_mm")).innerHTML = "&nbsp;";
    $('date_'+firstOldTime.toString("d_M_yyyy_H_mm")).className = "dropables";
  }
}

function deleteLessonById(id) {
  var lessonID = id.split("_");
  var lessonDate = Date.parse(lessonID[0]+"."+lessonID[1]+"."+lessonID[2]+" "+lessonID[3]+":"+lessonID[4]);
  xajax_deleteBooking($('date_'+lessonDate.toString("d_M_yyyy_H_mm")).firstChild.id.replace('plan_',''),Math.floor(lessonDate.getTime()/1000));
  $('rest'+$('date_'+lessonDate.toString("d_M_yyyy_H_mm")).firstChild.id.replace('plan_','')).innerHTML = parseInt($('rest'+$('date_'+lessonDate.toString("d_M_yyyy_H_mm")).firstChild.id.replace('plan_','')).innerHTML)+2;
  
  $('date_'+lessonDate.toString("d_M_yyyy_H_mm")).style.backgroundColor = "transparent";
  $('date_'+lessonDate.toString("d_M_yyyy_H_mm")).innerHTML = "&nbsp;";
  $('date_'+lessonDate.toString("d_M_yyyy_H_mm")).className = "dropables";
}
// ]]>
</script>
<?php $xajax->printJavascript('lib/'); ?>
</body>
</html>
