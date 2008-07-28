<?php

/**

  @defgroup c_field class c_field
  @brief library to interconnect presentation and model for the 'field' web form
  @ingroup CONTROLLER

  <pre>
  --------------------------------------------------------------------------------
  FILE-HISTORY
  --------------------------------------------------------------------------------
  Description
    handle field form
  --------------------------------------------------------------------------------
  date        version   upload    who?      change description
  10.07.2008            no        it05mg1   created
  28.07.2008  1.0.0     yes       it05mg1   upload
  --------------------------------------------------------------------------------
  </pre>
*/


class c_field
{
  var $v_field; // VIEW
  var $model;
  var $val;
  var $language;
  
  /**
      @brief    constructor (initiate v_field, mdl and language class)
      @ingroup  c_field
      @param    $val  array with all posted parameters
  */
  function c_field($val)
  {
    $this->val = $val;

    $this->v_field = new v_field($val);
    $this->model = new mdl;
    $this->language = new language($val['lang']);
  }









  /**
      @brief    generate form (main part of the application website)
      @ingroup  c_field
      @param    $site current site
      @return   HTML (table with 'field' data)
  */
  function c_field_generateForm()
  {
    if ($this->val['do'] == "save")
    {
      // check saving data
      $sErr = $this->c_field_validateData($arSAVE, $arDEL);

      if ($sErr=="")
      {
        // saving
        for ($i=0; $i<count($arSAVE); $i++)
        {
          // take all fields
          $arField[$i]['STRING']['FIELD_NAME'] = $arSAVE[$i]['FIELD_NAME'];

          // insert data
          if ($this->model->mdl_insert_data($arField, array("FIELD_ID", $arSAVE[$i]['FIELD_ID']),"FIELD", $arSAVE[$i]['_STATUS']) ) {$sErr = $this->language->language_getLabel(8); break;}
        }
        
        if (is_array($arDEL))
        {
          if ($sErr=="")
          {
            foreach($arDEL as $key => $value)
            {
              $this->model->mdl_delete_data(array("FIELD_ID", $key), "FIELD");
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
      for ($i=1; $i<count($this->val['data']['FIELD_ID']); $i++)
      {
        $arDATA[$iCnt]['FIELD_ID'] = $this->val['data']['FIELD_ID'][$i];
        $arDATA[$iCnt]['FIELD_NAME'] = $this->val['data']['FIELD_NAME'][$i];
        $arDATA[$iCnt]['ERR']['FIELD_NAME'] = $this->val['data']['ERR']['FIELD_NAME'][$i];
        $iCnt++;
      }

    } else
    {
      // show database data
      $arDATA = $this->model->mdl_execute_simple_queries("field", null, null, "FIELD_NAME");
    }
    
    // generate table with 'field' data
    $sMain = $this->v_field->v_field_getFormHtml($arDATA, $this->val['site'], $sErr, $this->val['do']);
    
    // call function that generates the whole HTML-site
    return $this->v_field->v_field_generate_site($sMain);
  }
  
  







  /**
      @brief    validate posted data
      @ingroup  c_field
      @return   $arSAVE (function-parameter) array containing records to save
      @return   $arDEL (function-parameter) array containing records to delete
      @return   error message
  */
  function c_field_validateData(&$arSAVE, &$arDEL)
  {
    $sErr = "";

    // necessary to identify deleted records: query all 'field' data
    $arFLD = $this->model->mdl_execute_simple_queries("field");
    for ($i=0; $i<count($arFLD); $i++) {$arDEL[$arFLD[$i]['FIELD_ID']]=true;}
    
    // check all records
    $iCnt = 0;
    unset($arDOPL);
    for ($i=1; $i<count($this->val['data']['FIELD_ID']); $i++)
    {
      $bChange = FALSE;
      $bNewRecord = FALSE;

      // format strings
      $this->val['data']['FIELD_NAME'][$i] = stripslashes($this->val['data']['FIELD_NAME'][$i]);

      if ($this->val['data']['FIELD_ID'][$i] != -9999) // existing record
      {
        // query current record
        $arCHK = $this->model->mdl_execute_simple_queries("field", "field_id", array(intval($this->val['data']['FIELD_ID'][$i])));

        // record changed?
        if ($this->val['data']['FIELD_NAME'][$i] != $arCHK[0]['FIELD_NAME']) {$bChange = TRUE;}
      
      } else  // new record
      {
        $bChange = TRUE;
        $bNewRecord = TRUE;
      }
      
      // validate changed data
      if ($bChange)
      {
        if (strlen($this->val['data']['FIELD_NAME'][$i]) < 1 or strlen($this->val['data']['FIELD_NAME'][$i]) > 30) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['FIELD_NAME'][$i] = str_replace(array("<#L1#>", "<#L2#>"), array(1, 30), $this->language->language_getLabel(6));}
        
        $arSAVE[$iCnt]['FIELD_ID'] = intval($this->val['data']['FIELD_ID'][$i]);
        $arSAVE[$iCnt]['FIELD_NAME'] = $this->val['data']['FIELD_NAME'][$i];
        if ($bNewRecord) {$arSAVE[$iCnt]['_STATUS'] = "insert"; } else {$arSAVE[$iCnt]['_STATUS'] = "update"; }
        $iCnt++;
      }

      // check doubled records
      if (isset($arDOPL[$this->val['data']['FIELD_NAME'][$i]])) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['FIELD_NAME'][$i] = $this->language->language_getLabel(11);} else {$arDOPL[$this->val['data']['FIELD_NAME'][$i]]="";}

      // necessary to identify deleted records: mark all existing records
      unset($arDEL[$this->val['data']['FIELD_ID'][$i]]);
    }

    // deleting records
    if (is_array($arDEL))
    {
      foreach ($arDEL as $pk_value => $bDelete)
      {
        $iChk = $this->model->mdl_check_foreign_key("class", array("field_id", $pk_value));

        if ($iChk>0)
        {
          // get record
          $arH = $this->model->mdl_execute_simple_queries("field", "field_id", array($pk_value));

          // add record to data array
          $this->val['data']['FIELD_ID'][] = $pk_value;
          $this->val['data']['FIELD_NAME'][] = $arH[0]['FIELD_NAME'];

          // error message
          $sErr .= str_replace(array("<#NAME#>", "<#ANZAHL#>", "<#FK_NAME#>"), array($arH[0]['FIELD_NAME'], $iChk, $this->language->language_getLabel(12)) , $this->language->language_getLabel(9));
        }
      }
    }
    return $sErr;
  }
}

?>