<?php

/**

  @defgroup v_cur_class class v_cur_class
  @brief library to present the curriculum of one 'class' form
  @ingroup VIEW

  <pre>
  --------------------------------------------------------------------------------
  FILE-HISTORY
  --------------------------------------------------------------------------------
  Description
    provide 'cur_class' form
  --------------------------------------------------------------------------------
  date        version   upload    who?      change description
  10.07.2008            no        it05mg1   created
  --------------------------------------------------------------------------------
  </pre>
*/


class v_cur_class
{
  var $frame;
  var $language;
  var $lan_id;
  
  
  /**
      @brief    constructor (initiate frame and language class)
      @ingroup  v_cur_class
      @param    $lan_id current language
  */
  function v_cur_class($val)
  {
    $this->lan_id = $val['lang'];

    $this->frame = new frame($val);
    $this->language = new language($this->lan_id);
  }









  /**
      @brief    generate data table
      @ingroup  v_cur_class
      @param    $arDATA array with all data
      @param    $site contains current site parameter
      @return   HTML table
  */
  function v_cur_class_getFormHtml($arPERIOD, $arCUR, $arFkSub, $arFkLec, $site, $CLASS_ID, $sErr, $saved)
  {
    $sTab = "";
    // class period
    for ($i=0; $i<count($arPERIOD); $i++)
    {
      $arDateBegin = explode("-", $arPERIOD[$i]['CLASS_PERIOD_BEGIN']);
      $arDateEnd = explode("-", $arPERIOD[$i]['CLASS_PERIOD_END']);
    
      $sTab .= '<tr style="display:none" id="trVorlage_'.$arPERIOD[$i]['CLASS_PERIOD_ID'].'">
        <td>
          <input type="hidden" name="data[CUR_ID][]" value="">
          <input type="hidden" name="data[CLASS_PERIOD_ID][]" value="'.$arPERIOD[$i]['CLASS_PERIOD_ID'].'">
          '.$this->v_class_getSelectionListSub($arFkSub, "data[SUB_ID][]").'
        </td>
        <td align="center"><input type="text" name="data[CUR_CNT_SUB][]" value="'.$arCUR[$cur]['CUR_CNT_SUB'].'" size="3" maxlength="3"></td>
         <td>'.$this->v_class_getSelectionListLec($arFkLec, "data[LEC_ID][]").'</td>
        <td><a href="#" onClick="if (confirm(\''.$this->language->language_getLabel(2).'\')) this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode); return false;"><img src="img/delete_icon.gif" border="0"></a></td>
      </tr>
      <tr valign="top">
        <td align="center" colspan="3">
          <font size="-1">
          <b>
            - '.$arDateBegin[2].'.'.$arDateBegin[1].'.'.$arDateBegin[0].' bis '.$arDateEnd[2].'.'.$arDateEnd[1].'.'.$arDateEnd[0].' -
            '.(($arPERIOD[$i]['CLASS_PERIOD_TYP']==1) ? $this->language->language_getLabel(40) : $this->language->language_getLabel(41)).' -
          </b>
          </font>
        </td>
      </tr>
      <tr>
        <th>'.$this->language->language_getLabel(56).'*</th>
        <th>'.$this->language->language_getLabel(57).'*  (<a href="index.php?site=0&lang='.$this->lan_id.'#curriculum" target="_blank">?</a>)</th>
        <th>'.$this->language->language_getLabel(21).'*</th>
        <th></th>
      </tr>';
      
      for ($cur=0; $cur<count($arCUR); $cur++)
      {
        if ($arPERIOD[$i]['CLASS_PERIOD_ID'] == $arCUR[$cur]['CLASS_PERIOD_ID'])
        {
          $sTab .= '<tr valign="top">
            <td>
              <input type="hidden" name="data[CUR_ID][]" value="'.$arCUR[$cur]['CUR_ID'].'">
              <input type="hidden" name="data[CLASS_PERIOD_ID][]" value="'.$arPERIOD[$i]['CLASS_PERIOD_ID'].'">

              <div '.((isset($arCUR[$cur]['ERR']['SUB_ID'])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
                '.$this->v_class_getSelectionListSub($arFkSub, "data[SUB_ID][]", $arCUR[$cur]['SUB_ID']).'
                '.((isset($arCUR[$cur]['ERR']['SUB_ID'])) ? "<br />".$arCUR[$cur]['ERR']['SUB_ID'] : "").'
              </div>
            </td>
            <td align="center">
              <div '.((isset($arCUR[$cur]['ERR']['CUR_CNT_SUB'])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
                <input type="text" name="data[CUR_CNT_SUB][]" value="'.$arCUR[$cur]['CUR_CNT_SUB'].'" size="3" maxlength="3">
                '.((isset($arCUR[$cur]['ERR']['CUR_CNT_SUB'])) ? "<br />".$arCUR[$cur]['ERR']['CUR_CNT_SUB'] : "").'
              </div>
            <td>
              <div '.((isset($arCUR[$cur]['ERR']['LEC_ID'])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
              '.$this->v_class_getSelectionListLec($arFkLec, "data[LEC_ID][]", $arCUR[$cur]['lec_id']).'
                '.((isset($arCUR[$cur]['ERR']['LEC_ID'])) ? "<br />".$arCUR[$cur]['ERR']['LEC_ID'] : "").'
              </div>
            </td>
            <td align="center"><a href="#" onClick="if (confirm(\''.$this->language->language_getLabel(2).'\')) this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode); return false;"><img src="img/delete_icon.gif" border="0"></a></td>
          </tr>';
        }
      }
      
      $sTab .= '<tr>
        <td colspan="3"></td>
        <td align="center"><a href="#" onClick="var objDS = document.getElementById(\'trVorlage_'.$arPERIOD[$i]['CLASS_PERIOD_ID'].'\').parentNode.insertBefore(document.getElementById(\'trVorlage_'.$arPERIOD[$i]['CLASS_PERIOD_ID'].'\').cloneNode(true),this.parentNode.parentNode); objDS.style.display = \'\'; objDS.id=\'\'; objDS.getElementsByTagName(\'input\')[0].value=-9999; return false;"><img src="img/icon_add.gif" border="0"></a></td>
      </tr>
      ';
    }

    // message
    if ($saved=="save")
    {
      if ($sErr != "") {$sMsg = '<font color="#ff0000"><b>'.$sErr.'</b></font>';} else {$sMsg = '<font color="#00ff00"><b>'.$this->language->language_getLabel(10).'</b></font>';}
    }

    if ($sTab=="")
    {
      return '>>> <b>'.$this->language->language_getLabel(58).' <<<';
    } else
    {

      return $sMsg.'
      <form action="index.php" method="post">
      <input type="hidden" name="site" value="'.$site.'">
      <input type="hidden" name="lang" value="'.$this->lan_id.'"
      <input type="hidden" name="CLASS_ID" value="'.$CLASS_ID.'">
      <input type="hidden" name="do" value="save">
      <table>
        '.$sTab.'
        <tr><td align="center" colspan="4"><input type="submit" value="'.$this->language->language_getLabel(4).'" ></td></tr>
      </table>
      </form>';
    }
  }
  
  







