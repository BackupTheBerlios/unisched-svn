<?php
/**

 @mainpage University Scheduling System (master data)
 @version 0.1
 @author Ivonne Seibt, Stephan Hilbrandt, Jan Walther
 @date 25-07-2008
 @brief source code documentation

 @defgroup Main Package Main functions
 @brief Room planning
*/

$SHOW_ROOMS_MULTIPLE = false;

require 'lib/funcs.php';

require ("lib/xajax.inc.php");
require('ajax/common.php');
$_GET['date'] = (int)$_GET['date'];
$_GET['curriculumID'] = (int)$_GET['curriculumID'];
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
  <head>
    <title>University Scheduling System: <?php echo getTranslation(519,$_GET['lang']); ?></title>
    <meta http-equiv="content-type" content="text/html; charset=iso-8859-1" />
    <link rel="stylesheet" href="css/style.css" type = "text/css" />
<style type="text/css">
td {text-align:left;}
.draggable {cursor:move;}
</style>
  </head>
  <body onunload="checkForDuplicateRooms()">
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
  
  $rs = mysql_query("SELECT book_id,UNIX_TIMESTAMP(book_begin) AS begin,sub_name,class_name,room_id,class.class_id,module_sub_id FROM booking INNER JOIN curriculum ON booking.cur_id=curriculum.cur_id JOIN subject INNER JOIN class ON curriculum.class_id=class.class_id WHERE (curriculum.sub_id=subject.sub_id OR (curriculum.mod_group_id=subject.mod_id AND booking.module_sub_id=subject.sub_id)) AND book_begin>='".date('Y-m-d 00:00:00',$_GET['date'])."' AND book_end<='".date('Y-m-d 23:59:59',$_GET['date'])."' GROUP BY book_id ORDER BY book_id");
  $rooms = array();   
  echo '<tr><th style="text-align:left;font-weight:900;border-right:solid 1px #bbb;cursor:pointer;">'.getTranslation(538,$_GET['lang']).'</th><td colspan="'.$cnt_times.'" style="background:#eee;">&nbsp;</td></tr>';
  $modules_subjects = array();
  while($data = mysql_fetch_assoc($rs)) {
    if($data['module_sub_id']>0 && !in_array($data['module_sub_id'].$data['begin'],$modules_subjects)) {
      $modules_subjects[] = $data['module_sub_id'].$data['begin'];
      if(isRoomAndTimeUsed($data['room_id'],$data['begin'],$rooms)!==false) {
        //here is the collission
        echo "<tr><td>&nbsp;</td>";
        for($i=0;$i<$cnt_times;$i++) {
          $zeit = explode("_",$starttimes[$i]);
          $zeit = mktime($zeit[0],(int)($zeit[1]),0,date('n',$_GET['date']),date('j',$_GET['date']),date('Y',$_GET['date']));
          
          if($data['begin']<$zeit) echo "<td style=\"border-right:solid 1px #bbb;text-align:center;\">&nbsp;</td>";
          elseif($data['begin']>$zeit) echo "<td style=\"border-right:solid 1px #bbb;text-align:center;\">&nbsp;</td>";
          else echo "<td style=\"border-right:solid 1px #bbb;text-align:center;\"><div class=\"draggable duplicate\" style=\"height:100%;padding:3px;margin:0;background:rgb(".(($data['class_id']*33)%256).",".(($data['class_id']*66)%256).",".(($data['class_id']*99)%256).");\" id=\"roomduplicate_".$data['room_nr']."_".$starttimes[$i]."\"><span id=\"book_".$data['book_id']."\" style=\"color:rgb(".getContrastColor(($data['class_id']*33)%256,($data['class_id']*66)%256,($data['class_id']*99)%256).")\">".$data['sub_name']." (".$data['class_name'].")</span></td>";
        }
        echo "</tr>";
      } else {
        $rooms[] = array($data['room_id'],$data['begin']);
      }
    }
  }
  
  $rs = mysql_query("SELECT book_id,UNIX_TIMESTAMP(book_begin) AS begin,sub_name,class_name,room_nr,class.class_id FROM booking INNER JOIN curriculum ON booking.cur_id=curriculum.cur_id JOIN subject INNER JOIN class ON curriculum.class_id=class.class_id INNER JOIN room ON booking.room_id=room.room_id WHERE (curriculum.sub_id=subject.sub_id OR (curriculum.mod_group_id=subject.mod_id AND booking.module_sub_id=subject.sub_id)) AND book_begin>='".date('Y-m-d 00:00:00',$_GET['date'])."' AND book_end<='".date('Y-m-d 23:59:59',$_GET['date'])."' ORDER BY book_id");
  $bookings = array();
  while($data = mysql_fetch_assoc($rs)) {
    $bookings[] = array($data['book_id'],$data['room_nr'],$data['begin'],$data['sub_name'],$data['class_name'],$data['class_id']);
  }
  
  $usedrooms = array();
  if($_GET['curriculumID']) {
    echo '<tr><th style="text-align:left;font-weight:900;border-right:solid 1px #bbb;cursor:pointer;" onclick="switchVisibility(\'default\')"><img src="img/open.gif" alt="'.getTranslation(526,$_GET['lang']).'" title="'.getTranslation(526,$_GET['lang']).'" id="icon_default" /> '.getTranslation(515,$_GET['lang']).'</th><td colspan="'.$cnt_times.'" style="background:#eee;">&nbsp;</td></tr>';

    $rs = mysql_query("SELECT room.room_id,room_nr,room_name FROM room INNER JOIN defaultrooms ON room.room_id=defaultrooms.room_id WHERE class_id=(SELECT class_id FROM curriculum WHERE cur_id='".$_GET['curriculumID']."') AND room_seat>=(SELECT class_count FROM class WHERE class_id=(SELECT class_id FROM curriculum WHERE cur_id='".$_GET['curriculumID']."')) ORDER BY priority");
    while($data = mysql_fetch_assoc($rs)) {
      echo '<tr style="display:table-row;" class="default"><td style="background:#DEF;color:#019;border-right:solid 1px #bbb;padding-left:23px;">'.$data['room_name'].' ('.$data['room_nr'].')</td>';
      $usedrooms[] = $data['room_id'];
      for($i=0;$i<$cnt_times;$i++) {
        $zeit = explode("_",$starttimes[$i]);
        $zeit = mktime($zeit[0],(int)($zeit[1]),0,date('n',$_GET['date']),date('j',$_GET['date']),date('Y',$_GET['date']));
        $lessonIndex = getLessonAtRoomAndTime($zeit,$data['room_nr'],$bookings);
        echo "<td style=\"border-right:solid 1px #bbb;text-align:center;\">";
        if($lessonIndex!==false) {
          echo "<div class=\"dropables draggable\" style=\"background:rgb(".(($bookings[$lessonIndex][5]*33)%256).",".(($bookings[$lessonIndex][5]*66)%256).",".(($bookings[$lessonIndex][5]*99)%256).");\" id=\"roomdefault_".$data['room_nr']."_".$starttimes[$i]."\"><span id=\"book_".$bookings[$lessonIndex][0]."\" style=\"color:rgb(".getContrastColor(($bookings[$lessonIndex][5]*33)%256,($bookings[$lessonIndex][5]*66)%256,($bookings[$lessonIndex][5]*99)%256).")\">".$bookings[$lessonIndex][3]." (".$bookings[$lessonIndex][4].")</span></div>";
        } else echo "<div class=\"dropables\" id=\"roomdefault_".$data['room_nr']."_".$starttimes[$i]."\">&nbsp;</div>";
        echo "</td>";
      }
      echo '</tr>';
    }
  }
  
  echo '<tr><th style="text-align:left;font-weight:900;border-right:solid 1px #bbb;cursor:pointer;" onclick="switchVisibility(\'labor\')"><img src="img/closed.gif" alt="'.getTranslation(527,$_GET['lang']).'" title="'.getTranslation(527,$_GET['lang']).'" id="icon_labor" /> '.getTranslation(516,$_GET['lang']).'</th><td colspan="'.$cnt_times.'" style="background:#eee;">&nbsp;</td></tr>';

  $rs = mysql_query("SELECT room_id,room_nr,room_name FROM room WHERE ".((!$SHOW_ROOMS_MULTIPLE)?"room_id NOT IN ('".implode("','",$usedrooms)."') AND ":"")." room_type>0".(($_GET['curriculum_ID'])?" AND room_seat>=(SELECT class_count FROM class WHERE class_id=(SELECT class_id FROM curriculum WHERE cur_id='".$_GET['curriculumID']."'))":"")." ORDER BY room_nr");
  while($data = mysql_fetch_assoc($rs)) {
    echo '<tr style="display:none;" class="labor"><td style="background:#DEF;color:#019;border-right:solid 1px #bbb;padding-left:23px;">'.$data['room_name'].' ('.$data['room_nr'].')</td>';
    $usedrooms[] = $data['room_id'];
    for($i=0;$i<$cnt_times;$i++) {
      $zeit = explode("_",$starttimes[$i]);
      $zeit = mktime($zeit[0],(int)($zeit[1]),0,date('n',$_GET['date']),date('j',$_GET['date']),date('Y',$_GET['date']));
      $lessonIndex = getLessonAtRoomAndTime($zeit,$data['room_nr'],$bookings);
      echo "<td style=\"border-right:solid 1px #bbb;text-align:center;\">";
      if($lessonIndex!==false) {
        echo "<div class=\"dropables draggable\" style=\"background:rgb(".(($bookings[$lessonIndex][5]*33)%256).",".(($bookings[$lessonIndex][5]*66)%256).",".(($bookings[$lessonIndex][5]*99)%256).");\" id=\"roomlabor_".$data['room_nr']."_".$starttimes[$i]."\"><span id=\"book_".$bookings[$lessonIndex][0]."\" style=\"color:rgb(".getContrastColor(($bookings[$lessonIndex][5]*33)%256,($bookings[$lessonIndex][5]*66)%256,($bookings[$lessonIndex][5]*99)%256).")\">".$bookings[$lessonIndex][3]." (".$bookings[$lessonIndex][4].")</span></div>";
      } else echo "<div class=\"dropables\" id=\"roomlabor_".$data['room_nr']."_".$starttimes[$i]."\">&nbsp;</div>";
      echo "</td>";
    }
    echo '</tr>';
  }
  
  echo '<tr><th style="text-align:left;font-weight:900;border-right:solid 1px #bbb;cursor:pointer;" onclick="switchVisibility(\'all\')"><img src="img/closed.gif" alt="'.getTranslation(528,$_GET['lang']).'" title="'.getTranslation(528,$_GET['lang']).'" id="icon_all" /> '.getTranslation(517,$_GET['lang']).'</th><td colspan="'.$cnt_times.'" style="background:#eee;">&nbsp;</td></tr>';

  $rs = mysql_query("SELECT room_id,room_nr,room_name FROM room WHERE ".((!$SHOW_ROOMS_MULTIPLE)?"room_id NOT IN ('".implode("','",$usedrooms)."') AND ":"")." ".(($_GET['curriculum_ID'])?"room_seat>=(SELECT class_count FROM class WHERE class_id=(SELECT class_id FROM curriculum WHERE cur_id='".$_GET['curriculumID']."'))":"1")." ORDER BY room_nr");
  while($data = mysql_fetch_assoc($rs)) {
    echo '<tr style="display:none;" class="all"><td style="background:#DEF;color:#019;border-right:solid 1px #bbb;padding-left:23px;">'.$data['room_name'].' ('.$data['room_nr'].')</td>';
    $usedrooms[] = $data['room_id'];
    for($i=0;$i<$cnt_times;$i++) {
      $zeit = explode("_",$starttimes[$i]);
      $zeit = mktime($zeit[0],(int)($zeit[1]),0,date('n',$_GET['date']),date('j',$_GET['date']),date('Y',$_GET['date']));
      $lessonIndex = getLessonAtRoomAndTime($zeit,$data['room_nr'],$bookings);
      echo "<td style=\"border-right:solid 1px #bbb;text-align:center;\">";
      if($lessonIndex!==false) {
        echo "<div class=\"dropables draggable\" style=\"background:rgb(".(($bookings[$lessonIndex][5]*33)%256).",".(($bookings[$lessonIndex][5]*66)%256).",".(($bookings[$lessonIndex][5]*99)%256).");\" id=\"roomall_".$data['room_nr']."_".$starttimes[$i]."\"><span id=\"book_".$bookings[$lessonIndex][0]."\" style=\"color:rgb(".getContrastColor(($bookings[$lessonIndex][5]*33)%256,($bookings[$lessonIndex][5]*66)%256,($bookings[$lessonIndex][5]*99)%256).")\">".$bookings[$lessonIndex][3]." (".$bookings[$lessonIndex][4].")</span></div>";
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
    if(droparea.innerHTML!="&nbsp;") return false;
    var bookID = draggable.firstChild.id.replace('book_','');
    var room = draggable.id.split("_");
    var old_room_nr = room[1];
    if(room[0].indexOf("duplicate")>-1) var isDuplicate = true;
    else var isDuplicate = false;
    var time = room[2]+"_"+room[3];
    var color = draggable.style.backgroundColor;
    var newroom = droparea.id.split("_");
    var new_room_nr = newroom[1];
    var newtime = newroom[2]+"_"+newroom[3];
    
    if(newtime!=time) return false;

    xajax_changeRoom(bookID,new_room_nr);
    
    var views = new Array();
    views[0] = "default";
    views[1] = "labor";
    views[2] = "all";
    
    var html = draggable.innerHTML;
    for(var i=0;i<views.length;i++) {
      // put lesson to new room
      if($('room'+views[i]+'_'+new_room_nr+'_'+time)) {
        $('room'+views[i]+'_'+new_room_nr+'_'+time).innerHTML = html;
        $('room'+views[i]+'_'+new_room_nr+'_'+time).style.background = color;
        $('room'+views[i]+'_'+new_room_nr+'_'+time).style.color = "rgb("+getContrast(color.substring(4,color.length-1))+")";
        $('room'+views[i]+'_'+new_room_nr+'_'+time).className = "dropables draggable";
        new Draggable( $('room'+views[i]+'_'+new_room_nr+'_'+time), {revert:true,constraint:'vertical' });
      }
      
      if(!isDuplicate && $('room'+views[i]+'_'+old_room_nr+'_'+time)) {
        // delete lesson from old room
        $('room'+views[i]+'_'+old_room_nr+'_'+time).innerHTML = '&nbsp;';
        $('room'+views[i]+'_'+old_room_nr+'_'+time).style.background = 'transparent';
        $('room'+views[i]+'_'+old_room_nr+'_'+time).className = "dropables";
      }
    }
    
    if(isDuplicate) {
      // delete lesson from old room
      $('roomduplicate_'+old_room_nr+'_'+time).innerHTML = '&nbsp;';
      $('roomduplicate_'+old_room_nr+'_'+time).style.background = 'transparent';
      $('roomduplicate_'+old_room_nr+'_'+time).className = "duplicate";
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

function checkForDuplicateRooms() {
  var duplicates = document.getElementsByClassName('duplicates');
  for(var i=0;i<duplicates.length;i++) {
    if(duplicates[i].innerHTML!="") {
      if(confirm("Es gibt noch Vorlesungen, denen kein Raum zugeordnet wurde. Wollen Sie die entsprechenden Vorlesungen l�schen?")) {
        
      } else {
        // Reload
        location.href = location.href;
      }
      return true;
    }
  }
}
</script>
<?php $xajax->printJavascript('lib/'); ?>
  </body>
</html>