<?php

/**

  @defgroup c_class_period class c_class_period
  @brief library to interconnect presentation and model for the 'class_period' web form
  @ingroup CONTROLLER

  <pre>
  --------------------------------------------------------------------------------
  FILE-HISTORY
  --------------------------------------------------------------------------------
  Description
    handle class_period form
  --------------------------------------------------------------------------------
  date        version   upload    who?      change description
  20.07.2008            no        it05mg1   created
  --------------------------------------------------------------------------------
  </pre>
*/


class c_class_period
{
  var $v_class_period; // VIEW
  var $model;
  var $val;
  var $language;
  
  /**
      @brief    constructor (initiate v_class_period, mdl and language class)
      @ingroup  c_class_period
      @param    $val  array with all posted parameters
  */
  function c_class_period($val)
  {
    $this->val = $val;

    $this->v_class_period = new v_class_period($val);
    $this->model = new mdl;
    $this->language = new language($val['lang']);
  }









  /**
      @brief    generate form (main part of the application website)
      @ingroup  c_class_period
      @param    $site current site
      @return   HTML (table with 'class_period' data)
  */
  function c_class_period_generateForm()
  {
    if ($this->val['do'] == "save")
    {
      // check saving data
      $sErr = $this->c_class_period_validateData($arSAVE, $arDEL);

      if ($sErr=="")
      {
        // saving
        for ($i=0; $i<count($arSAVE); $i++)
        {
          // take all class_periods
          $arField[$i]['NUMBER']['CLASS_ID'] = $arSAVE[$i]['CLASS_ID'];
          $arField[$i]['NUMBER']['TERM_ID'] = $arSAVE[$i]['TERM_ID'];
          $arField[$i]['DATE']['CLASS_PERIOD_BEGIN'] = $arSAVE[$i]['CLASS_PERIOD_BEGIN'];
          $arField[$i]['DATE']['CLASS_PERIOD_END'] = $arSAVE[$i]['CLASS_PERIOD_END'];
          $arField[$i]['NUMBER']['CLASS_PERIOD_TYP'] = $arSAVE[$i]['CLASS_PERIOD_TYP'];

          // insert data
          if ($this->model->mdl_insert_data($arField, array("CLASS_PERIOD_ID", $arSAVE[$i]['CLASS_PERIOD_ID']),"CLASS_PERIOD", $arSAVE[$i]['_STATUS']) ) {$sErr = $this->language->language_getLabel(8); break;}
        }
        
        if (is_array($arDEL))
        {
          if ($sErr=="")
          {
            foreach($arDEL as $key => $value)
            {
              $this->model->mdl_delete_data(array("CLASS_PERIOD_ID", $key), "CLASS_PERIOD");
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
      for ($i=1; $i<count($this->val['data']['CLASS_PERIOD_ID']); $i++)
      {
        $arDATA[$iCnt]['CLASS_PERIOD_ID'] = $this->val['data']['CLASS_PERIOD_ID'][$i];
        $arDATA[$iCnt]['CLASS_ID'] = $this->val['data']['CLASS_ID'][$i];
        $arDATA[$iCnt]['TERM_ID'] = $this->val['data']['TERM_ID'][$i];
        $arDATA[$iCnt]['CLASS_PERIOD_BEGIN'] = $this->val['data']['CLASS_PERIOD_BEGIN']['JAHR'][$i]."-".$this->val['data']['CLASS_PERIOD_BEGIN']['MONAT'][$i]."-".$this->val['data']['CLASS_PERIOD_BEGIN']['TAG'][$i];
        $arDATA[$iCnt]['CLASS_PERIOD_END'] = $this->val['data']['CLASS_PERIOD_END']['JAHR'][$i]."-".$this->val['data']['CLASS_PERIOD_END']['MONAT'][$i]."-".$this->val['data']['CLASS_PERIOD_END']['TAG'][$i];
        $arDATA[$iCnt]['CLASS_PERIOD_TYP'] = $this->val['data']['CLASS_PERIOD_TYP'][$i];

        $arDATA[$iCnt]['ERR']['CLASS_ID'] = $this->val['data']['ERR']['CLASS_ID'][$i];
        $arDATA[$iCnt]['ERR']['TERM_ID'] = $this->val['data']['ERR']['TERM_ID'][$i];
        $arDATA[$iCnt]['ERR']['CLASS_PERIOD_BEGIN'] = $this->val['data']['ERR']['CLASS_PERIOD_BEGIN'][$i];
        $arDATA[$iCnt]['ERR']['CLASS_PERIOD_END'] = $this->val['data']['ERR']['CLASS_PERIOD_END'][$i];
        $arDATA[$iCnt]['ERR']['CLASS_PERIOD_TYP'] = $this->val['data']['ERR']['CLASS_PERIOD_TYP'][$i];
        $iCnt++;
      }
    } else
    {
      // show database data
      $arDATA = $this->model->mdl_execute_simple_queries("class_period", null, null, "CLASS_ID, TERM_ID, CLASS_PERIOD_BEGIN");
    }
    
    // load fk values
    $arFkField = $this->model->mdl_execute_simple_queries("class", null, null, "CLASS_NAME");

    // generate table with 'class_period' data
    $sMain = $this->v_class_period->v_class_period_getFormHtml($arDATA, $arFkField, $this->val['site'], $sErr, $this->val['do']);
    
    // call function that generates the whole HTML-site
    return $this->v_class_period->v_class_period_generate_site($sMain);
  }
  
  







  /**
      @brief    validate posted data
      @ingroup  c_class_period
      @return   $arSAVE (function-parameter) array containing records to save
      @return   $arDEL (function-parameter) array containing records to delete
      @return   error message
  */
  function c_class_period_validateData(&$arSAVE, &$arDEL)
  {
    $sErr = "";

    // necessary to identify deleted records: query all 'class_period' data
    $arFLD = $this->model->mdl_execute_simple_queries("class_period");
    for ($i=0; $i<count($arFLD); $i++) {$arDEL[$arFLD[$i]['CLASS_PERIOD_ID']]=true;}
    
    // check all records
    $iCnt = 0;
    unset($arDOPL);
    for ($i=1; $i<count($this->val['data']['CLASS_PERIOD_ID']); $i++)
    {
      $bChange = FALSE;
      $bNewRecord = FALSE;

      // format date
      $this->val['data']['CLASS_PERIOD_BEGIN']['TAG'][$i] = stripslashes($this->val['data']['CLASS_PERIOD_BEGIN']['TAG'][$i]);
      $this->val['data']['CLASS_PERIOD_BEGIN']['MONAT'][$i] = stripslashes($this->val['data']['CLASS_PERIOD_BEGIN']['MONAT'][$i]);
      $this->val['data']['CLASS_PERIOD_BEGIN']['JAHR'][$i] = stripslashes($this->val['data']['CLASS_PERIOD_BEGIN']['JAHR'][$i]);
      $this->val['data']['CLASS_PERIOD_END']['TAG'][$i] = stripslashes($this->val['data']['CLASS_PERIOD_END']['TAG'][$i]);
      $this->val['data']['CLASS_PERIOD_END']['MONAT'][$i] = stripslashes($this->val['data']['CLASS_PERIOD_END']['MONAT'][$i]);
      $this->val['data']['CLASS_PERIOD_END']['JAHR'][$i] = stripslashes($this->val['data']['CLASS_PERIOD_END']['JAHR'][$i]);
      
      // format numbers
      $this->val['data']['CLASS_ID'][$i] = intval($this->val['data']['CLASS_ID'][$i]);
      $this->val['data']['TERM_ID'][$i] = intval($this->val['data']['TERM_ID'][$i]);
      $this->val['data']['CLASS_PERIOD_TYP'][$i] = intval($this->val['data']['CLASS_PERIOD_TYP'][$i]);

      if ($this->val['data']['CLASS_PERIOD_ID'][$i] != -9999) // existing record
      {
        // query current record
        $arCHK = $this->model->mdl_execute_simple_queries("class_period", "class_period_id", array(intval($this->val['data']['CLASS_PERIOD_ID'][$i])));

        // record changed?
        if ($this->val['data']['CLASS_ID'][$i] != $arCHK[0]['CLASS_ID']) {$bChange = TRUE;}
        if ($this->val['data']['TERM_ID'][$i] != $arCHK[0]['TERM_ID']) {$bChange = TRUE;}
        if ($this->val['data']['CLASS_PERIOD_TYP'][$i] != $arCHK[0]['CLASS_PERIOD_TYP']) {$bChange = TRUE;}

        $arDate = explode("-", $arCHK[0]['CLASS_PERIOD_BEGIN']);
        if ($this->val['data']['CLASS_PERIOD_BEGIN']['TAG'][$i] != $arDate[2]) {$bChange = TRUE;}
        if ($this->val['data']['CLASS_PERIOD_BEGIN']['MONAT'][$i] != $arDate[1]) {$bChange = TRUE;}
        if ($this->val['data']['CLASS_PERIOD_BEGIN']['JAHR'][$i] != $arDate[0]) {$bChange = TRUE;}

        $arDate = explode("-", $arCHK[0]['CLASS_PERIOD_END']);
        if ($this->val['data']['CLASS_PERIOD_END']['TAG'][$i] != $arDate[2]) {$bChange = TRUE;}
        if ($this->val['data']['CLASS_PERIOD_END']['MONAT'][$i] != $arDate[1]) {$bChange = TRUE;}
        if ($this->val['data']['CLASS_PERIOD_END']['JAHR'][$i] != $arDate[0]) {$bChange = TRUE;}
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
        if ($this->val['data']['CLASS_PERIOD_TYP'][$i] != 0 and $this->val['data']['CLASS_PERIOD_TYP'][$i] != 1) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['CLASS_PERIOD_TYP'][$i] = $this->language->language_getLabel(23);}
        if ($this->val['data']['TERM_ID'][$i] != 1 and $this->val['data']['TERM_ID'][$i] != 2 and $this->val['data']['TERM_ID'][$i] != 3 and $this->val['data']['TERM_ID'][$i] != 4 and $this->val['data']['TERM_ID'][$i] != 5 and $this->val['data']['TERM_ID'][$i] != 6) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['TERM_ID'][$i] = $this->language->language_getLabel(23);}

        if (!@checkdate($this->val['data']['CLASS_PERIOD_BEGIN']['MONAT'][$i], $this->val['data']['CLASS_PERIOD_BEGIN']['TAG'][$i], $this->val['data']['CLASS_PERIOD_BEGIN']['JAHR'][$i])) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['CLASS_PERIOD_BEGIN'][$i] = $this->language->language_getLabel(38);}
        if (!@checkdate($this->val['data']['CLASS_PERIOD_END']['MONAT'][$i], $this->val['data']['CLASS_PERIOD_END']['TAG'][$i], $this->val['data']['CLASS_PERIOD_END']['JAHR'][$i])) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['CLASS_PERIOD_END'][$i] = $this->language->language_getLabel(38);}

        if ($this->val['data']['CLASS_PERIOD_END']['JAHR'][$i].$this->val['data']['CLASS_PERIOD_END']['MONAT'][$i].$this->val['data']['CLASS_PERIOD_END']['TAG'][$i] < $this->val['data']['CLASS_PERIOD_BEGIN']['JAHR'][$i].$this->val['data']['CLASS_PERIOD_BEGIN']['MONAT'][$i].$this->val['data']['CLASS_PERIOD_BEGIN']['TAG'][$i]) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['CLASS_PERIOD_BEGIN'][$i] = $this->language->language_getLabel(45);$this->val['data']['ERR']['CLASS_PERIOD_END'][$i] = $this->language->language_getLabel(45);}

        $arSAVE[$iCnt]['CLASS_PERIOD_ID'] = intval($this->val['data']['CLASS_PERIOD_ID'][$i]);
        $arSAVE[$iCnt]['CLASS_ID'] = $this->val['data']['CLASS_ID'][$i];
        $arSAVE[$iCnt]['TERM_ID'] = $this->val['data']['TERM_ID'][$i];
        $arSAVE[$iCnt]['CLASS_PERIOD_BEGIN']['TAG'] = $this->val['data']['CLASS_PERIOD_BEGIN']['TAG'][$i];
        $arSAVE[$iCnt]['CLASS_PERIOD_BEGIN']['MONAT'] = $this->val['data']['CLASS_PERIOD_BEGIN']['MONAT'][$i];
        $arSAVE[$iCnt]['CLASS_PERIOD_BEGIN']['JAHR'] = $this->val['data']['CLASS_PERIOD_BEGIN']['JAHR'][$i];
        $arSAVE[$iCnt]['CLASS_PERIOD_END']['TAG'] = $this->val['data']['CLASS_PERIOD_END']['TAG'][$i];
        $arSAVE[$iCnt]['CLASS_PERIOD_END']['MONAT'] = $this->val['data']['CLASS_PERIOD_END']['MONAT'][$i];
        $arSAVE[$iCnt]['CLASS_PERIOD_END']['JAHR'] = $this->val['data']['CLASS_PERIOD_END']['JAHR'][$i];
        $arSAVE[$iCnt]['CLASS_PERIOD_TYP'] = $this->val['data']['CLASS_PERIOD_TYP'][$i];
        if ($bNewRecord) {$arSAVE[$iCnt]['_STATUS'] = "insert"; } else {$arSAVE[$iCnt]['_STATUS'] = "update"; }
        $iCnt++;
      }

      // necessary to identify deleted records: mark all existing records
      unset($arDEL[$this->val['data']['CLASS_PERIOD_ID'][$i]]);
    }

