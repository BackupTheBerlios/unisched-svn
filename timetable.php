<?php
require 'lib/funcs.php';

require ("lib/xajax.inc.php");
require('ajax/common.php');

if(empty($_GET['startdate']) && !empty($_GET['class']) && !empty($_GET['semester'])) {
  $rs = mysql_query("SELECT UNIX_TIMESTAMP(MIN(class_period_begin)) AS start,UNIX_TIMESTAMP(MAX(class_period_end)) AS end FROM class_period WHERE term_id='".$_GET['semester']."' AND class_id='".$_GET['class']."'");
  $data = mysql_fetch_assoc($rs);
  $_GET['startdate'] = $data['start'];
  $_GET['enddate'] = $data['end'];
}

// Prüfung der GET-Parameter auf Korrektheit
if($_GET['view']!="week") {
  if(empty($_GET['startdate'])) $startdate = time();
  else $startdate = $_GET['startdate'];
} elseif($_GET['view']=="week") {
  if(empty($_GET['startdate'])) $startdate = time();
  else $startdate = $_GET['startdate'];
  $timestamp = strtotime("last ".$wochentage[0],$startdate);
  $timestamp2 = strtotime("next ".$wochentage[0],$startdate);
  if($timestamp2-$timestamp>604800) $timestamp = strtotime("today",$startdate);
  elseif(date('W',$timestamp)<date('W',$startdate)) $timestamp = $timestamp2;
  $startdate = $timestamp;
} else $startdate = $_GET['startdate'];

if(empty($_GET['enddate'])) $enddate = time()+90*24*3600;
else $enddate = $_GET['enddate'];

if(empty($_GET['view'])) $_GET['view'] = "all";
?><!DOCTYPE html 
     PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head>
<title>University Scheduling System: Zeitplanung</title>
<link rel="stylesheet" href="css/dateslider.css" type = "text/css" />
<link rel="stylesheet" href="css/tabs.css" type = "text/css" />
<link rel="stylesheet" href="css/style.css" type = "text/css" />
</head>	
<body>

<div style="position:absolute;top:10px;left:210px;min-width:800px;">
  <div id = "slider-container" style="float:left;">
  	<div id = "sliderbar"></div>
  </div>
  <div>
  <label for = "datestart" style="width:40px;float:left;margin-top:3px;padding-right:5px;text-align:right;">Von:</label>  <input type = "text" id = "datestart" style="margin-bottom:3px;" /><br />
  <label for = "dateend" style="width:40px;float:left;margin-top:3px;padding-right:5px;text-align:right;">Bis:</label> <input type = "text" id = "dateend" /> <input type="button" value="Aktualisieren" onclick="showAll()" />
  </div>
</div>
<div>
  <select id="class"><option value="0">-- Matrikel --</option><?php
  $rs = mysql_query("SELECT DISTINCT class.class_id,class_name FROM class_period INNER JOIN class ON class_period.class_id=class.class_id WHERE class_period_end>NOW() ORDER BY class_name");
  while($data = mysql_fetch_assoc($rs)) {
    echo "<option value=\"".$data['class_id']."\"";
    if($_GET['class']==$data['class_id']) echo "selected=\"selected\"";
    echo ">".$data['class_name']."</option>";
  }
  ?></select><br />
  <select id="semester"><option value="0">-- Semester --</option><?php
  $rs = mysql_query("SELECT MAX(term_id) FROM class_period");
  $maxTerms = mysql_result($rs,0);
  for($i=1;$i<=$maxTerms;$i++) {
    echo "<option value=\"".$i."\"";
    if($_GET['semester']==$i) echo "selected=\"selected\"";
    echo ">".$i.". Semester</option>";
  }
  ?></select>
  <input type="button" value="Laden" onclick="window.location.href='<?php echo $_SERVER['PHP_SELF']; ?>?class='+$('class').value+'&semester='+$('semester').value" />
</div>

