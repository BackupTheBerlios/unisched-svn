<?php

/**

  @defgroup v_class_period class v_class_period
  @brief library to present 'class_period' form
  @ingroup VIEW

  <pre>
  --------------------------------------------------------------------------------
  FILE-HISTORY
  --------------------------------------------------------------------------------
  Description
    provide 'class_period' form
  --------------------------------------------------------------------------------
  date        version   upload    who?      change description
  20.07.2008            no        it05mg1   created
  --------------------------------------------------------------------------------
  </pre>
*/


class v_class_period
{
  var $frame;
  var $language;
  var $lan_id;
  
  
  /**
      @brief    constructor (initiate frame and language class)
      @ingroup  v_class_period
      @param    $lan_id current language
  */
  function v_class_period($val)
  {
    $this->lan_id = $val['lang'];

    $this->frame = new frame($val);
    $this->language = new language($this->lan_id);

  }









  /**
      @brief    generate data table
      @ingroup  v_class_period
      @param    $arDATA array with all data
      @param    $arFkClass foreignkey values for selection list
      @param    $site contains current site parameter
      @param    $sErr saving exception message
      @return   HTML table
  */
  function v_class_period_getFormHtml($arDATA, $site, $state, $arFkClass=null, $CLASS_ID=null, $sErr=null, $saved=null)
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
        // typ and term
        $arSelTyp[$arDATA[$i]['CLASS_PERIOD_TYP']] = "selected";
        $arSelTerm[$arDATA[$i]['TERM_ID']] = "selected";

        // date
        $arDateBegin = explode("-", $arDATA[$i]['CLASS_PERIOD_BEGIN']);
        $arDateEnd = explode("-", $arDATA[$i]['CLASS_PERIOD_END']);

        $sTab .= '
        <tr valign="top">
          <td>
           <input type="hidden" name="data[CLASS_PERIOD_ID][]" value="'.$arDATA[$i]['CLASS_PERIOD_ID'].'">
           <div '.((isset($arDATA[$i]['ERR']['TERM_ID'])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
              <select name="data[TERM_ID][]">
                <option value="1" '.$arSelTerm[1].'>1. '.$this->language->language_getLabel(39).'</option>
                <option value="2" '.$arSelTerm[2].'>2. '.$this->language->language_getLabel(39).'</option>
                <option value="3" '.$arSelTerm[3].'>3. '.$this->language->language_getLabel(39).'</option>
                <option value="4" '.$arSelTerm[4].'>4. '.$this->language->language_getLabel(39).'</option>
                <option value="5" '.$arSelTerm[5].'>5. '.$this->language->language_getLabel(39).'</option>
                <option value="6" '.$arSelTerm[6].'>6. '.$this->language->language_getLabel(39).'</option>
              </select>
              '.((isset($arDATA[$i]['ERR']['TERM_ID'])) ? "<br />".$arDATA[$i]['ERR']['TERM_ID'] : "").'
              |
            </div>
          </td>
          <td>
            <div '.((isset($arDATA[$i]['ERR']['CLASS_PERIOD_BEGIN'])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
              <input type="text" name="data[CLASS_PERIOD_BEGIN][TAG][]" value="'.$arDateBegin[2].'" size="1" maxlength="2">
              <input type="text" name="data[CLASS_PERIOD_BEGIN][MONAT][]" value="'.$arDateBegin[1].'" size="1" maxlength="2">
              <input type="text" name="data[CLASS_PERIOD_BEGIN][JAHR][]" value="'.$arDateBegin[0].'" size="2" maxlength="4">
              '.((isset($arDATA[$i]['ERR']['CLASS_PERIOD_BEGIN'])) ? "<br />".$arDATA[$i]['ERR']['CLASS_PERIOD_BEGIN'] : "").'
              |
            </div>
          </td>
          <td>
            <div '.((isset($arDATA[$i]['ERR']['CLASS_PERIOD_END'])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
              <input type="text" name="data[CLASS_PERIOD_END][TAG][]" value="'.$arDateEnd[2].'" size="1" maxlength="2">
              <input type="text" name="data[CLASS_PERIOD_END][MONAT][]" value="'.$arDateEnd[1].'" size="1" maxlength="2">
              <input type="text" name="data[CLASS_PERIOD_END][JAHR][]" value="'.$arDateEnd[0].'" size="2" maxlength="4">
              '.((isset($arDATA[$i]['ERR']['CLASS_PERIOD_END'])) ? "<br />".$arDATA[$i]['ERR']['CLASS_PERIOD_END'] : "").'
              |
            </div>
          </td>
          <td>
           <div '.((isset($arDATA[$i]['ERR']['CLASS_PERIOD_TYP'])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
              <select name="data[CLASS_PERIOD_TYP][]">
                <option value="0" '.$arSelTyp[0].'>'.$this->language->language_getLabel(40).'</option>
                <option value="1" '.$arSelTyp[1].'>'.$this->language->language_getLabel(41).'</option>
              </select>
              '.((isset($arDATA[$i]['ERR']['CLASS_PERIOD_TYP'])) ? "<br />".$arDATA[$i]['ERR']['CLASS_PERIOD_TYP'] : "").'
            </div>
          </td>
          <td><a href="#" onClick="if (confirm(\''.$this->language->language_getLabel(2).'\')) this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode); return false;"><img src="img/delete_icon.gif" border="0"></a></td>
        </tr>';

