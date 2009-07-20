<?php

/**

  @defgroup v_room class v_room
  @brief library to present 'room' form
  @ingroup VIEW

  <pre>
  --------------------------------------------------------------------------------
  FILE-HISTORY
  --------------------------------------------------------------------------------
  Description
    provide 'room' form
  --------------------------------------------------------------------------------
  date        version   upload    who?      change description
  20.07.2008            no        it05mg1   created
  28.07.2008  1.0.0     yes       it05mg1   upload
  --------------------------------------------------------------------------------
  </pre>
*/


class v_room
{
  var $frame;
  var $language;
  var $lan_id;
  
  
  /**
      @brief    constructor (initiate frame and language class)
      @ingroup  v_room
      @param    $val array with all post-data
  */
  function v_room($val)
  {
    $this->lan_id = $val['lang'];

    $this->frame = new frame($val);
    $this->language = new language($this->lan_id);
  }









  /**
      @brief    generate data table
      @ingroup  v_room
      @param    $arDATA array with all data
      @param    $site contains current site parameter
      @param    $sErr saving exception message
      @param    $saved save status
      @return   HTML table
  */
  function v_room_getFormHtml($arDATA, $site, $sErr=null, $saved=null)
  {

    $sTab = "";
    for ($i=0; $i<count($arDATA); $i++)
    {
      $arSEL[$arDATA[$i]['room_type']] = "selected";
    
      $sTab .= '
      <tr valign="top">
        <td>
          <div '.((isset($arDATA[$i]['ERR']['ROOM_NR'])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
            <input type="hidden" name="data[ROOM_ID][]" value="'.$arDATA[$i]['ROOM_ID'].'">
            <input type="text" name="data[ROOM_NR][]" value="'.htmlentities($arDATA[$i]['ROOM_NR']).'" size="5" maxlength="5">
            '.((isset($arDATA[$i]['ERR']['ROOM_NR'])) ? "<br />".$arDATA[$i]['ERR']['ROOM_NR'] : "").'
          </div>
        </td>
        <td>
          <div '.((isset($arDATA[$i]['ERR']['ROOM_NAME'])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
            <input type="text" name="data[ROOM_NAME][]" value="'.htmlentities($arDATA[$i]['ROOM_NAME']).'" size="30" maxlength="30">
            '.((isset($arDATA[$i]['ERR']['ROOM_NAME'])) ? "<br />".$arDATA[$i]['ERR']['ROOM_NAME'] : "").'
          </div>
        </td>
        <td>
          <div '.((isset($arDATA[$i]['ERR']['ROOM_SEAT'])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
            <input type="text" name="data[ROOM_SEAT][]" value="'.htmlentities($arDATA[$i]['ROOM_SEAT']).'" size="5" maxlength="3">
            '.((isset($arDATA[$i]['ERR']['ROOM_SEAT'])) ? "<br />".$arDATA[$i]['ERR']['ROOM_SEAT'] : "").'
          </div>
        </td>
        <td>
          <div '.((isset($arDATA[$i]['ERR']['ROOM_TYPE'])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
            <select name="data[ROOM_TYPE][]">
              <option value="0" '.$arSEL[0].'>'.$this->language->language_getLabel(59).'</option>
              <option value="1" '.$arSEL[1].'>'.$this->language->language_getLabel(60).'</option>
            </select>
            '.((isset($arDATA[$i]['ERR']['ROOM_TYPE'])) ? "<br />".$arDATA[$i]['ERR']['ROOM_TYPE'] : "").'
          </div>
        </td>
        <td><a href="#" onClick="if (confirm(\''.$this->language->language_getLabel(2).'\')) this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode); return false;"><img src="../img/delete_icon.gif" border="0"></a></td>
      </tr>';

      unset($arSEL);
    }

    // message
    if ($saved=="save")
    {
      if ($sErr != "") {$sMsg = '<font color="#ff0000"><b>'.$sErr.'</b></font>';} else {$sMsg = '<font color="#00ff00"><b>'.$this->language->language_getLabel(10).'</b></font>';}
    }

    return $sMsg.'
    <form action="index.php" method="post">
    <input type="hidden" name="site" value="'.$site.'">
    <input type="hidden" name="lang" value="'.$this->lan_id.'">

    <input type="hidden" name="do" value="save">
    <table id="table">
      <tr>
        <th>'.$this->language->language_getLabel(31).'*</th>
        <th>'.$this->language->language_getLabel(5).'</th>
        <th>'.$this->language->language_getLabel(32).'</th>
        <th>'.$this->language->language_getLabel(20).'*</th>
        <th></th>
      </tr>
      <tr style="display:none" id="trVorlage">
        <td><input type="hidden" name="data[ROOM_ID][]" value="-9999"><input type="text" name="data[ROOM_NR][]" value="" size="5" maxlength="3"></td>
        <td><input type="text" name="data[ROOM_NAME][]" value="" size="30" maxlength="30"></td>
        <td><input type="text" name="data[ROOM_SEAT][]" value="" size="5" maxlength="3"></td>
        <td>
          <select name="data[ROOM_TYPE][]">
            <option value="0">'.$this->language->language_getLabel(59).'</option>
            <option value="1">'.$this->language->language_getLabel(60).'</option>
          </select>
        </td>
        <td><a href="#" onClick="if (confirm(\''.$this->language->language_getLabel(2).'\')) this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode); return false;"><img src="../img/delete_icon.gif" border="0"></a></td>
      </tr>
      '.$sTab.'
      <tr id="trLast">
        <td colspan="4"></td>
        <td><a href onClick="var objDS = document.getElementById(\'trVorlage\').parentNode.insertBefore(document.getElementById(\'trVorlage\').cloneNode(true),document.getElementById(\'trLast\')); objDS.style.display = \'\'; objDS.id=\'\'; return false;"><img src="../img/icon_add.gif" border="0"></a></td>
      </tr>
      <tr><td colspan="5" align="center">
        <input type="submit" value="'.$this->language->language_getLabel(4).'" >
      </td></tr>
    </table>
    </form>';
  }
  
  







  /**
      @brief    get whole HTML site
      @ingroup  v_room
      @param    $sMain contains content that should shown in the main area of the application (data table)
      @return HTML site
  */
  function v_room_generate_site($sMain)
  {
    $sHeadline = $this->language->language_getLabel(33);
    return $this->frame->frame_getFrame($sHeadline, $sMain, $this->lan_id);
  }
}
?>