<?php
require 'lib/funcs.php';

require ("lib/xajax.inc.php");
require('ajax/common.php');
$_GET['date'] = (int)$_GET['date'];
$_GET['curriculumID'] = (int)$_GET['curriculumID'];
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
  <head>
    <title>University Scheduling System: Raumplanung</title>
    <meta http-equiv="content-type" content="text/html; charset=iso-8859-1" />
    <link rel="stylesheet" href="css/style.css" type = "text/css" />
<style type="text/css">
td {text-align:left;}
</style>
  </head>
  <body>
  <?php
  echo '<h2>'.date('d.m.y',$_GET['date']).'</h2>';
  
  $rsTimes = mysql_query("SELECT TU_START,TU_DURATION,TU_TYP FROM timeunits WHERE TU_TYP='1' ORDER BY TU_START");
  $cnt_times = mysql_num_rows($rsTimes);
  $starttimes = array();
  echo '<table style="width:100%;border-collapse:collapse;border:solid 2px #aaa;width:100%;font-size:80%;"><tr><th>&nbsp;</th>';
  while($data = mysql_fetch_assoc($rsTimes)) {
    echo "<th style=\"font-weight:900;background:#DEF;color:#019;border-right:solid 1px #bbb;\">".floor($data['TU_START']/60).":".str_pad(($data['TU_START']%60),2,"0",STR_PAD_LEFT)." - ".floor(($data['TU_START']+$data['TU_DURATION'])/60).":".str_pad((($data['TU_START']+$data['TU_DURATION'])%60),2,"0",STR_PAD_LEFT)."</th>";
    $starttimes[] = floor($data['TU_START']/60)."_".str_pad(($data['TU_START']%60),2,"0",STR_PAD_LEFT);
  }
  
  echo '</tr>';
  
  
  $rs = mysql_query("SELECT booking.book_id,UNIX_TIMESTAMP(book_begin) AS begin,sub_name,class_name,room_nr FROM booking INNER JOIN curriculum ON booking.cur_id=curriculum.cur_id INNER JOIN subject ON curriculum.sub_id=subject.sub_id INNER JOIN class ON curriculum.class_id=class.class_id INNER JOIN room ON booking.room_id=room.room_id WHERE book_begin>='".date('Y-m-d 00:00:00',$_GET['date'])."' AND book_end<='".date('Y-m-d 23:59:59',$_GET['date'])."'");
  $bookings = array();
  while($data = mysql_fetch_assoc($rs)) {
    $bookings[] = array($data['book_id'],$data['room_nr'],$data['begin'],$data['sub_name'],$data['class_name']);
  }
  
  if($_GET['curriculumID']) {
    echo '<tr><th style="text-align:left;font-weight:900;border-right:solid 1px #bbb;cursor:pointer;" onclick="switchVisibility(\'default\')"><img src="img/open.gif" alt="Standardräume dieser Seminargruppe anzeigen" title="Standardräume dieser Seminargruppe anzeigen" id="icon_default" /> Standard-Räume</th><td colspan="'.$cnt_times.'" style="background:#eee;">&nbsp;</td></tr>';

    $rs = mysql_query("SELECT room_nr,room_name FROM room INNER JOIN defaultrooms ON room.room_id=defaultrooms.room_id WHERE room_seat>=(SELECT class_count FROM class WHERE class_id=(SELECT class_id FROM curriculum WHERE cur_id='".$_GET['curriculumID']."')) ORDER BY priority");
    while($data = mysql_fetch_assoc($rs)) {
      echo '<tr style="display:table-row;" class="default"><td style="background:#DEF;color:#019;border-right:solid 1px #bbb;padding-left:23px;">'.$data['room_name'].' ('.$data['room_nr'].')</td>';
      for($i=0;$i<$cnt_times;$i++) {
        $zeit = explode("_",$starttimes[$i]);
        $zeit = mktime($zeit[0],(int)($zeit[1]),0,date('n',$_GET['date']),date('j',$_GET['date']),date('Y',$_GET['date']));
        $lessonIndex = getLessonAtRoomAndTime($zeit,$data['room_nr'],$bookings);
        echo "<td style=\"border-right:solid 1px #bbb;text-align:center;\">";
        if($lessonIndex!==false) {
          echo "<div class=\"dropables draggable\" style=\"background:rgb(255,255,0);\" id=\"roomdefault_".$data['room_nr']."_".$starttimes[$i]."\"><span id=\"book_".$bookings[$lessonIndex][0]."\">".$bookings[$lessonIndex][3]." (".$bookings[$lessonIndex][4].")</span></div>";
        } else echo "<div class=\"dropables\" id=\"roomdefault_".$data['room_nr']."_".$starttimes[$i]."\">&nbsp;</div>";
        echo "</td>";
      }
      echo '</tr>';
    }
  }
  
  echo '<tr><th style="text-align:left;font-weight:900;border-right:solid 1px #bbb;cursor:pointer;" onclick="switchVisibility(\'labor\')"><img src="img/closed.gif" alt="Labore anzeigen" title="Labore anzeigen" id="icon_labor" /> Labore</th><td colspan="'.$cnt_times.'" style="background:#eee;">&nbsp;</td></tr>';

  $rs = mysql_query("SELECT room_nr,room_name FROM room WHERE room_type>0".(($_GET['curriculum_ID'])?" AND room_seat>=(SELECT class_count FROM class WHERE class_id=(SELECT class_id FROM curriculum WHERE cur_id='".$_GET['curriculumID']."'))":"")." ORDER BY room_nr");
  while($data = mysql_fetch_assoc($rs)) {
    echo '<tr style="display:none;" class="labor"><td style="background:#DEF;color:#019;border-right:solid 1px #bbb;padding-left:23px;">'.$data['room_name'].' ('.$data['room_nr'].')</td>';
    for($i=0;$i<$cnt_times;$i++) {
      $zeit = explode("_",$starttimes[$i]);
      $zeit = mktime($zeit[0],(int)($zeit[1]),0,date('n',$_GET['date']),date('j',$_GET['date']),date('Y',$_GET['date']));
      $lessonIndex = getLessonAtRoomAndTime($zeit,$data['room_nr'],$bookings);
      echo "<td style=\"border-right:solid 1px #bbb;text-align:center;\">";
      if($lessonIndex!==false) {
        echo "<div class=\"dropables draggable\" style=\"background:rgb(255,255,0);\" id=\"roomlabor_".$data['room_nr']."_".$starttimes[$i]."\"><span id=\"book_".$bookings[$lessonIndex][0]."\">".$bookings[$lessonIndex][3]." (".$bookings[$lessonIndex][4].")</span></div>";
      } else echo "<div class=\"dropables\" id=\"roomlabor_".$data['room_nr']."_".$starttimes[$i]."\">&nbsp;</div>";
      echo "</td>";
    }
    echo '</tr>';
  }
  
  echo '<tr><th style="text-align:left;font-weight:900;border-right:solid 1px #bbb;cursor:pointer;" onclick="switchVisibility(\'all\')"><img src="img/closed.gif" alt="Alle Räume anzeigen" title="Alle Räume anzeigen" id="icon_all" /> Alle</th><td colspan="'.$cnt_times.'" style="background:#eee;">&nbsp;</td></tr>';

  $rs = mysql_query("SELECT room_nr,room_name FROM room WHERE ".(($_GET['curriculum_ID'])?" AND room_seat>=(SELECT class_count FROM class WHERE class_id=(SELECT class_id FROM curriculum WHERE cur_id='".$_GET['curriculumID']."'))":"1")." ORDER BY room_nr");
  while($data = mysql_fetch_assoc($rs)) {
    echo '<tr style="display:none;" class="all"><td style="background:#DEF;color:#019;border-right:solid 1px #bbb;padding-left:23px;">'.$data['room_name'].' ('.$data['room_nr'].')</td>';
    for($i=0;$i<$cnt_times;$i++) {
      $zeit = explode("_",$starttimes[$i]);
      $zeit = mktime($zeit[0],(int)($zeit[1]),0,date('n',$_GET['date']),date('j',$_GET['date']),date('Y',$_GET['date']));
      $lessonIndex = getLessonAtRoomAndTime($zeit,$data['room_nr'],$bookings);
      echo "<td style=\"border-right:solid 1px #bbb;text-align:center;\">";
      if($lessonIndex!==false) {
        echo "<div class=\"dropables draggable\" style=\"background:rgb(255,255,0);\" id=\"roomall_".$data['room_nr']."_".$starttimes[$i]."\"><span id=\"book_".$bookings[$lessonIndex][0]."\">".$bookings[$lessonIndex][3]." (".$bookings[$lessonIndex][4].")</span></div>";
      } else echo "<div class=\"dropables\" id=\"roomall_".$data['room_nr']."_".$starttimes[$i]."\">&nbsp;</div>";
      echo "</td>";
    }
    echo '</tr>';
  }
  echo '</table>';
  ?>
    
