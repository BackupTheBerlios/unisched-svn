<?php

/**

  @defgroup c_defaultroom class c_defaultroom
  @brief library to interconnect presentation and model for the 'defaultroom' web form
  @ingroup CONTROLLER

  <pre>
  --------------------------------------------------------------------------------
  FILE-HISTORY
  --------------------------------------------------------------------------------
  Description
    handle defaultroom form
  --------------------------------------------------------------------------------
  date        version   upload    who?      change description
  23.07.2008            no        it05mg1   created
  --------------------------------------------------------------------------------
  </pre>
*/


class c_defaultroom
{
  var $v_defaultroom; // VIEW
  var $model;
  var $val;
  var $language;
  
  /**
      @brief    constructor (initiate v_defaultroom, mdl and language class)
      @ingroup  c_defaultroom
      @param    $val  array with all posted parameters
  */
  function c_defaultroom($val)
  {
    $this->val = $val;

    $this->v_defaultroom = new v_defaultroom($val);
    $this->model = new mdl;
    $this->language = new language($val['lang']);
  }









  /**
      @brief    generate form (main part of the application website)
      @ingroup  c_defaultroom
      @param    $site current site
      @return   HTML (table with 'defaultroom' data)
  */
  function c_defaultroom_generateForm()
  {
    if ($this->val['do'] == "save")
    {
      // check saving data
      $sErr = $this->c_defaultroom_validateData($arSAVE, $arDEL);

      if ($sErr=="")
      {
        // insert data
        if ($this->model->mdl_insert_defaultroom($arSAVE)) {$sErr = $this->language->language_getLabel(8); break;}
        
        if (is_array($arDEL))
        {
          die("löschen");
          if ($sErr=="")
          {
            foreach($arDEL as $key => $value)
            {
              $this->model->mdl_delete_data(array("DEFAULTROOMS_ID", $key), "DEFAULTROOMS");
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
        $arDATA[$iCnt]['CLASS_ID'] = $this->val['data']['CLASS_ID'][$i];
        $arDATA[$iCnt]['PRIORITY'] = $this->val['data']['PRIORITY'][$i];

        $arDATA[$iCnt]['ERR']['ROOM_ID'] = $this->val['data']['ERR']['ROOM_ID'][$i];
        $arDATA[$iCnt]['ERR']['CLASS_ID'] = $this->val['data']['ERR']['CLASS_ID'][$i];
        $arDATA[$iCnt]['ERR']['PRIORITY'] = $this->val['data']['ERR']['PRIORITY'][$i];
        $iCnt++;
      }
    } else
    {
      // show database data
      $arDATA = $this->model->mdl_execute_simple_queries("defaultrooms", null, null, "CLASS_ID, priority");
    }
    
    // load fk values
    $arFkClass = $this->model->mdl_execute_simple_queries("class", null, null, "CLASS_NAME");
    $arFkRoom = $this->model->mdl_execute_simple_queries("room", null, null, "ROOM_NAME");
    
    // generate table with 'defaultroom' data
    $sMain = $this->v_defaultroom->v_defaultroom_getFormHtml($arDATA, $arFkClass, $arFkRoom, $this->val['site'], $sErr, $this->val['do']);
    
    // call function that generates the whole HTML-site
    return $this->v_defaultroom->v_defaultroom_generate_site($sMain);
  }
  
  







  /**
      @brief    validate posted data
      @ingroup  c_defaultroom
      @return   $arSAVE (function-parameter) array containing records to save
      @return   $arDEL (function-parameter) array containing records to delete
      @return   error message
  */
  function c_defaultroom_validateData(&$arSAVE, &$arDEL)
  {
    $sErr = "";
die("check_validate");
    // necessary to identify deleted records: query all 'defaultroom' data
    $arFLD = $this->model->mdl_execute_simple_queries("defaultrooms");
    for ($i=0; $i<count($arFLD); $i++) {$arDEL[$arFLD[$i]['CLASS_ID'].$arFLD[$i]['ROOM_ID']]=true;}
    
    // check all records
    $iCnt = 0;
    unset($arDOPL);
    for ($i=1; $i<count($this->val['data']['ROOM_ID']); $i++)
    {
      $bChange = FALSE;
      $bNewRecord = FALSE;

      // format numbers
      $this->val['data']['CLASS_ID'][$i] = intval($this->val['data']['CLASS_ID'][$i]);
      $this->val['data']['ROOM_ID'][$i] = intval($this->val['data']['ROOM_ID'][$i]);
      $this->val['data']['PRIORITY'][$i] = intval($this->val['data']['PRIORITY'][$i]);

      if ($this->val['data']['DEFAULTROOMS_ID'][$i] != -9999) // existing record
      {
        // query current record
        $arCHK = $this->model->mdl_execute_simple_queries("defaultroom", "defaultroom_id", array(intval($this->val['data']['DEFAULTROOMS_ID'][$i])));

        // record changed?
        if ($this->val['data']['CLASS_ID'][$i] != $arCHK[0]['CLASS_ID']) {$bChange = TRUE;}
        if ($this->val['data']['TERM_ID'][$i] != $arCHK[0]['TERM_ID']) {$bChange = TRUE;}
        if ($this->val['data']['DEFAULTROOMS_TYP'][$i] != $arCHK[0]['DEFAULTROOMS_TYP']) {$bChange = TRUE;}

        $arDate = explode("-", $arCHK[0]['DEFAULTROOMS_BEGIN']);
        if ($this->val['data']['DEFAULTROOMS_BEGIN']['TAG'][$i] != $arDate[2]) {$bChange = TRUE;}
        if ($this->val['data']['DEFAULTROOMS_BEGIN']['MONAT'][$i] != $arDate[1]) {$bChange = TRUE;}
        if ($this->val['data']['DEFAULTROOMS_BEGIN']['JAHR'][$i] != $arDate[0]) {$bChange = TRUE;}

        $arDate = explode("-", $arCHK[0]['DEFAULTROOMS_END']);
        if ($this->val['data']['DEFAULTROOMS_END']['TAG'][$i] != $arDate[2]) {$bChange = TRUE;}
        if ($this->val['data']['DEFAULTROOMS_END']['MONAT'][$i] != $arDate[1]) {$bChange = TRUE;}
        if ($this->val['data']['DEFAULTROOMS_END']['JAHR'][$i] != $arDate[0]) {$bChange = TRUE;}
      } else  // new record
      {
        $bChange = TRUE;
        $bNewRecord = TRUE;
      }

      // validate changed data
      if ($bChange)
      {
        $arCHK = $this->model->mdl_execute_simple_queries("class", "class_id", array($this->val['data']['CLASS_ID'][$i]));
        if (count($arCHK) != 1) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['CLASS_ID'][$i] = $this->language->language_getLabel(23);}
        if ($this->val['data']['DEFAULTROOMS_TYP'][$i] != 0 and $this->val['data']['DEFAULTROOMS_TYP'][$i] != 1) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['DEFAULTROOMS_TYP'][$i] = $this->language->language_getLabel(23);}
        if ($this->val['data']['TERM_ID'][$i] != 1 and $this->val['data']['TERM_ID'][$i] != 2 and $this->val['data']['TERM_ID'][$i] != 3 and $this->val['data']['TERM_ID'][$i] != 4 and $this->val['data']['TERM_ID'][$i] != 5 and $this->val['data']['TERM_ID'][$i] != 6) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['TERM_ID'][$i] = $this->language->language_getLabel(23);}

        if (!@checkdate($this->val['data']['DEFAULTROOMS_BEGIN']['MONAT'][$i], $this->val['data']['DEFAULTROOMS_BEGIN']['TAG'][$i], $this->val['data']['DEFAULTROOMS_BEGIN']['JAHR'][$i])) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['DEFAULTROOMS_BEGIN'][$i] = $this->language->language_getLabel(38);}
        if (!@checkdate($this->val['data']['DEFAULTROOMS_END']['MONAT'][$i], $this->val['data']['DEFAULTROOMS_END']['TAG'][$i], $this->val['data']['DEFAULTROOMS_END']['JAHR'][$i])) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['DEFAULTROOMS_END'][$i] = $this->language->language_getLabel(38);}

        $arSAVE[$iCnt]['DEFAULTROOMS_ID'] = intval($this->val['data']['DEFAULTROOMS_ID'][$i]);
        $arSAVE[$iCnt]['CLASS_ID'] = $this->val['data']['CLASS_ID'][$i];
        $arSAVE[$iCnt]['TERM_ID'] = $this->val['data']['TERM_ID'][$i];
        $arSAVE[$iCnt]['DEFAULTROOMS_BEGIN']['TAG'] = $this->val['data']['DEFAULTROOMS_BEGIN']['TAG'][$i];
        $arSAVE[$iCnt]['DEFAULTROOMS_BEGIN']['MONAT'] = $this->val['data']['DEFAULTROOMS_BEGIN']['MONAT'][$i];
        $arSAVE[$iCnt]['DEFAULTROOMS_BEGIN']['JAHR'] = $this->val['data']['DEFAULTROOMS_BEGIN']['JAHR'][$i];
        $arSAVE[$iCnt]['DEFAULTROOMS_END']['TAG'] = $this->val['data']['DEFAULTROOMS_END']['TAG'][$i];
        $arSAVE[$iCnt]['DEFAULTROOMS_END']['MONAT'] = $this->val['data']['DEFAULTROOMS_END']['MONAT'][$i];
        $arSAVE[$iCnt]['DEFAULTROOMS_END']['JAHR'] = $this->val['data']['DEFAULTROOMS_END']['JAHR'][$i];
        $arSAVE[$iCnt]['DEFAULTROOMS_TYP'] = $this->val['data']['DEFAULTROOMS_TYP'][$i];
        if ($bNewRecord) {$arSAVE[$iCnt]['_STATUS'] = "insert"; } else {$arSAVE[$iCnt]['_STATUS'] = "update"; }
        $iCnt++;
      }

