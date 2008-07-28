<?php

/**

  @defgroup v_defaultroom class v_defaultroom
  @brief library to present 'defaultroom' form
  @ingroup VIEW

  <pre>
  --------------------------------------------------------------------------------
  FILE-HISTORY
  --------------------------------------------------------------------------------
  Description
    provide 'defaultroom' form
  --------------------------------------------------------------------------------
  date        version   upload    who?      change description
  10.07.2008            no        it05mg1   created
  --------------------------------------------------------------------------------
  </pre>
*/


class v_defaultroom
{
  var $frame;
  var $language;
  var $lan_id;
  
  
  /**
      @brief    constructor (initiate frame and language class)
      @ingroup  v_defaultroom
      @param    $lan_id current language
  */
  function v_defaultroom($val)
  {
    $this->lan_id = $val['lang'];

    $this->frame = new frame($val);
    $this->language = new language($this->lan_id);
  }









  /**
      @brief    generate data table
      @ingroup  v_defaultroom
      @param    $arDATA array with all data
      @param    $site contains current site parameter
      @param    $state which page should show (1 -> classes; 2 -> add rooms)
      @param    $arFk array with 'room'-data
      @return   HTML table
  */
  function v_defaultroom_getFormHtml($arDATA, $site, $state, $CLASS_ID=null, $arFK=null, $sErr=null, $saved=null)
  {
    if ($state == 1)
    {
      $sTab = "";
      for ($i=0; $i<count($arDATA); $i++)
      {
        $sTab .= '<tr valign="top">
          <td>
            '.htmlentities($arDATA[$i]['CLASS_NAME']).'
          </td>
          <td align="center">
            <a href="index.php?site='.$site.'&lang='.$this->lan_id.'&CLASS_ID='.$arDATA[$i]['CLASS_ID'].'&do=show_class"><img src="../img/edit.gif" border="0"></a>
          </td>
        </tr>';
      }

      return (($sTab=="") ? '>>> <b>'.$this->language->language_getLabel(55).' <<<' : "").'
      <table>
        <tr>
          <th>'.$this->language->language_getLabel(12).'</th>
          <th>'.$this->language->language_getLabel(44).'</th>
        </tr>
        '.$sTab.'
      </table>';
    } else if ($state == 2)
    {
      $sTab = "";
      for ($i=0; $i<count($arDATA); $i++)
      {
        // sub_typ
        $arSEL[$arDATA[$i]['priority']] = "selected";

        $sTab .= '
        <tr valign="top">
          <td>
           <div '.((isset($arDATA[$i]['ERR']['PRIORITY'])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
              <select name="data[PRIORITY][]">
                <option value="1" '.$arSEL[1].'>'.$this->language->language_getLabel(48).'</option>
                <option value="2" '.$arSEL[2].'>'.$this->language->language_getLabel(49).'</option>
                <option value="3" '.$arSEL[3].'>'.$this->language->language_getLabel(50).'</option>
                <option value="4" '.$arSEL[4].'>'.$this->language->language_getLabel(51).'</option>
                <option value="5" '.$arSEL[5].'>'.$this->language->language_getLabel(52).'</option>
              </select>
              '.((isset($arDATA[$i]['ERR']['PRIORITY'])) ? "<br />".$arDATA[$i]['ERR']['PRIORITY'] : "").'
            </div>
          </td>
          <td>
            <div '.((isset($arDATA[$i]['ERR']['ROOM_ID'])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
              '.$this->v_defaultroom_getSelectionList($arFK, "ROOM_ID", "ROOM_NR","data[ROOM_ID][]", $arDATA[$i]['ROOM_ID']).'
              '.((isset($arDATA[$i]['ERR']['ROOM_ID'])) ? "<br />".$arDATA[$i]['ERR']['ROOM_ID'] : "").'
            </div>
          </td>
          <td><a href="#" onClick="if (confirm(\''.$this->language->language_getLabel(2).'\')) this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode); return false;"><img src="img/delete_icon.gif" border="0"></a></td>
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
      <input type="hidden" name="CLASS_ID" value="'.$CLASS_ID.'">
      <table id="table">
        <tr>
          <th>'.$this->language->language_getLabel(54).'* (<a href="index.php?site=0&lang='.$this->lan_id.'#defaultroom_priority" target="_blank">?</a>)</th>
          <th>'.$this->language->language_getLabel(53).'*</th>
          <th></th>
        </tr>
        <tr style="display:none" id="trVorlage">
          <td>
              <select name="data[PRIORITY][]">
                <option value="5">'.$this->language->language_getLabel(48).'</option>
                <option value="4">'.$this->language->language_getLabel(49).'</option>
                <option value="3" selected>'.$this->language->language_getLabel(50).'</option>
                <option value="2">'.$this->language->language_getLabel(51).'</option>
                <option value="1">'.$this->language->language_getLabel(52).'</option>
              </select>
          </td>
          <td>
            '.$this->v_defaultroom_getSelectionList($arFK, "ROOM_ID", "ROOM_NR","data[ROOM_ID][]").'
          </td>
          <td><a href="#" onClick="if (confirm(\''.$this->language->language_getLabel(2).'\')) this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode); return false;"><img src="img/delete_icon.gif" border="0"></a></td>
        </tr>
        '.$sTab.'
        <tr id="trLast">
          <td colspan="2"></td>
          <td><a href onClick="var objDS = document.getElementById(\'trVorlage\').parentNode.insertBefore(document.getElementById(\'trVorlage\').cloneNode(true),document.getElementById(\'trLast\')); objDS.style.display = \'\'; objDS.id=\'\'; return false;"><img src="img/icon_add.gif" border="0"></a></td>
        </tr>
        <tr><td colspan="5" align="center">
          <input type="submit" value="'.$this->language->language_getLabel(4).'" >
          <input type="submit" onClick="document.getElementsByName(\'do\')[0].value=\'\'; document.submit(); return false;" value="'.$this->language->language_getLabel(67).'" >
        </td></tr>
      </table>
      </form>';
    }
    
  }
  
  







  /**
      @brief    get whole HTML site
      @ingroup  v_defaultroom
      @param    $sMain contains content that should shown in the main area of the application (data table)
      @param    $sCLASS_NAME  class name
      @return HTML site
  */
  function v_defaultroom_generate_site($sMain, $sCLASS_NAME)
  {
    $sHeadline = $this->language->language_getLabel(30).(($sCLASS_NAME != "") ? " '".$sCLASS_NAME."'" : "");
    return $this->frame->frame_getFrame($sHeadline, $sMain, $this->lan_id);
  }
  
  
  
  
  
  
  
  
  
  /**
      @brief    generate a selection list
      @ingroup  v_defaultroom
      @param    $ar             array with data
      @param    $value_column   column in the array for the value-tag
      @param    $show_column    column in the array
      @param    $list_name      name of the list
      @param    $selected_value preselected value
      @return HTML selection list
  */
  function v_defaultroom_getSelectionList($ar, $value_column, $show_column, $list_name, $selected_value=null)
  {
    $sList = "";
    for ($i=0; $i<count($ar); $i++)
    {
      $sList .= '<option value="'.$ar[$i][$value_column].'" '.(($ar[$i][$value_column]==$selected_value) ? "selected" : "").'>'.$ar[$i][$show_column].'</option>
      ';
    }

    return '
    <select name="'.$list_name.'">
      '.$sList.'
    </select>';
  }
}
?>