    // deleting records
    foreach ($arDEL as $pk_value => $bDelete)
    {
      // ---- check values in booking ----
      $iChk = $this->model->mdl_check_foreign_key("curriculum", array("class_period_id", $pk_value));
      
      if ($iChk>0)
      {
        // get record
        $arH = $this->model->mdl_execute_simple_queries("class_period", "class_period_id", array($pk_value));
      
        // add record to data array
        $this->val['data']['CLASS_PERIOD_ID'][] = $pk_value;
        $this->val['data']['CLASS_ID'][] = $arH[0]['CLASS_ID'];
        $this->val['data']['TERM_ID'][] = $arH[0]['TERM_ID'];
        $this->val['data']['CLASS_PERIOD_TYP'][] = $arH[0]['CLASS_PERIOD_TYP'];

        $arDate = explode("-", $arH[0]['CLASS_PERIOD_BEGIN']);
        $this->val['data']['CLASS_PERIOD_BEGIN']['TAG'][] = $arDate[2];
        $this->val['data']['CLASS_PERIOD_BEGIN']['MONAT'][] = $arDate[1];
        $this->val['data']['CLASS_PERIOD_BEGIN']['JAHR'][] = $arDate[0];

        $arDate = explode("-", $arH[0]['CLASS_PERIOD_END']);
        $this->val['data']['CLASS_PERIOD_END']['TAG'][] = $arDate[2];
        $this->val['data']['CLASS_PERIOD_END']['MONAT'][] = $arDate[1];
        $this->val['data']['CLASS_PERIOD_END']['JAHR'][] = $arDate[0];

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