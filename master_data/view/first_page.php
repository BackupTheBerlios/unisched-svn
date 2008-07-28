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
          <td>Hinzuf�gen neuer Datens�tze.</td>
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
          <td>Entfernen eines Datensatzes.<br />Wird erst mit Bet�tigung der <b>Speichern</b>-Schaltfl�che ausgef�hrt.</td>
        </tr>
        <tr>
          <td align="center">*</td>
          <td>Pflichtfeld</td>
        </tr>
        <tr>
          <td align="center">(<a href="#">?</a>)</td>
          <td>Hilfe zum jeweiligen Feld �ffnet sich.</td>
        </tr>
        <tr>
          <td align="center"><input type="submit" value="Speichern"</td>
          <td>Erst mit dem Bet�tigen der Speichern-Schaltfl�che wird jede �nderung (Hinzuf�gen, �ndern, Entfernen) gespeichert.</td>
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
            1) Vorbereitung: Es muss eine neue Seminargruppe erstellt werden, welche innerhalb der Semester die gleiche Anzahl an Studienzeitr�umen besitzt, wie die Vorlage. <br />
            2) Bet�tigen Sie die Schaltfl�che <b>kopieren</b> hinter der Seminargruppe die Sie kopieren wollen. <br />
            3) W�hlen Sie im n�chsten Dialog die Seminargruppe, welche die Daten des Curriculums erhalten soll. <br />
            4) �berpr�fen Sie die Angaben und Speichern Sie die kopierten Daten. <br />
          </td>
        </tr>
        <tr>
          <td align="left">
            <a name="curriculum_subject"></a>
            <b>Curriculum - Module:</b> <br />
            Innerhalb des Curriculums erscheinen Module nur als ein Datensatz. Sie k�nnen dann innerhalb der Raum- und Stundenplanung getrennt auf R�ume und Zeit verteilt werden.<br />
            Ein Modulblock kann mehreren Seminargruppen (Studienrichtungs�bergreifend) zugeteilt werden. In der Planung erscheint dies bei allen betroffenen Seminargruppen.
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
            <b>Standardraum - Priot�t:</b> <br />
            H�here Priorit�t bedeutet, dass ein Raum in der Raumplanung den Vorzug gegen�ber einem Raum mit niedriger Priorit�t erh�lt.
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