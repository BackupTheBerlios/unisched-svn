<?php

/**

  @defgroup c_class class c_class
  @brief library to interconnect presentation and model for the 'class' web form
  @ingroup CONTROLLER

  <pre>
  --------------------------------------------------------------------------------
  FILE-HISTORY
  --------------------------------------------------------------------------------
  Description
    handle class form
  --------------------------------------------------------------------------------
  date        version   upload    who?      change description
  20.07.2008            no        it05mg1   created
  --------------------------------------------------------------------------------
  </pre>
*/


class c_class
{
  var $v_class; // VIEW
  var $model;
  var $val;
  var $language;
  
  /**
      @brief    constructor (initiate v_class, mdl and language class)
      @ingroup  c_class
      @param    $val  array with all posted parameters
  */
  function c_class($val)
  {
    $this->val = $val;

    $this->v_class = new v_class($val);
    $this->model = new mdl;
    $this->language = new language($val['lang']);
  }









  /**
      @brief    generate form (main part of the application website)
      @ingroup  c_class
      @param    $site current site
      @return   HTML (table with 'class' data)
  */
  function c_class_generateForm()
  {
    if ($this->val['do'] == "save")
    {
      // check saving data
      $sErr = $this->c_class_validateData($arSAVE, $arDEL);

      if ($sErr=="")
      {
        // saving
        for ($i=0; $i<count($arSAVE); $i++)
        {
          // take all classs
          $arField[$i]['NUMBER']['FIELD_ID'] = $arSAVE[$i]['FIELD_ID'];
          $arField[$i]['STRING']['CLASS_NAME'] = $arSAVE[$i]['CLASS_NAME'];
          $arField[$i]['NUMBER']['CLASS_COUNT'] = $arSAVE[$i]['CLASS_COUNT'];
          $arField[$i]['NUMBER']['CLASS_TYP'] = $arSAVE[$i]['CLASS_TYP'];

          // insert data
          if ($this->model->mdl_insert_data($arField, array("CLASS_ID", $arSAVE[$i]['CLASS_ID']),"CLASS", $arSAVE[$i]['_STATUS']) ) {$sErr = $this->language->language_getLabel(8); break;}
        }
        
        if (is_array($arDEL))
        {
          if ($sErr=="")
          {
            foreach($arDEL as $key => $value)
            {
              $this->model->mdl_delete_data(array("CLASS_ID", $key), "CLASS");
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
      for ($i=1; $i<count($this->val['data']['CLASS_ID']); $i++)
      {
        $arDATA[$iCnt]['CLASS_ID'] = $this->val['data']['CLASS_ID'][$i];
        $arDATA[$iCnt]['FIELD_ID'] = $this->val['data']['FIELD_ID'][$i];
        $arDATA[$iCnt]['CLASS_NAME'] = $this->val['data']['CLASS_NAME'][$i];
        $arDATA[$iCnt]['CLASS_COUNT'] = $this->val['data']['CLASS_COUNT'][$i];
        $arDATA[$iCnt]['CLASS_TYP'] = $this->val['data']['CLASS_TYP'][$i];

        $arDATA[$iCnt]['ERR']['FIELD_ID'] = $this->val['data']['ERR']['FIELD_ID'][$i];
        $arDATA[$iCnt]['ERR']['CLASS_NAME'] = $this->val['data']['ERR']['CLASS_NAME'][$i];
        $arDATA[$iCnt]['ERR']['CLASS_COUNT'] = $this->val['data']['ERR']['CLASS_COUNT'][$i];
        $arDATA[$iCnt]['ERR']['CLASS_TYP'] = $this->val['data']['ERR']['CLASS_TYP'][$i];
        $iCnt++;
      }
    } else
    {
      // show database data
      $arDATA = $this->model->mdl_execute_simple_queries("class", null, null, "CLASS_NAME");
    }
    
    // load fk values
    $arFkField = $this->model->mdl_execute_simple_queries("field", null, null, "FIELD_NAME");

    // generate table with 'class' data
    $sMain = $this->v_class->v_class_getFormHtml($arDATA, $arFkField, $this->val['site'], $sErr, $this->val['do']);
    
    // call function that generates the whole HTML-site
    return $this->v_class->v_class_generate_site($sMain);
  }
  
  







  /**
      @brief    validate posted data
      @ingroup  c_class
      @return   $arSAVE (function-parameter) array containing records to save
      @return   $arDEL (function-parameter) array containing records to delete
      @return   error message
  */
  function c_class_validateData(&$arSAVE, &$arDEL)
  {
    $sErr = "";

    // necessary to identify deleted records: query all 'class' data
    $arFLD = $this->model->mdl_execute_simple_queries("class");
    for ($i=0; $i<count($arFLD); $i++) {$arDEL[$arFLD[$i]['CLASS_ID']]=true;}
    
    // check all records
    $iCnt = 0;
    unset($arDOPL);
    for ($i=1; $i<count($this->val['data']['CLASS_ID']); $i++)
    {
      $bChange = FALSE;
      $bNewRecord = FALSE;
      
      // format strings
      $this->val['data']['CLASS_NAME'][$i] = stripslashes($this->val['data']['CLASS_NAME'][$i]);

      // format numbers
      $this->val['data']['FIELD_ID'][$i] = intval($this->val['data']['FIELD_ID'][$i]);
      $this->val['data']['CLASS_COUNT'][$i] = intval($this->val['data']['CLASS_COUNT'][$i]);
      $this->val['data']['CLASS_TYP'][$i] = intval($this->val['data']['CLASS_TYP'][$i]);

      if ($this->val['data']['CLASS_ID'][$i] != -9999) // existing record
      {
        // query current record
        $arCHK = $this->model->mdl_execute_simple_queries("class", "class_id", array(intval($this->val['data']['CLASS_ID'][$i])));

        // record changed?
        if ($this->val['data']['FIELD_ID'][$i] != $arCHK[0]['FIELD_ID']) {$bChange = TRUE;}
        if ($this->val['data']['CLASS_NAME'][$i] != $arCHK[0]['CLASS_NAME']) {$bChange = TRUE;}
        if ($this->val['data']['CLASS_COUNT'][$i] != $arCHK[0]['CLASS_COUNT']) {$bChange = TRUE;}
        if ($this->val['data']['CLASS_TYP'][$i] != $arCHK[0]['CLASS_TYP']) {$bChange = TRUE;}
      
      } else  // new record
      {
        $bChange = TRUE;
        $bNewRecord = TRUE;
      }
      
      // validate changed data
      if ($bChange)
      {
        $arCHK = $this->model->mdl_execute_simple_queries("field", "field_id", array($this->val['data']['FIELD_ID'][$i]));
        if (count($arCHK) != 1) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['FIELD_ID'][$i] = $this->language->language_getLabel(23);}
        if (strlen($this->val['data']['CLASS_NAME'][$i]) < 1 or strlen($this->val['data']['CLASS_NAME'][$i]) > 10) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['CLASS_NAME'][$i] = str_replace(array("<#L1#>", "<#L2#>"), array(1,10), $this->language->language_getLabel(6));}
        if ($this->val['data']['CLASS_COUNT'][$i] < 0 or $this->val['data']['CLASS_COUNT'][$i] > 999) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['CLASS_COUNT'][$i] = str_replace(array("<#N1#>", "<#N2#>"), array(0,999), $this->language->language_getLabel(27));}
        if ($this->val['data']['CLASS_TYP'][$i] != 1 and $this->val['data']['CLASS_TYP'][$i] != 2) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['CLASS_TYP'][$i] = $this->language->language_getLabel(23);}
        
        $arSAVE[$iCnt]['CLASS_ID'] = intval($this->val['data']['CLASS_ID'][$i]);
        $arSAVE[$iCnt]['FIELD_ID'] = $this->val['data']['FIELD_ID'][$i];
        $arSAVE[$iCnt]['CLASS_NAME'] = $this->val['data']['CLASS_NAME'][$i];
        $arSAVE[$iCnt]['CLASS_COUNT'] = $this->val['data']['CLASS_COUNT'][$i];
        $arSAVE[$iCnt]['CLASS_TYP'] = $this->val['data']['CLASS_TYP'][$i];
        if ($bNewRecord) {$arSAVE[$iCnt]['_STATUS'] = "insert"; } else {$arSAVE[$iCnt]['_STATUS'] = "update"; }
        $iCnt++;
      }

      // check doubled records
      if (isset($arDOPL[$this->val['data']['CLASS_NAME'][$i]])) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['CLASS_NAME'][$i] = $this->language->language_getLabel(11);}
      else {$arDOPL[$this->val['data']['CLASS_NAME'][$i]]="";}

      // necessary to identify deleted records: mark all existing records
      unset($arDEL[$this->val['data']['CLASS_ID'][$i]]);
    }

