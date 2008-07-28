<?php

/**

  @defgroup v_first_page class v_first
  @brief master data start page
  @ingroup VIEW

  <pre>
  --------------------------------------------------------------------------------
  FILE-HISTORY
  --------------------------------------------------------------------------------
  Description
    first page
  --------------------------------------------------------------------------------
  date        version   upload    who?      change description
  25.07.2008            no        it05mg1   created
  --------------------------------------------------------------------------------
  </pre>
*/


class v_first_page
{
  var $frame;
  var $language;
  var $lan_id;
  
  
  /**
      @brief    constructor (initiate frame and language class)
      @ingroup  v_first_page
      @param    $lan_id current language
  */
  function v_first_page($val)
  {
    $this->lan_id = $val['lang'];

    $this->frame = new frame($this->lan_id);
    $this->language = new language($this->lan_id);
  }









  /**
      @brief    generate data table
      @ingroup  v_first_page
      @param    $arDATA array with all data (lectures and examination
      @param    $arMOD data for moduls
      @param    $site contains current site parameter
      @param    $sErr saving exception message
      @return   HTML table
  */
  function v_first_page_getFormHtml()
  {   // english / german
    $sMain = '
      <b>Hinweise</b>
      <br />
      <br />
      
      <table width="50%">
        <tr>
          <td>
          </td>
        </tr>
        <tr>
          <td align="left">
            <a name="defaultroom_priority"></a>
            <b>Standardraum - Priotät:</b> <br />
            Höhere Priorität bedeutet, dass ein Raum in der Raumplanung den Vorzug gegenüber einem Raum mit niedriger priorität erhält.
          </td>
        </tr>
        <tr>
          <td align="left">
            <a name="curriculum"></a>
            <b>Curriculum - Stunden:</b> <br />
            Anzahl der Stunden entspricht Einheiten von 45 Minuten.
          </td>
        </tr>
      </table>
      
      
    ';

    return $this->v_first_page_generate_site($sMain);
  }
  
  







  /**
      @brief    get whole HTML site
      @ingroup  v_first_page
      @param    $sMain contains content that should shown in the main area of the application (data table)
      @return HTML site
  */
  function v_first_page_generate_site($sMain)
  {
    $sHeadline = $this->language->language_getLabel(46);
    return $this->frame->frame_getFrame($sHeadline, $sMain, $this->lan_id);
  }
}
?>