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
  28.07.2008  1.0.0     yes       it05mg1   upload
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
      <font size="+1"><b>Hinweise zur Bearbeitung</b></font>

      <table width="75%">
        <tr>
          <th>Symbol</th>
          <th>Beschreibung</th>
        </tr>
        <tr>
          <td align="center"><img src="../img/icon_add.gif"></td>
          <td>Hinzufügen neuer Datensätze.</td>
        </tr>
        <tr>
          <td align="center"><img src="../img/edit.gif"></td>
          <td>Bearbeiten eines Datensatzes.</td>
        </tr>
        <tr>
          <td align="center"><img src="img/edit_copy.png" width="24px" ></td>
          <td>Daten kopieren.</td>
        </tr>
        <tr>
          <td align="center"><img src="../img/delete_icon.gif"></td>
          <td>Entfernen eines Datensatzes.<br />Wird erst mit Betätigung der <b>Speichern</b>-Schaltfläche ausgeführt.</td>
        </tr>
        <tr>
          <td align="center">*</td>
          <td>Pflichtfeld</td>
        </tr>
        <tr>
          <td align="center">(<a href="#">?</a>)</td>
          <td>Hilfe zum jeweiligen Feld öffnet sich.</td>
        </tr>
        <tr>
          <td align="center"><input type="submit" value="Speichern"</td>
          <td>Erst mit dem Betätigen der Speichern-Schaltfläche wird jede Änderung (Hinzufügen, Ändern, Entfernen) gespeichert.</td>
        </tr>
      </table>

      <br />

      <font size="+1"><b>Formularbezogene Hinweise</b></font>

      <table width="75%">
        <tr>
          <td>
          </td>
        </tr>
        <tr>
          <td align="left">
            <a name="curriculum_copy_action"></a>
            <b>Curriculum - Vorgang des Kopierens:</b> <br />
            1) Vorbereitung: Es muss eine neue Seminargruppe erstellt werden, welche innerhalb der Semester die gleiche Anzahl an Studienzeiträumen besitzt, wie die Vorlage. <br />
            2) Betätigen Sie die Schaltfläche <b>kopieren</b> hinter der Seminargruppe die Sie kopieren wollen. <br />
            3) Wählen Sie im nächsten Dialog die Seminargruppe, welche die Daten des Curriculums erhalten soll. <br />
            4) Überprüfen Sie die Angaben und Speichern Sie die kopierten Daten. <br />
          </td>
        </tr>
        <tr>
          <td align="left">
            <a name="curriculum_subject"></a>
            <b>Curriculum - Module:</b> <br />
            Innerhalb des Curriculums erscheinen Module nur als ein Datensatz. Sie können dann innerhalb der Raum- und Stundenplanung getrennt auf Räume und Zeit verteilt werden.<br />
            Ein Modulblock kann mehreren Seminargruppen (Studienrichtungsübergreifend) zugeteilt werden. In der Planung erscheint dies bei allen betroffenen Seminargruppen.
          </td>
        </tr>
        <tr>
          <td align="left">
            <a name="curriculum"></a>
            <b>Curriculum - Stunden:</b> <br />
            Die Anzahl der Stunden entspricht Einheiten von 45 Minuten.
          </td>
        </tr>
        <tr>
          <td align="left">
            <a name="defaultroom_priority"></a>
            <b>Standardraum - Priotät:</b> <br />
            Höhere Priorität bedeutet, dass ein Raum in der Raumplanung den Vorzug gegenüber einem Raum mit niedriger Priorität erhält.
          </td>
        </tr>
      </table>
      
      <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
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