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
      @param    $lan_id current language
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
        <td>
          [<a href="index.php?site=8&lang='.$this->lan_id.'&CLASS_ID='.$arDATA[$i]['CLASS_ID'].'">edit</a>]
          [<a href="#">copy</a>]
        </td>
      </tr>';
    }

    return '
    <table>
      <tr>
        <th>'.$this->language->language_getLabel(12).'</th>
        <th>'.$this->language->language_getLabel(44).'</th>
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
    $sHeadline = $this->language->language_getLabel(1);
    return $this->frame->frame_getFrame($sHeadline, $sMain, $this->lan_id);
  }
}
?>