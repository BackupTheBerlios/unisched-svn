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
      @param    $val array with all post-data
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
      @return   HTML table
  */
  function v_first_page_getFormHtml()
  {   // english / german
  
    if ($this->lan_id==1)
    {
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
            <td align="center"><img src="../img/edit_copy.png" width="24px" ></td>
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
    } else
    {
      // english
      $sMain = '
        <font size="+1"><b>References For The Handling</b></font>

        <table width="75%">
          <tr>
            <th>icon</th>
            <th>description</th>
          </tr>
          <tr>
            <td align="center"><img src="../img/icon_add.gif"></td>
            <td>Add new records.</td>
          </tr>
          <tr>
            <td align="center"><img src="../img/edit.gif"></td>
            <td>Edit a record.</td>
          </tr>
          <tr>
            <td align="center"><img src="../img/edit_copy.png" width="24px" ></td>
            <td>Copy records.</td>
          </tr>
          <tr>
            <td align="center"><img src="../img/delete_icon.gif"></td>
            <td>Delete a record. <br />Record will not be deleted until the <b>save</b> button has been pressed.</td>
          </tr>
          <tr>
            <td align="center">*</td>
            <td>Mandatory field</td>
          </tr>
          <tr>
            <td align="center">(<a href="#">?</a>)</td>
            <td>A contextual help will open.</td>
          </tr>
          <tr>
            <td align="center"><input type="submit" value="save"</td>
            <td>Changes (add, edit, delete) will not be saved until the save button has been pressed.</td>
          </tr>
        </table>

        <br />

        <font size="+1"><b>Contextual Information</b></font>

        <table width="75%">
          <tr>
            <td>
            </td>
          </tr>
          <tr>
            <td align="left">
              <a name="curriculum_copy_action"></a>
              <b>curriculum - how to copy:</b> <br />
              1)	Preparation: A new class must be created. This class must have the same number of class periods like the template. <br />
              2)	Press the copy button behind the class, that you want to copy. <br />
              3)	Within the next step you have to choose the class, which gets the copy of the curriculum. <br />
              4)	Verify the details and save the data. <br />
            </td>
          </tr>
          <tr>
            <td align="left">
              <a name="curriculum_subject"></a>
              <b>curriculm - modules:</b> <br />
              Inside of the curriculm the modules only appear as one record. The rooms and time can be distributed separately within the room and time planning. <br />
              A module can be assigned to more than one class. The relevant classes are marked in the scheduling.
            </td>
          </tr>
          <tr>
            <td align="left">
              <a name="curriculum"></a>
              <b>curriculum - hours:</b> <br />
              The quantity of the hours is equivalent to units of 45 minutes.
            </td>
          </tr>
          <tr>
            <td align="left">
              <a name="defaultroom_priority"></a>
              <b>defaultroom - priority:</b> <br />
              High priority means, that a room is preferred in the room scheduling.
            </td>
          </tr>
        </table>

        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
      ';
    }
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