        unset($arSelTerm);
        unset($arSelTyp);
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
          <th>'.$this->language->language_getLabel(39).'*</th>
          <th>'.$this->language->language_getLabel(42).'*</th>
          <th>'.$this->language->language_getLabel(43).'*</th>
          <th>'.$this->language->language_getLabel(20).'*</th>
          <th></th>
        </tr>
        <tr style="display:none" id="trVorlage">
          <td>
            <input type="hidden" name="data[CLASS_PERIOD_ID][]" value="-9999">
            <select name="data[TERM_ID][]">
              <option value="1">1. '.$this->language->language_getLabel(39).'</option>
              <option value="2">2. '.$this->language->language_getLabel(39).'</option>
              <option value="3">3. '.$this->language->language_getLabel(39).'</option>
              <option value="4">4. '.$this->language->language_getLabel(39).'</option>
              <option value="5">5. '.$this->language->language_getLabel(39).'</option>
              <option value="6">6. '.$this->language->language_getLabel(39).'</option>
            </select>
            |
          </td>
          <td>
            <input type="text" name="data[CLASS_PERIOD_BEGIN][TAG][]" value="" size="1" maxlength="2">
            <input type="text" name="data[CLASS_PERIOD_BEGIN][MONAT][]" value="" size="1" maxlength="2">
            <input type="text" name="data[CLASS_PERIOD_BEGIN][JAHR][]" value="" size="2" maxlength="4">
            |
          </td>
          <td>
            <input type="text" name="data[CLASS_PERIOD_END][TAG][]" value="" size="1" maxlength="2">
            <input type="text" name="data[CLASS_PERIOD_END][MONAT][]" value="" size="1" maxlength="2">
            <input type="text" name="data[CLASS_PERIOD_END][JAHR][]" value="" size="2" maxlength="4">
            |
          </td>
          <td>
            <select name="data[CLASS_PERIOD_TYP][]">
              <option value="0">'.$this->language->language_getLabel(40).'</option>
              <option value="1">'.$this->language->language_getLabel(41).'</option>
            </select>
          </td>
          <td><a href="#" onClick="if (confirm(\''.$this->language->language_getLabel(2).'\')) this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode); return false;"><img src="img/delete_icon.gif" border="0"></a></td>
        </tr>
        '.$sTab.'
        <tr id="trLast">
          <td colspan="4"></td>
          <td><a href onClick="var objDS = document.getElementById(\'trVorlage\').parentNode.insertBefore(document.getElementById(\'trVorlage\').cloneNode(true),document.getElementById(\'trLast\')); objDS.style.display = \'\'; objDS.id=\'\'; return false;"><img src="img/icon_add.gif" border="0"></a></td>
        </tr>
        <tr><td colspan="6" align="center">
          <input type="submit" value="'.$this->language->language_getLabel(4).'" >
          <input type="submit" onClick="document.getElementsByName(\'do\')[0].value=\'\'; document.submit(); return false;" value="'.$this->language->language_getLabel(67).'" >
        </td></tr>
      </table>
      </form>';
    }
  }
  
  







  /**
      @brief    get whole HTML site
      @ingroup  v_class_period
      @param    $sMain contains content that should shown in the main area of the application (data table)
      @return HTML site
  */
  function v_class_period_generate_site($sMain, $sCLASS_NAME)
  {
    $sHeadline = $this->language->language_getLabel(34).(($sCLASS_NAME != "") ? " '".$sCLASS_NAME."'" : "");
    return $this->frame->frame_getFrame($sHeadline, $sMain, $this->lan_id);
  }
  
  
  
  
  
  
  
  
  
  /**
      @brief    generate a selection list
      @ingroup  v_class_period
      @param    $ar             array with data
      @param    $value_column   column in the array for the value-tag
      @param    $show_column    column in the array
      @param    $list_name      name of the list
      @param    $selected_value preselected value
      @return HTML selection list
  */
  function v_class_period_getSelectionList($ar, $value_column, $show_column, $list_name, $selected_value=null)
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