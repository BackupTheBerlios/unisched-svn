<?php

/**

  @defgroup v_field class v_field
  @brief library to present 'field' form
  @ingroup VIEW

  <pre>
  --------------------------------------------------------------------------------
  FILE-HISTORY
  --------------------------------------------------------------------------------
  Description
    provide 'field' form
  --------------------------------------------------------------------------------
  date        version   upload    who?      change description
  10.07.2008            no        it05mg1   created
  --------------------------------------------------------------------------------
  </pre>
*/


class v_field
{
  var $frame;
  var $language;
  var $lan_id;
  
  
  /**
      @brief    constructor (initiate frame and language class)
      @ingroup  v_field
      @param    $lan_id current language
  */
  function v_field($val)
  {
    $this->lan_id = $val['lang'];

    $this->frame = new frame($val);
    $this->language = new language($this->lan_id);
  }









  /**
      @brief    generate data table
      @ingroup  v_field
      @param    $arDATA array with all data
      @param    $site contains current site parameter
      @param    $sErr saving exception message
      @return   HTML table
  */
  function v_field_getFormHtml($arDATA, $site, $sErr=null, $saved=null)
  {
    $sTab = "";
    for ($i=0; $i<count($arDATA); $i++)
    {
      $sTab .= '<tr valign="top">
        <td>
          <div '.((isset($arDATA[$i]['ERR']['FIELD_NAME'])) ? 'style="border:1px solid #FF0000; color:#FF0000; padding:1px; display:table;"' : "").'>
            <input type="hidden" name="data[FIELD_ID][]" value="'.$arDATA[$i]['FIELD_ID'].'"><input type="text" name="data[FIELD_NAME][]" value="'.htmlentities($arDATA[$i]['FIELD_NAME']).'" size="30" maxlength="30">
            '.((isset($arDATA[$i]['ERR']['FIELD_NAME'])) ? "<br />".$arDATA[$i]['ERR']['FIELD_NAME'] : "").'
          </div>
        </td>
        <td><a href="#" onClick="if (confirm(\''.$this->language->language_getLabel(2).'\')) this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode); return false;"><img src="img/delete_icon.gif" border="0"></a></td>
      </tr>';
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
    <table>
      <tr>
        <th>'.$this->language->language_getLabel(5).'*</th>
        <th></th>
      </tr>
      <tr style="display:none" id="trVorlage">
        <td><input type="hidden" name="data[FIELD_ID][]" value="-9999"><input type="text" name="data[FIELD_NAME][]" value="" size="30" maxlength="30"></td>
        <td><a href="#" onClick="if (confirm(\''.$this->language->language_getLabel(2).'\')) this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode); return false;"><img src="img/delete_icon.gif" border="0"></a></td>
      </tr>
      '.$sTab.'
      <tr id="trLast">
        <td></td>
        <td><a href onClick="var objDS = document.getElementById(\'trVorlage\').parentNode.insertBefore(document.getElementById(\'trVorlage\').cloneNode(true),document.getElementById(\'trLast\')); objDS.style.display = \'\'; objDS.id=\'\'; return false;"><img src="img/icon_add.gif" border="0"></a></td>
      </tr>
      <tr><td colspan="2" align="center">
        <input type="submit" value="'.$this->language->language_getLabel(4).'" >
      </td></tr>
    </table>
    </form>';
  }
  
  







  /**
      @brief    get whole HTML site
      @ingroup  v_field
      @param    $sMain contains content that should shown in the main area of the application (data table)
      @return HTML site
  */
  function v_field_generate_site($sMain)
  {
    $sHeadline = $this->language->language_getLabel(1);
    return $this->frame->frame_getFrame($sHeadline, $sMain, $this->lan_id);
  }
}
?>