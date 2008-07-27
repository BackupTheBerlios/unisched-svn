<?php

/**

  @defgroup v_subject class v_subject
  @brief library to present 'subject' form
  @ingroup VIEW

  <pre>
  --------------------------------------------------------------------------------
  FILE-HISTORY
  --------------------------------------------------------------------------------
  Description
    provide 'subject' form
  --------------------------------------------------------------------------------
  date        version   upload    who?      change description
  18.07.2008            no        it05mg1   created
  --------------------------------------------------------------------------------
  </pre>
*/


class v_subject
{
  var $frame;
  var $language;
  var $lan_id;
  
  
  /**
      @brief    constructor (initiate frame and language class)
      @ingroup  v_subject
      @param    $lan_id current language
  */
  function v_subject($val)
  {
    $this->lan_id = $val['lang'];

    $this->frame = new frame($val);
    $this->language = new language($this->lan_id);
  }









  /**
      @brief    generate data table
      @ingroup  v_subject
      @param    $arDATA array with all data (lectures and examination
      @param    $arMOD data for moduls
      @param    $site contains current site parameter
      @param    $sErr saving exception message
      @return   HTML table
  */
  function v_subject_getFormHtml($arDATA, $arMOD, $site, $sErr=null, $saved=null)
  {
    $sTab = "";
    for ($i=0; $i<count($arDATA); $i++)
    {
      // sub_typ
      $arSEL[$arDATA[$i]['SUB_TYP']] = "selected";

      $sTab .= '
      <tr valign="top">
        <td>
          <div '.((isset($arDATA[$i]['ERR']['SUB_NAME'])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
            <input type="hidden" name="data[SUB_ID][]" value="'.$arDATA[$i]['SUB_ID'].'">
            <input type="text" name="data[SUB_NAME][]" value="'.htmlentities($arDATA[$i]['SUB_NAME']).'" size="8" maxlength="8">
            '.((isset($arDATA[$i]['ERR']['SUB_NAME'])) ? "<br />".$arDATA[$i]['ERR']['SUB_NAME'] : "").'
          </div>
        </td>
        <td>
          <div '.((isset($arDATA[$i]['ERR']['SUB_LONG_NAME'])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
            <input type="text" name="data[SUB_LONG_NAME][]" value="'.htmlentities($arDATA[$i]['SUB_LONG_NAME']).'" size="30" maxlength="30">
            '.((isset($arDATA[$i]['ERR']['SUB_LONG_NAME'])) ? "<br />".$arDATA[$i]['ERR']['SUB_LONG_NAME'] : "").'
          </div>
        </td>
        <td>
          <div '.((isset($arDATA[$i]['ERR']['SUB_TYP'])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
            <select name="data[SUB_TYP][]">
              <option value="1" '.$arSEL[1].'>'.$this->language->language_getLabel(17).'</option>
              <option value="2" '.$arSEL[2].'>'.$this->language->language_getLabel(18).'</option>
            </select>
            '.((isset($arDATA[$i]['ERR']['SUB_TYP'])) ? "<br />".$arDATA[$i]['ERR']['SUB_TYP'] : "").'
          </div>
        </td>
        <td><a href="#" onClick="if (confirm(\''.$this->language->language_getLabel(2).'\')) this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode); return false;"><img src="img/delete_icon.gif" border="0"></a></td>
      </tr>
      ';
      
      unset($arSEL);
    }

    // ---- moduls ----
    $sTabMod = "";
    $sInnerTab = "";
    foreach ($arMOD as $key => $arVAL)
    {
      // sub_typ
      $arSEL[$arVAL['SUB_TYP']] = "selected";

      for ($i=0; $i<count($arVAL['SUB_ID']); $i++)
      {
        $sInnerTab .= '<tr>
          <td>
            <input type="hidden" name="data['.$key.'][SUB_ID][]" value="'.$arVAL['SUB_ID'][$i].'">
            <div '.((isset($arVAL['ERR']['SUB_NAME'][$i])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
              <input type="text" name="data['.$key.'][SUB_NAME][]" value="'.htmlentities($arVAL['SUB_NAME'][$i]).'" size="8" maxlength="8">
              <br /><div style="padding:1px"></div>
            '.((isset($arVAL['ERR']['SUB_NAME'][$i])) ? $arVAL['ERR']['SUB_NAME'][$i] : "").'
            </div>
          </td>
          <td>
            <div '.((isset($arVAL['ERR']['SUB_LONG_NAME'][$i])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
              <input type="text" name="data['.$key.'][SUB_LONG_NAME][]" value="'.htmlentities($arVAL['SUB_LONG_NAME'][$i]).'" size="30" maxlength="30">
              <br /><div style="padding:1px"></div>
            '.((isset($arVAL['ERR']['SUB_LONG_NAME'][$i])) ? $arVAL['ERR']['SUB_LONG_NAME'][$i] : "").'
            </div>
          </td>
          <td><a href="#" onClick="if (confirm(\''.$this->language->language_getLabel(2).'\')) this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode); return false;"><img src="img/delete_icon.gif" border="0"></a></td>
        </tr>';
      }

      // a moduls row
      $sTabMod .= '
        <tr><td colspan="4"><hr></td></tr>
        <tr valign="top">
          <td colspan="2" cellpadding="0" cellspacing="0">
            <table>
              <tr style="display:none" id="vorlage_mod_'.$key.'">
                <td>
                  <input type="hidden" name="data['.$key.'][SUB_ID][]" value="-9999">
                  <input type="text" name="data['.$key.'][SUB_NAME][]" value="" size="8" maxlength="8"></td>
                <td><input type="text" name="data['.$key.'][SUB_LONG_NAME][]" value="" size="30" maxlength="30"></td>
                <td>
                  <a href="#" onClick="if (confirm(\''.$this->language->language_getLabel(2).'\')) this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode); return false;"><img src="img/delete_icon.gif" border="0"></a>
                </td>
              </tr>
              '.$sInnerTab.'
              <tr>
                <td colspan="2"></td>
                <td>
                  <a href="#" onClick="var objDS = document.getElementById(\'vorlage_mod_'.$key.'\').parentNode.insertBefore(document.getElementById(\'vorlage_mod_'.$key.'\').cloneNode(true),this.parentNode.parentNode); objDS.style.display = \'\'; objDS.id=\'\'; return false;"><img src="img/icon_add.gif" border="0"></a>
                </td>
              </tr>
            </table>
          </td>
          <td>
            <div '.((isset($arVAL['ERR']['SUB_TYP'])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
              <select name="data['.$key.'][SUB_TYP]">
                <option value="1" '.$arSEL[1].'>'.$this->language->language_getLabel(17).'</option>
                <option value="2" '.$arSEL[2].'>'.$this->language->language_getLabel(18).'</option>
              </select>
              '.((isset($arVAL['ERR']['SUB_TYP'])) ? "<br />".$arVAL['ERR']['SUB_TYP'] : "").'
            </div>
          </td>
          <td align="center">
            <a href="#" onClick="if (confirm(\''.$this->language->language_getLabel(2).'\')) this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode); return false;"><img src="img/delete_icon.gif" border="0"></a>
          </td>
        </tr>
      ';

      unset($sSUB_NAME);
      unset($sSUB_LONG_NAME);
      unset($sSUB_ID);
      unset($arSEL);
      $sInnerTab = "";
    }







    // message
    if ($saved=="save_ve")
    {
      if ($sErr != "") {$sMsg1 = '<font color="#ff0000"><b>'.$sErr.'</b></font>';} else {$sMsg1 = '<font color="#00ff00"><b>'.$this->language->language_getLabel(10).'</b></font>';}
    } elseif ($saved=="save_mod")
    {
      if ($sErr != "") {$sMsg2 = '<font color="#ff0000"><b>'.$sErr.'</b></font>';} else {$sMsg2 = '<font color="#00ff00"><b>'.$this->language->language_getLabel(10).'</b></font>';}
    }

    return $sMsg1.'
    <form action="index.php" method="post">
    <input type="hidden" name="site" value="'.$site.'">
    <input type="hidden" name="lang" value="'.$this->lan_id.'">
    <input type="hidden" name="do" value="save_ve">
    <table id="table">
      <tr>
        <th>'.$this->language->language_getLabel(19).'*</th>
        <th>'.$this->language->language_getLabel(5).'*</th>
        <th>'.$this->language->language_getLabel(20).'</th>
        <th></th>
      </tr>
      <tr style="display:none" id="trVorlage">
        <td><input type="hidden" name="data[SUB_ID][]" value="-9999"><input type="text" name="data[SUB_NAME][]" value="" size="8" maxlength="8"></td>
        <td><input type="text" name="data[SUB_LONG_NAME][]" value="" size="30" maxlength="30"></td>
        <td>
          <select name="data[SUB_TYP][]">
            <option value="1">'.$this->language->language_getLabel(17).'</option>
            <option value="2">'.$this->language->language_getLabel(18).'</option>
          </select>
        </td>
        <td>
          <a href="#" onClick="if (confirm(\''.$this->language->language_getLabel(2).'\')) this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode); return false;"><img src="img/delete_icon.gif" border="0"></a>
        </td>
      </tr>
      '.$sTab.'
      <tr id="trLast">
        <td colspan="3"></td>
        <td><a href onClick="var objDS = document.getElementById(\'trVorlage\').parentNode.insertBefore(document.getElementById(\'trVorlage\').cloneNode(true),document.getElementById(\'trLast\')); objDS.style.display = \'\'; objDS.id=\'\'; return false;"><img src="img/icon_add.gif" border="0"></a></td>
      </tr>
      <tr><td colspan="4" align="center">
        <input type="submit" value="'.$this->language->language_getLabel(4).'" >
      </td></tr>
    </table>
    </form>
    
    <hr>
    <h2>'.$this->language->language_getLabel(26).'</h2>
    '.$sMsg2.'
    <form action="index.php" method="post">
    <input type="hidden" name="site" value="'.$site.'">
    <input type="hidden" name="lang" value="'.$this->lan_id.'">
    <input type="hidden" name="do" value="save_mod">
    <input type="hidden" name="counter" value="-9998" id="counter">
    <table id="mod_table">
      <tr>
        <th>'.$this->language->language_getLabel(19).'*</th>
        <th>'.$this->language->language_getLabel(5).'*</th>
        <th>'.$this->language->language_getLabel(20).'</th>
        <th></th>
      </tr>
      <tr style="display:none" id="mod_trVorlage" valign="top" center="center">
        <td colspan="2" cellpadding="0" cellspacing="0">
          <table>
            <tr style="display:none" id="vorlage_mod">
              <td>
                <input type="hidden" name="SUB_ID" value="-9999">
                <input type="text" name="SUB_NAME" value="" size="8" maxlength="8"></td>
              <td><input type="text" name="SUB_LONG_NAME" value="" size="30" maxlength="30"></td>
              <td>
                <a href="#" onClick="if (confirm(\''.$this->language->language_getLabel(2).'\')) this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode); return false;"><img src="img/delete_icon.gif" border="0"></a>
              </td>
            </tr>
            <tr>
              <td>
                <input type="hidden" name="SUB_ID" value="-9999">
                <input type="text" name="SUB_NAME" size="8" maxlength="8">
              </td>
              <td>
                <input type="text" name="SUB_LONG_NAME" size="30" maxlength="30">
              </td>
              <td><a href="#" onClick="if (confirm(\''.$this->language->language_getLabel(2).'\')) this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode); return false;"><img src="img/delete_icon.gif" border="0"></a></td>
            </tr>
            <tr>
              <td colspan="2"></td>
              <td>
                <a href="#" onClick="var objDS = document.getElementById(\'vorlage_mod_'.$key.'\').parentNode.insertBefore(document.getElementById(\'vorlage_mod_'.$key.'\').cloneNode(true),this.parentNode.parentNode); objDS.style.display = \'\'; objDS.id=\'\'; return false;"><img src="img/icon_add.gif" border="0"></a>
              </td>
            </tr>
          </table>
        </td>
      </tr>
      '.$sTabMod.'
      <tr><td colspan="4"><hr></td></tr>
      <tr><td colspan="3"></td><td><a href="#" onClick="return false;"> <img src="img/icon_add.gif" border="0"></a></td></tr>
      <tr id="mod_trLast"><td colspan="4" align="center">
        <input type="submit" value="'.$this->language->language_getLabel(4).'" >
      </td></tr>
    </table>
    </form>';
  }
  
  







  /**
      @brief    get whole HTML site
      @ingroup  v_subject
      @param    $sMain contains content that should shown in the main area of the application (data table)
      @return HTML site
  */
  function v_subject_generate_site($sMain)
  {
    $sHeadline = $this->language->language_getLabel(25);
    return $this->frame->frame_getFrame($sHeadline, $sMain, $this->lan_id);
  }
}
?>