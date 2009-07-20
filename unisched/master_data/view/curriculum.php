<?php

/**

  @defgroup v_curriculum class v_curriculum
  @brief library to present 'curriculum' form
  @ingroup VIEW

  <pre>
  --------------------------------------------------------------------------------
  FILE-HISTORY
  --------------------------------------------------------------------------------
  Description
    provide 'curriculum' form
  --------------------------------------------------------------------------------
  date        version   upload    who?      change description
  10.07.2008            no        it05mg1   created
  28.07.2008  1.0.0     yes       it05mg1   upload
  --------------------------------------------------------------------------------
  </pre>
*/


class v_curriculum
{
  var $frame;
  var $language;
  var $lan_id;
  
  
  /**
      @brief    constructor (initiate frame and language class)
      @ingroup  v_curriculum
      @param    $val array with all post-data
  */
  function v_curriculum($val)
  {
    $this->lan_id = $val['lang'];

    $this->frame = new frame($val);
    $this->language = new language($this->lan_id);
  }









  /**
      @brief    generate data table
      @ingroup  v_curriculum
      @param    $arDATA array with all data
      @param    $site contains current site parameter
      @return   HTML table
  */
  function v_curriculum_getFormHtml($arDATA, $site)
  {
    $sTab = "";
    for ($i=0; $i<count($arDATA); $i++)
    {
      $sTab .= '<tr valign="top">
        <td>
          '.htmlentities($arDATA[$i]['CLASS_NAME']).'
        </td>
        <td valign="middle">
          <a href="index.php?site=8&lang='.$this->lan_id.'&CLASS_ID='.$arDATA[$i]['CLASS_ID'].'"><img src="../img/edit.gif" border="0"></a>
          <a href="index.php?site=8&do=copy_start&lang='.$this->lan_id.'&COPY_CLASS_ID='.$arDATA[$i]['CLASS_ID'].'" title="'.$this->language->language_getLabel(69).'"><img src="../img/edit_copy.png" width="24px" border="0"></a>
        </td>
      </tr>';
    }

    return (($sTab=="") ? '>>> <b>'.$this->language->language_getLabel(55).' <<<' : "").'
    <table>
      <tr>
        <th>'.$this->language->language_getLabel(12).'</th>
        <th>'.$this->language->language_getLabel(44).' (<a href="index.php?site=0&lang='.$this->lan_id.'#curriculum_copy_action" target="_blank">?</a>)</th>
      </tr>
      '.$sTab.'
    </table>';
  }
  
  







  /**
      @brief    get whole HTML site
      @ingroup  v_curriculum
      @param    $sMain contains content that should shown in the main area of the application (data table)
      @return HTML site
  */
  function v_curriculum_generate_site($sMain)
  {
    $sHeadline = $this->language->language_getLabel(22);
    return $this->frame->frame_getFrame($sHeadline, $sMain, $this->lan_id);
  }
}
?>