<div style="position:absolute;top:94px;left:0px;width:195px;"><h3 style="margin:0 3px 12px;">Fächer</h3>
<?php

$bookings = array();




$colors = array();
if(!empty($_GET['class']) && !empty($_GET['semester'])) {
  // Select all units within the selected period
  $rs = mysql_query("SELECT curriculum.cur_id,UNIX_TIMESTAMP(book_begin) AS begin,sub_name FROM booking INNER JOIN curriculum ON booking.cur_id=curriculum.cur_id INNER JOIN subject ON curriculum.sub_id=subject.sub_id WHERE book_begin>='".date('Y-m-d H:i:00',$startdate)."' AND class_id='".$_GET['class']."'");
  while($data = mysql_fetch_assoc($rs)) {
    $bookings[] = array($data['cur_id'],$data['begin'],$data['sub_name']);
  }
  
  
  
  $rs = mysql_query("SELECT cur_id,sub_name,cur_cnt_sub,lec_gname,lec_lname,lec_tel FROM curriculum INNER JOIN class_period ON curriculum.class_period_id=class_period.class_period_id INNER JOIN subject ON curriculum.sub_id=subject.sub_id INNER JOIN lecturer ON curriculum.lec_id=lecturer.lec_id WHERE class_period_begin<='".date('Y-m-d',$startdate)."' AND class_period_end>='".date('Y-m-d',$enddate)."' AND term_id='".$_GET['semester']."' AND curriculum.class_id='".$_GET['class']."'");
  $r = 255;
  $g = 255;
  $b = 0;
  
  while($data = mysql_fetch_assoc($rs)) {
    echo '<div class="lesson" title="Tel.: '.$data['lec_tel'].'"><a href="#"><img src="img/edit.gif" style="float:right;margin:0 4px;border:none;" alt="Vorlesung bearbeiten" title="Vorlesung bearbeiten" /></a><div class="loadedSubjects" id="subject_'.$data['cur_id'].'" style="width:130px"><div style="width:13px;height:13px;background-color:rgb('.$r.','.$g.','.$b.');border:solid 1px #222;float:left;margin-right:3px;"></div>'.$data['sub_name'].'</div>'.$data['lec_lname'].(($data['lec_gname'])?', '.$data['lec_gname']:'').' - <span id="rest'.$data['cur_id'].'">'.($data['cur_cnt_sub']-getTerminatedLessonCnt($data['cur_id'],$bookings)).'</span> h</div>';
    $colors[$data['cur_id']] = array($r,$g,$b);
    $r = ($r+33)%256;
    $g = ($g+66)%256;
    $b = ($b+99)%256;
  }
} else {
  // Select all units within the selected period
  $rs = mysql_query("SELECT curriculum.cur_id,UNIX_TIMESTAMP(book_begin) AS begin,sub_name FROM booking INNER JOIN curriculum ON booking.cur_id=curriculum.cur_id INNER JOIN subject ON curriculum.sub_id=subject.sub_id WHERE book_begin>='".date('Y-m-d H:i:00',$startdate)."'");
  while($data = mysql_fetch_assoc($rs)) {
    $bookings[] = array($data['cur_id'],$data['begin'],$data['sub_name']);
  }
  for($i=0;$i<=1000;$i++) {
    $colors[] = array(150,150,150);
  }
}
?></div>

