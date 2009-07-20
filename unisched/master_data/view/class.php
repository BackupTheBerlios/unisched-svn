<?php

/**

  @defgroup v_class class v_class
  @brief library to present 'class' form
  @ingroup VIEW

  <pre>
  --------------------------------------------------------------------------------
  FILE-HISTORY
  --------------------------------------------------------------------------------
  Description
    provide 'class' form
  --------------------------------------------------------------------------------
  date        version   upload    who?      change description
  20.07.2008            no        it05mg1   created
  28.07.2008  1.0.0     yes       it05mg1   upload
  --------------------------------------------------------------------------------
  </pre>
*/


class v_class
{
  var $frame;
  var $language;
  var $lan;
  
  
  /**
      @brief    constructor (initiate frame and language class)
      @ingroup  v_class
      @param    $val array with all post-data
  */
  function v_class($val)
  {
    $this->lan_id = $val['lang'];

    $this->frame = new frame($val);
    $this->language = new language($this->lan_id);
  }









  /**
      @brief    generate data table
      @ingroup  v_class
      @param    $arDATA array with all data
      @param    $arFkField foreignkey values for selection list
      @param    $site contains current site parameter
      @param    $sErr saving exception message
      @param    $saved save status
      @return   HTML table
  */
  function v_class_getFormHtml($arDATA, $arFkField, $site, $sErr=null, $saved=null)
  {

    $sTab = "";
    for ($i=0; $i<count($arDATA); $i++)
    {
      // sub_typ
      $arSEL[$arDATA[$i]['CLASS_TYP']] = "selected";

      $sTab .= '
      <tr valign="top">
        <td>
          <div '.((isset($arDATA[$i]['ERR']['FIELD_ID'])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
            <input type="hidden" name="data[CLASS_ID][]" value="'.$arDATA[$i]['CLASS_ID'].'">
            '.$this->v_class_getSelectionList($arFkField, "FIELD_ID", "FIELD_NAME","data[FIELD_ID][]", $arDATA[$i]['FIELD_ID']).'
            '.((isset($arDATA[$i]['ERR']['FIELD_ID'])) ? "<br />".$arDATA[$i]['ERR']['FIELD_ID'] : "").'
          </div>
        </td>
        <td>
          <div '.((isset($arDATA[$i]['ERR']['CLASS_NAME'])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
            <input type="text" name="data[CLASS_NAME][]" value="'.htmlentities($arDATA[$i]['CLASS_NAME']).'" size="10" maxlength="10">
            '.((isset($arDATA[$i]['ERR']['CLASS_NAME'])) ? "<br />".$arDATA[$i]['ERR']['CLASS_NAME'] : "").'
          </div>
        </td>
        <td>
          <div '.((isset($arDATA[$i]['ERR']['CLASS_COUNT'])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
            <input type="text" name="data[CLASS_COUNT][]" value="'.$arDATA[$i]['CLASS_COUNT'].'" size="5" maxlength="3">
            '.((isset($arDATA[$i]['ERR']['CLASS_COUNT'])) ? "<br />".$arDATA[$i]['ERR']['CLASS_COUNT'] : "").'
          </div>
        </td>
        <td>
         <div '.((isset($arDATA[$i]['ERR']['CLASS_TYP'])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
            <select name="data[CLASS_TYP][]">
              <option value="1" '.$arSEL[1].'>'.$this->language->language_getLabel(36).'</option>
              <option value="2" '.$arSEL[2].'>'.$this->language->language_getLabel(37).'</option>
            </select>
            '.((isset($arDATA[$i]['ERR']['CLASS_TYP'])) ? "<br />".$arDATA[$i]['ERR']['CLASS_TYP'] : "").'
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
        <th>'.$this->language->language_getLabel(1).'*</th>
        <th>'.$this->language->language_getLabel(5).'*</th>
        <th>'.$this->language->language_getLabel(35).'</th>
        <th>'.$this->language->language_getLabel(20).'*</th>
        <th></th>
      </tr>
      <tr style="display:none" id="trVorlage">
        <td>
          <input type="hidden" name="data[CLASS_ID][]" value="-9999">
          '.$this->v_class_getSelectionList($arFkField, "FIELD_ID", "FIELD_NAME","data[FIELD_ID][]").'
        </td>
        <td><input type="text" name="data[CLASS_NAME][]" value="" size="10" maxlength="10"></td>
        <td><input type="text" name="data[CLASS_COUNT][]" value="" size="5" maxlength="3"></td>
        <td>
          <select name="data[CLASS_TYP][]">
            <option value="1">'.$this->language->language_getLabel(36).'</option>
            <option value="2">'.$this->language->language_getLabel(37).'</option>
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
      @ingroup  v_class
      @param    $sMain contains content that should shown in the main area of the application (data table)
      @return HTML site
  */
  function v_class_generate_site($sMain)
  {
    $sHeadline = $this->language->language_getLabel(12);
    return $this->frame->frame_getFrame($sHeadline, $sMain, $this->lan_id);
  }
  
  
  
  
  
  
  
  
  
  /**
      @brief    generate a selection list
      @ingroup  v_class
      @param    $ar             array with data
      @param    $value_column   column in the array for the value-tag
      @param    $show_column    column in the array
      @param    $list_name      name of the list
      @param    $selected_value preselected value
      @return HTML selection list
  */
  function v_class_getSelectionList($ar, $value_column, $show_column, $list_name, $selected_value=null)
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