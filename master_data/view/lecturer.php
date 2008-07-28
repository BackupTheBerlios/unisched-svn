<?php

/**

  @defgroup v_lecturer class v_lecturer
  @brief library to present 'lecturer' form
  @ingroup VIEW

  <pre>
  --------------------------------------------------------------------------------
  FILE-HISTORY
  --------------------------------------------------------------------------------
  Description
    provide 'lecturer' form
  --------------------------------------------------------------------------------
  date        version   upload    who?      change description
  18.07.2008            no        it05mg1   created
  28.07.2008  1.0.0     yes       it05mg1   upload
  --------------------------------------------------------------------------------
  </pre>
*/


class v_lecturer
{
  var $frame;
  var $language;
  var $lan_id;
  
  
  /**
      @brief    constructor (initiate frame and language class)
      @ingroup  v_lecturer
      @param    $lan_id current language
  */
  function v_lecturer($val)
  {
    $this->lan_id = $val['lang'];

    $this->frame = new frame($val);
    $this->language = new language($this->lan_id);
  }









  /**
      @brief    generate data table
      @ingroup  v_lecturer
      @param    $arDATA array with all data
      @param    $site contains current site parameter
      @param    $sErr saving exception message
      @return   HTML table
  */
  function v_lecturer_getFormHtml($arDATA, $site, $sErr=null, $saved=null)
  {

    $sTab = "";
    for ($i=0; $i<count($arDATA); $i++)
    {
      $sTab .= '
      <tr valign="top">
        <td>
          <div '.((isset($arDATA[$i]['ERR']['LEC_TIT'])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
            <input type="hidden" name="data[LEC_ID][]" value="'.$arDATA[$i]['LEC_ID'].'">
            <input type="text" name="data[LEC_TIT][]" value="'.htmlentities($arDATA[$i]['LEC_TIT']).'" size="10" maxlength="10">
            '.((isset($arDATA[$i]['ERR']['LEC_TIT'])) ? "<br />".$arDATA[$i]['ERR']['LEC_TIT'] : "").'
          </div>
        </td>
        <td>
          <div '.((isset($arDATA[$i]['ERR']['LEC_LNAME'])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
            <input type="text" name="data[LEC_LNAME][]" value="'.htmlentities($arDATA[$i]['LEC_LNAME']).'" size="30" maxlength="30">
            '.((isset($arDATA[$i]['ERR']['LEC_LNAME'])) ? "<br />".$arDATA[$i]['ERR']['LEC_LNAME'] : "").'
          </div>
        </td>
        <td>
          <div '.((isset($arDATA[$i]['ERR']['LEC_GNAME'])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
            <input type="text" name="data[LEC_GNAME][]" value="'.htmlentities($arDATA[$i]['LEC_GNAME']).'" size="30" maxlength="30">
            '.((isset($arDATA[$i]['ERR']['LEC_GNAME'])) ? "<br />".$arDATA[$i]['ERR']['LEC_GNAME'] : "").'
          </div>
        </td>
        <td>
          <div '.((isset($arDATA[$i]['ERR']['LEC_TEL'])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
            <input type="text" name="data[LEC_TEL][]" value="'.htmlentities($arDATA[$i]['LEC_TEL']).'" size="20" maxlength="20">
            '.((isset($arDATA[$i]['ERR']['LEC_TEL'])) ? "<br />".$arDATA[$i]['ERR']['LEC_TEL'] : "").'
          </div>
        </td>
        <td><a href="#" onClick="if (confirm(\''.$this->language->language_getLabel(2).'\')) this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode); return false;"><img src="../img/delete_icon.gif" border="0"></a></td>
      </tr>

      ';
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
        <th>'.$this->language->language_getLabel(47).'</th>
        <th>'.$this->language->language_getLabel(14).'*</th>
        <th>'.$this->language->language_getLabel(13).'*</th>
        <th>'.$this->language->language_getLabel(15).'</th>
        <th></th>
      </tr>
      <tr style="display:none" id="trVorlage">
        <td><input type="hidden" name="data[LEC_ID][]" value="-9999"><input type="text" name="data[LEC_TIT][]" value="" size="10" maxlength="10"></td>
        <td><input type="text" name="data[LEC_LNAME][]" value="" size="30" maxlength="30"></td>
        <td><input type="text" name="data[LEC_GNAME][]" value="" size="30" maxlength="30"></td>
        <td><input type="text" name="data[LEC_TEL][]" value="" size="20" maxlength="20"></td>
        <td><a href="#" onClick="if (confirm(\''.$this->language->language_getLabel(2).'\')) this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode); return false;"><img src="../img/delete_icon.gif" border="0"></a></td>
      </tr>
      '.$sTab.'
      <tr id="trLast">
        <td colspan="4"></td>
        <td><a href onClick="var objDS = document.getElementById(\'trVorlage\').parentNode.insertBefore(document.getElementById(\'trVorlage\').cloneNode(true),document.getElementById(\'trLast\')); objDS.style.display = \'\'; objDS.id=\'\'; return false;"><img src="../img/icon_add.gif" border="0"></a></td>
      </tr>
      <tr><td colspan="4" align="center">
        <input type="submit" value="'.$this->language->language_getLabel(4).'" >
      </td></tr>
    </table>
    </form>';
  }
  
  







  /**
      @brief    get whole HTML site
      @ingroup  v_lecturer
      @param    $sMain contains content that should shown in the main area of the application (data table)
      @return HTML site
  */
  function v_lecturer_generate_site($sMain)
  {
    $sHeadline = $this->language->language_getLabel(21);
    return $this->frame->frame_getFrame($sHeadline, $sMain, $this->lan_id);
  }
}
?>