    if (is_array($arDEL))
    {
      // deleting records
      foreach ($arDEL as $pk_value => $bDelete)
      {
        // ---- check values in booking ----
        $iChk = $this->model->mdl_check_foreign_key("curriculum", array("class_id", $pk_value));

        if ($iChk>0)
        {
          // get record
          $arH = $this->model->mdl_execute_simple_queries("class", "class_id", array($pk_value));

          // add record to data array
          $this->val['data']['CLASS_ID'][] = $pk_value;
          $this->val['data']['FIELD_ID'][] = $arH[0]['FIELD_ID'];
          $this->val['data']['CLASS_NAME'][] = $arH[0]['CLASS_NAME'];
          $this->val['data']['CLASS_COUNT'][] = $arH[0]['CLASS_COUNT'];
          $this->val['data']['CLASS_TYP'][] = $arH[0]['CLASS_TYP'];

          // error message
          $sErr .= str_replace(array("<#NAME#>", "<#ANZAHL#>", "<#FK_NAME#>"), array($arH[0]['CLASS_NAME'], $iChk, $this->language->language_getLabel(22)) , $this->language->language_getLabel(9));

          $arADDED[$pk_value] = "";
        }

        // ---- check values in defaultclasss ----
        $iChk = $this->model->mdl_check_foreign_key("CLASS_PERIOD", array("class_id", $pk_value));

        if ($iChk>0)
        {
          // get record
          $arH = $this->model->mdl_execute_simple_queries("class", "class_id", array($pk_value));

          if (!isset($arADDED[$pk_value]))
          {
            // add record to data array
            $this->val['data']['CLASS_ID'][] = $pk_value;
            $this->val['data']['FIELD_ID'][] = $arH[0]['FIELD_ID'];
            $this->val['data']['CLASS_NAME'][] = $arH[0]['CLASS_NAME'];
            $this->val['data']['CLASS_COUNT'][] = $arH[0]['CLASS_COUNT'];
            $this->val['data']['CLASS_TYP'][] = $arH[0]['CLASS_TYP'];
          }

          // error message
          $sErr .= "<br>".str_replace(array("<#NAME#>", "<#ANZAHL#>", "<#FK_NAME#>"), array($arH[0]['CLASS_NAME'], $iChk, $this->language->language_getLabel(34)) , $this->language->language_getLabel(9));
        }
      }
    }
    return $sErr;
  }
}

?>