  /**
      @brief    get whole HTML site
      @ingroup  v_cur_class
      @param    $sMain contains content that should shown in the main area of the application (data table)
      @return HTML site
  */
  function v_cur_class_generate_site($sMain, $CLASS_NAME)
  {
    $sHeadline = $this->language->language_getLabel(22)." '".$CLASS_NAME."'";
    return $this->frame->frame_getFrame($sHeadline, $sMain, $this->lan_id);
  }
  
  
  
  
  
  
  
  
  
  /**
      @brief    generate a selection list
      @ingroup  v_cur_class
      @param    $ar             array with data
      @param    $list_name      name of the list
      @param    $selected_value preselected value
      @return HTML selection list
  */
  function v_class_getSelectionListLec($ar, $list_name, $selected_value=null)
  {
    $sList = "";
    for ($i=0; $i<count($ar); $i++)
    {
      $sList .= '<option value="'.$ar[$i]['LEC_ID'].'" '.(($ar[$i]['LEC_ID']==$selected_value) ? "selected" : "").'>'.$ar[$i]['LEC_TIT'].' '.$ar[$i]['LEC_LNAME'].'</option>
      ';
    }

    return '
    <select name="'.$list_name.'">
      '.$sList.'
    </select>';
  }
  
  
  
  
  
  
  
  
  
  /**
      @brief    generate a selection list
      @ingroup  v_cur_class
      @param    $ar             array with data
      @param    $list_name      name of the list
      @param    $selected_value preselected value
      @return HTML selection list
  */
  function v_class_getSelectionListSub($ar, $list_name, $selected_value=null)
  {
    $sList = "";
    for ($i=0; $i<count($ar); $i++)
    {
      // option value
      $sOptionValue = "";
      if ($ar[$i]['MOD_ID'] != "") {$sOptionValue = $this->language->language_getLabel(26);} else {$sOptionValue = $this->language->language_getLabel(17);}
      if  ($ar[$i]['SUB_TYP'] == 2) {$sOptionValue .= " - ".$this->language->language_getLabel(18); }
      $sOptionValue = $ar[$i]['SUB_NAME']." (".$sOptionValue.")";

      // option tag
      $sList .= '<option value="'.$ar[$i]["SUB_ID"].'" '.(($ar[$i]['SUB_ID']==$selected_value) ? "selected" : "").'>
        '.$sOptionValue.'
      </option>
      ';
    }

    return '
    <select name="'.$list_name.'">
      '.$sList.'
    </select>';
  }
}
?>