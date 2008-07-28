<?php

/**

  @defgroup c_room class c_room
  @brief library to interconnect presentation and model for the 'room' web form
  @ingroup CONTROLLER

  <pre>
  --------------------------------------------------------------------------------
  FILE-HISTORY
  --------------------------------------------------------------------------------
  Description
    handle room form
  --------------------------------------------------------------------------------
  date        version   upload    who?      change description
  20.07.2008            no        it05mg1   created
  28.07.2008  1.0.0     yes       it05mg1   upload
  --------------------------------------------------------------------------------
  </pre>
*/


class c_room
{
  var $v_room; // VIEW
  var $model;
  var $val;
  var $language;
  
  /**
      @brief    constructor (initiate v_room, mdl and language class)
      @ingroup  c_room
      @param    $val  array with all posted parameters
  */
  function c_room($val)
  {
    $this->val = $val;

    $this->v_room = new v_room($val);
    $this->model = new mdl;
    $this->language = new language($val['lang']);
  }









  /**
      @brief    generate form (main part of the application website)
      @ingroup  c_room
      @return   HTML (table with 'room' data)
  */
  function c_room_generateForm()
  {
    if ($this->val['do'] == "save")
    {
      // check saving data
      $sErr = $this->c_room_validateData($arSAVE, $arDEL);

      if ($sErr=="")
      {
        // saving
        for ($i=0; $i<count($arSAVE); $i++)
        {
          // take all rooms
          $arField[$i]['STRING']['ROOM_NR'] = $arSAVE[$i]['ROOM_NR'];
          $arField[$i]['STRING']['ROOM_NAME'] = $arSAVE[$i]['ROOM_NAME'];
          $arField[$i]['NUMBER']['ROOM_SEAT'] = $arSAVE[$i]['ROOM_SEAT'];
          $arField[$i]['NUMBER']['room_type'] = $arSAVE[$i]['ROOM_TYPE'];

          // insert data
          if ($this->model->mdl_insert_data($arField, array("ROOM_ID", $arSAVE[$i]['ROOM_ID']),"ROOM", $arSAVE[$i]['_STATUS']) ) {$sErr = $this->language->language_getLabel(8); break;}
        }
        
        if (is_array($arDEL))
        {
          if ($sErr=="")
          {
            foreach($arDEL as $key => $value)
            {
              $this->model->mdl_delete_data(array("ROOM_ID", $key), "ROOM");
            }
          }
        }
      }
    }

    // error?
    if ($sErr!="")
    {
      // show form data
      $iCnt = 0;
      for ($i=1; $i<count($this->val['data']['ROOM_ID']); $i++)
      {
        $arDATA[$iCnt]['ROOM_ID'] = $this->val['data']['ROOM_ID'][$i];
        $arDATA[$iCnt]['ROOM_NR'] = $this->val['data']['ROOM_NR'][$i];
        $arDATA[$iCnt]['ROOM_NAME'] = $this->val['data']['ROOM_NAME'][$i];
        $arDATA[$iCnt]['ROOM_SEAT'] = $this->val['data']['ROOM_SEAT'][$i];
        $arDATA[$iCnt]['room_type'] = $this->val['data']['ROOM_TYPE'][$i];

        $arDATA[$iCnt]['ERR']['ROOM_NR'] = $this->val['data']['ERR']['ROOM_NR'][$i];
        $arDATA[$iCnt]['ERR']['ROOM_NAME'] = $this->val['data']['ERR']['ROOM_NAME'][$i];
        $arDATA[$iCnt]['ERR']['ROOM_SEAT'] = $this->val['data']['ERR']['ROOM_SEAT'][$i];
        $arDATA[$iCnt]['ERR']['ROOM_TYPE'] = $this->val['data']['ERR']['ROOM_TYPE'][$i];
        $iCnt++;
      }
    } else
    {
      // show database data
      $arDATA = $this->model->mdl_execute_simple_queries("room", null, null, "ROOM_NR");
    }
    
    // generate table with 'room' data
    $sMain = $this->v_room->v_room_getFormHtml($arDATA, $this->val['site'], $sErr, $this->val['do']);
    
    // call function that generates the whole HTML-site
    return $this->v_room->v_room_generate_site($sMain);
  }
  
  