      // necessary to identify deleted records: mark all existing records
      unset($arDEL[$this->val['data']['DEFAULTROOMS_ID'][$i]]);
    }

    // deleting records
    foreach ($arDEL as $pk_value => $bDelete)
    {
      // ---- check values in booking ----
      $iChk = $this->model->mdl_check_foreign_key("curriculum", array("defaultroom_id", $pk_value));
      
      if ($iChk>0)
      {
        // get record
        $arH = $this->model->mdl_execute_simple_queries("defaultroom", "defaultroom_id", array($pk_value));
      
        // add record to data array
        $this->val['data']['DEFAULTROOMS_ID'][] = $pk_value;
        $this->val['data']['CLASS_ID'][] = $arH[0]['CLASS_ID'];
        $this->val['data']['TERM_ID'][] = $arH[0]['TERM_ID'];
        $this->val['data']['DEFAULTROOMS_TYP'][] = $arH[0]['DEFAULTROOMS_TYP'];

        $arDate = explode("-", $arH[0]['DEFAULTROOMS_BEGIN']);
        $this->val['data']['DEFAULTROOMS_BEGIN']['TAG'][] = $arDate[2];
        $this->val['data']['DEFAULTROOMS_BEGIN']['MONAT'][] = $arDate[1];
        $this->val['data']['DEFAULTROOMS_BEGIN']['JAHR'][] = $arDate[0];

        $arDate = explode("-", $arH[0]['DEFAULTROOMS_END']);
        $this->val['data']['DEFAULTROOMS_END']['TAG'][] = $arDate[2];
        $this->val['data']['DEFAULTROOMS_END']['MONAT'][] = $arDate[1];
        $this->val['data']['DEFAULTROOMS_END']['JAHR'][] = $arDate[0];

        // label
        $arL = $this->model->mdl_execute_simple_queries("class", "class_id", array($arH[0]['CLASS_ID']));

        // error message
        $sErr .= str_replace(array("<#NAME#>", "<#ANZAHL#>", "<#FK_NAME#>"), array($arL[0]['CLASS_NAME']."-".$arH[0]['TERM_ID'].". ".$this->language->language_getLabel(39), $iChk, $this->language->language_getLabel(22)) , $this->language->language_getLabel(9));
        
        $arADDED[$pk_value] = "";
      }
    }
    return $sErr;
  }
}

?>