<script type="text/javascript" src="lib/prototype.js"></script>
<script type="text/javascript" src="lib/scriptaculous.js"></script>
<script type="text/javascript" src="lib/funcs.js"></script>
<script type="text/javascript">
var dragables = document.getElementsByClassName('draggable');
for(var i=0;i<dragables.length;i++) {
  new Draggable( dragables[i], {revert:true,constraint:'vertical' });
}

var dropables = document.getElementsByClassName('dropables');
for(var i=0;i<dropables.length;i++) {
  Droppables.add(dropables[i], {hoverclass:"dropHover",accept:"draggable",onDrop:function(draggable,droparea) {
    var bookID = draggable.firstChild.id.replace('book_','');
    var room = draggable.id.split("_");
    var old_room_nr = room[1];
    var time = room[2]+"_"+room[3];
    var color = draggable.style.backgroundColor;
    
    var newroom = droparea.id.split("_");
    var new_room_nr = newroom[1];

    xajax_changeRoom(bookID,new_room_nr);
    
    var views = new Array();
    views[0] = "default";
    views[1] = "labor";
    views[2] = "all";
    
    for(var i=0;i<views.length;i++) {
      // put lesson to new room
      if($('room'+views[i]+'_'+new_room_nr+'_'+time)) {
        $('room'+views[i]+'_'+new_room_nr+'_'+time).innerHTML = $('room'+views[i]+'_'+old_room_nr+'_'+time).innerHTML;
        $('room'+views[i]+'_'+new_room_nr+'_'+time).style.background = color;
        $('room'+views[i]+'_'+new_room_nr+'_'+time).className = "dropables draggable";
        new Draggable( $('room'+views[i]+'_'+new_room_nr+'_'+time), {revert:true,constraint:'vertical' });
      }
      
      if($('room'+views[i]+'_'+old_room_nr+'_'+time)) {
        // delete lesson from old room
        $('room'+views[i]+'_'+old_room_nr+'_'+time).innerHTML = '&nbsp;';
        $('room'+views[i]+'_'+old_room_nr+'_'+time).style.background = 'transparent';
        $('room'+views[i]+'_'+old_room_nr+'_'+time).className = "dropables";
      }
    }
  } });
}

function switchVisibility(className) {
  var elements = document.getElementsByClassName(className);
  if(elements[0].style.display=="none") {
    // show all rows
    for(var i=0;i<elements.length;i++) {
      try {
        // for FF
        elements[i].style.display = "table-row";
      } catch(e) {
        // for IE
        elements[i].style.display = "block";
      }
    }
  } else {
    // hide all rows
    for(var i=0;i<elements.length;i++) {
      elements[i].style.display = "none";
    }
  }
  
  var icon = $('icon_'+className);
  if(icon.src.indexOf("open.gif")>-1) icon.src = "img/closed.gif";
  else icon.src = "img/open.gif";
}
</script>
<?php $xajax->printJavascript('lib/'); ?>
  </body>
</html>