  /**
      @brief    validate posted data
      @ingroup  c_room
      @return   $arSAVE (function-parameter) array containing records to save
      @return   $arDEL (function-parameter) array containing records to delete
      @return   error message
  */
  function c_room_validateData(&$arSAVE, &$arDEL)
  {
    $sErr = "";

    // necessary to identify deleted records: query all 'room' data
    $arFLD = $this->model->mdl_execute_simple_queries("room");
    for ($i=0; $i<count($arFLD); $i++) {$arDEL[$arFLD[$i]['ROOM_ID']]=true;}
    
    // check all records
    $iCnt = 0;
    unset($arDOPL);
    for ($i=1; $i<count($this->val['data']['ROOM_ID']); $i++)
    {
      $bChange = FALSE;
      $bNewRecord = FALSE;
      
      // format strings
      $this->val['data']['ROOM_NR'][$i] = stripslashes($this->val['data']['ROOM_NR'][$i]);
      $this->val['data']['ROOM_NAME'][$i] = stripslashes($this->val['data']['ROOM_NAME'][$i]);

      // format numbers
      $this->val['data']['ROOM_SEAT'][$i] = intval($this->val['data']['ROOM_SEAT'][$i]);
      $this->val['data']['ROOM_TYPE'][$i] = intval($this->val['data']['ROOM_TYPE'][$i]);

      if ($this->val['data']['ROOM_ID'][$i] != -9999) // existing record
      {
        // query current record
        $arCHK = $this->model->mdl_execute_simple_queries("room", "room_id", array(intval($this->val['data']['ROOM_ID'][$i])));

        // record changed?
        if ($this->val['data']['ROOM_NR'][$i] != $arCHK[0]['ROOM_NR']) {$bChange = TRUE;}
        if ($this->val['data']['ROOM_NAME'][$i] != $arCHK[0]['ROOM_NAME']) {$bChange = TRUE;}
        if ($this->val['data']['ROOM_SEAT'][$i] != $arCHK[0]['ROOM_SEAT']) {$bChange = TRUE;}
        if ($this->val['data']['ROOM_TYPE'][$i] != $arCHK[0]['room_type']) {$bChange = TRUE;}
      
      } else  // new record
      {
        $bChange = TRUE;
        $bNewRecord = TRUE;
      }
      
      // validate changed data
      if ($bChange)
      {
        if (strlen($this->val['data']['ROOM_NR'][$i]) < 1 or strlen($this->val['data']['ROOM_NR'][$i]) > 5) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['ROOM_NR'][$i] = str_replace(array("<#L1#>", "<#L2#>"), array(1,5), $this->language->language_getLabel(6));}
        if (strlen($this->val['data']['ROOM_NAME'][$i]) > 30) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['ROOM_NAME'][$i] = str_replace(array("<#L1#>", "<#L2#>"), array(0,30), $this->language->language_getLabel(6));}
        if ($this->val['data']['ROOM_SEAT'][$i] < 0 or $this->val['data']['ROOM_SEAT'][$i] > 999) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['ROOM_SEAT'][$i] = str_replace(array("<#N1#>", "<#N2#>"), array(0,999), $this->language->language_getLabel(27));}
        if ($this->val['data']['ROOM_TYPE'][$i] != 0 and $this->val['data']['ROOM_TYPE'][$i] != 1) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['ROOM_TYPE'][$i] = $this->language->language_getLabel(23);}
        
        $arSAVE[$iCnt]['ROOM_ID'] = intval($this->val['data']['ROOM_ID'][$i]);
        $arSAVE[$iCnt]['ROOM_NR'] = $this->val['data']['ROOM_NR'][$i];
        $arSAVE[$iCnt]['ROOM_NAME'] = $this->val['data']['ROOM_NAME'][$i];
        $arSAVE[$iCnt]['ROOM_SEAT'] = $this->val['data']['ROOM_SEAT'][$i];
        $arSAVE[$iCnt]['ROOM_TYPE'] = $this->val['data']['ROOM_TYPE'][$i];
        if ($bNewRecord) {$arSAVE[$iCnt]['_STATUS'] = "insert"; } else {$arSAVE[$iCnt]['_STATUS'] = "update"; }
        $iCnt++;
      }

      // check doubled records
      if (isset($arDOPL[$this->val['data']['ROOM_NR'][$i]])) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['ROOM_NR'][$i] = $this->language->language_getLabel(28);}
      else {$arDOPL[$this->val['data']['ROOM_NR'][$i]]="";}

      // necessary to identify deleted records: mark all existing records
      unset($arDEL[$this->val['data']['ROOM_ID'][$i]]);
    }

    // deleting records
    if (is_array($arDEL))
    {
      foreach ($arDEL as $pk_value => $bDelete)
      {
        // ---- check values in booking ----
        $iChk = $this->model->mdl_check_foreign_key("booking", array("room_id", $pk_value));

        if ($iChk>0)
        {
          // get record
          $arH = $this->model->mdl_execute_simple_queries("room", "room_id", array($pk_value));

          // add record to data array
          $this->val['data']['ROOM_ID'][] = $pk_value;
          $this->val['data']['ROOM_NR'][] = $arH[0]['ROOM_NR'];
          $this->val['data']['ROOM_NAME'][] = $arH[0]['ROOM_NAME'];
          $this->val['data']['ROOM_SEAT'][] = $arH[0]['ROOM_SEAT'];
          $this->val['data']['ROOM_TYPE'][] = $arH[0]['room_type'];

          // error message
          $sErr .= str_replace(array("<#NAME#>", "<#ANZAHL#>", "<#FK_NAME#>"), array($arH[0]['ROOM_NR'], $iChk, $this->language->language_getLabel(29)) , $this->language->language_getLabel(9));

          $arADDED[$pk_value] = "";
        }

        // ---- check values in defaultrooms ----
        $iChk = $this->model->mdl_check_foreign_key("defaultrooms", array("room_id", $pk_value));

        if ($iChk>0)
        {
          // get record
          $arH = $this->model->mdl_execute_simple_queries("room", "room_id", array($pk_value));

          if (!isset($arADDED[$pk_value]))
          {
            // add record to data array
            $this->val['data']['ROOM_ID'][] = $pk_value;
            $this->val['data']['ROOM_NR'][] = $arH[0]['ROOM_NR'];
            $this->val['data']['ROOM_NAME'][] = $arH[0]['ROOM_NAME'];
            $this->val['data']['ROOM_SEAT'][] = $arH[0]['ROOM_SEAT'];
            $this->val['data']['ROOM_TYPE'][] = $arH[0]['room_type'];
          }

          // error message
          $sErr .= "<br>".str_replace(array("<#NAME#>", "<#ANZAHL#>", "<#FK_NAME#>"), array($arH[0]['ROOM_NR'], $iChk, $this->language->language_getLabel(30)) , $this->language->language_getLabel(9));
        }
      }
    }
    return $sErr;
  }
}

?>