<div style="padding-left:200px;margin-top:49px;">
  <div id="slidetabsmenu">
    <ul>
      <li<?php if($_GET['view']=="week") echo ' id="current"'; ?>><a href="<?php echo $_SERVER['PHP_SELF']; ?>?view=week&semester=<?php echo $_GET['semester']; ?>&class=<?php echo $_GET['class']; ?>&startdate=<?php echo $startdate; ?>"><span>Woche</span></a></li>
      <li<?php if($_GET['view']=="month") echo ' id="current"'; ?>><a href="<?php echo $_SERVER['PHP_SELF']; ?>?view=month&semester=<?php echo $_GET['semester']; ?>&class=<?php echo $_GET['class']; ?>&startdate=<?php echo $startdate; ?>"><span>Monat</span></a></li>
      <li<?php if($_GET['view']=="all") echo ' id="current"'; ?>><a href="#" onclick="showAll()"><span>Gesamtzeitraum</span></a></li>
    </ul>
  </div>
  <br style="clear: left;" />
  
  <?php
  $rsTimes = mysql_query("SELECT TU_START,TU_DURATION,TU_TYP FROM timeunits WHERE TU_TYP='1' ORDER BY TU_START");
  if($_GET['view']=="month" || $_GET['view']=="all") {
    echo '<table style="border-collapse:collapse;border:solid 2px #aaa;font-size:80%;width:100%" id="monatstable">';
    $spalteheute = 0;
    
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
      for($i=$weekNrStart;$i<=$weekNrEnd;$i++) {
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
        
        for($i=0;$i<=$weekNrEnd-$weekNrStart;$i++) {
          echo "<td style=\"";
          $dateArr = explode("_",$days[$i]);
          $zeit = mktime(floor($data['TU_START']/60),$data['TU_START']%60,0,$dateArr[1],$dateArr[0],$dateArr[2]); 
          $lessonIndex = getLessonAtTime($zeit,$bookings);
          
          if($i==$spalteheute) echo "background:#FFC;";
          elseif($i<=$spalteheute || ($spalteheute==0 && $timestamp<time())) echo "background:#fafafa;";
          echo "\"><div class=\"dropables";
          if($lessonIndex!==false) echo " loadedSubjects";
          echo "\" id=\"date_".$days[$i]."_".floor($data['TU_START']/60)."_".str_pad(($data['TU_START']%60),2,"0",STR_PAD_LEFT)."\"";
          if($lessonIndex!==false) echo " style=\"background:rgb(".$colors[$bookings[$lessonIndex][0]][0].",".$colors[$bookings[$lessonIndex][0]][1].",".$colors[$bookings[$lessonIndex][0]][2].");color:rgb(".getContrastColor($colors[$bookings[$lessonIndex][0]][0],$colors[$bookings[$lessonIndex][0]][1],$colors[$bookings[$lessonIndex][0]][2]).");\"";
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
    
    $spalteheute = 0;
    
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
        elseif($i<=$spalteheute || ($spalteheute==0 && $timestamp<time())) echo "background:#fafafa;";
        echo "\"><div class=\"dropables";
        if($lessonIndex!==false) echo " loadedSubjects";
        echo "\" id=\"date_".$days[$i]."_".floor($data['TU_START']/60)."_".str_pad(($data['TU_START']%60),2,"0",STR_PAD_LEFT)."\"";
        if($lessonIndex!==false) echo " style=\"background:rgb(".$colors[$bookings[$lessonIndex][0]][0].",".$colors[$bookings[$lessonIndex][0]][1].",".$colors[$bookings[$lessonIndex][0]][2].");color:rgb(".getContrastColor($colors[$bookings[$lessonIndex][0]][0],$colors[$bookings[$lessonIndex][0]][1],$colors[$bookings[$lessonIndex][0]][2]).");\"";
        echo ">";
        
        if($lessonIndex!==false) {
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
      url = 'http://localhost/roomplanning.php?curriculumID='+this.firstChild.id.replace('plan_','')+'&date='+Math.floor(droppedIntoDate.getTime()/1000);
    } else {
      url = 'http://localhost/roomplanning.php?date='+Math.floor(droppedIntoDate.getTime()/1000);
    }
    openRoomPlanning(url);
  }
  
  dropables[i].title = "Zum Bearbeiten der Räume zu diesem Zeitpunkt klicken Sie bitte doppelt auf die gewünschte Zeit.";
  
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
      if(!moveTermin(droppedIntoDate,color,lesson,draggable.id.replace('subject_',''))) {
        alert("Zu diesem Zeitpunkt ist bereits eine andere Vorlesung verplant.");
        //deleteLesson(droppedIntoDate);
        return false;
      }
      if($('rest'+draggable.id.replace('subject_','')).innerHTML<=0) {
        alert("Sämtliche Vorlesungen dieses Faches, die laut Curriculum vorgeschrieben sind, sind bereits verplant.");
        deleteLesson(droppedIntoDate);
        return false;
      }
      
      xajax_moveLesson(draggable.id.replace('subject_',''),Math.floor(droppedIntoDate.getTime()/1000));
      $('rest'+draggable.id.replace('subject_','')).innerHTML = parseInt($('rest'+draggable.id.replace('subject_','')).innerHTML) - 1;
    } else {
      if(!moveTermin(droppedIntoDate,color,lesson,draggable.firstChild.id.replace('plan_',''))) {
        alert("Zu diesem Zeitpunkt ist bereits eine andere Vorlesung verplant.");
        //deleteLesson(droppedIntoDate);
        return false;
      }
      xajax_moveLesson(draggable.firstChild.id.replace('plan_',''),Math.floor(droppedIntoDate.getTime()/1000));
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
  
  window.location.href = "<?php echo $_SERVER['PHP_SELF']; ?>?view=all&semester=<?php echo $_GET['semester']; ?>&class=<?php echo $_GET['class']; ?>&startdate="+Math.floor(start.getTime()/1000)+"&enddate="+Math.floor(end.getTime()/1000);
}

function moveTermin(firstGoal,color,lesson,curriculum_id) {
  var terminid = firstGoal.toString("d_M_yyyy_H_mm");
  if($('date_'+terminid).innerHTML!="&nbsp;") return false;
  $('date_'+terminid).style.backgroundColor = color;
  $('date_'+terminid).style.color = "rgb("+getContrast(color.substr(4,color.length-2))+")";
  $('date_'+terminid).innerHTML = "<div id=\"plan_"+curriculum_id+"\" style=\"float:right;cursor:pointer;margin:0;padding:0;color:red;\" onclick=\"deleteLessonById('"+terminid+"');\">x</div>"+lesson;
  new Draggable( $('date_'+terminid), {revert:true });
  $('date_'+terminid).className = "dropables loadedSubjects";
  return true;
}

function deleteLesson(firstOldTime) {
  if(firstOldTime) { 
     xajax_deleteBooking($('date_'+firstOldTime.toString("d_M_yyyy_H_mm")).firstChild.id.replace('plan_',''),Math.floor(firstOldTime.getTime()/1000));
    $('date_'+firstOldTime.toString("d_M_yyyy_H_mm")).style.backgroundColor = "transparent";
    $('date_'+firstOldTime.toString("d_M_yyyy_H_mm")).innerHTML = "&nbsp;";
    $('date_'+firstOldTime.toString("d_M_yyyy_H_mm")).className = "dropables";
  }
}

function deleteLessonById(id) {
  var lessonID = id.split("_");
  var lessonDate = Date.parse(lessonID[0]+"."+lessonID[1]+"."+lessonID[2]+" "+lessonID[3]+":"+lessonID[4]);
  xajax_deleteBooking($('date_'+lessonDate.toString("d_M_yyyy_H_mm")).firstChild.id.replace('plan_',''),Math.floor(lessonDate.getTime()/1000));
  $('rest'+$('date_'+lessonDate.toString("d_M_yyyy_H_mm")).firstChild.id.replace('plan_','')).innerHTML = parseInt($('rest'+$('date_'+lessonDate.toString("d_M_yyyy_H_mm")).firstChild.id.replace('plan_','')).innerHTML)+1;
  $('date_'+lessonDate.toString("d_M_yyyy_H_mm")).style.backgroundColor = "transparent";
  $('date_'+lessonDate.toString("d_M_yyyy_H_mm")).innerHTML = "&nbsp;";
  $('date_'+lessonDate.toString("d_M_yyyy_H_mm")).className = "dropables";
}
// ]]>
</script>
<?php $xajax->printJavascript('lib/'); ?>
</body>
</html>

