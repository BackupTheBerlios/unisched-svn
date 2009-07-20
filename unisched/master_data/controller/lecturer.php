<?php

/**

  @defgroup c_lecturer class c_lecturer
  @brief library to interconnect presentation and model for the 'lecturer' web form
  @ingroup CONTROLLER

  <pre>
  --------------------------------------------------------------------------------
  FILE-HISTORY
  --------------------------------------------------------------------------------
  Description
    handle lecturer form
  --------------------------------------------------------------------------------
  date        version   upload    who?      change description
  18.07.2008            no        it05mg1   created
  28.07.2008  1.0.0     yes       it05mg1   upload
  --------------------------------------------------------------------------------
  </pre>
*/


class c_lecturer
{
  var $v_lecturer; // VIEW
  var $model;
  var $val;
  var $language;
  
  /**
      @brief    constructor (initiate v_lecturer, mdl and language class)
      @ingroup  c_lecturer
      @param    $val  array with all posted parameters
  */
  function c_lecturer($val)
  {
    $this->val = $val;

    $this->v_lecturer = new v_lecturer($val);
    $this->model = new mdl;
    $this->language = new language($val['lang']);
  }









  /**
      @brief    generate form (main part of the application website)
      @ingroup  c_lecturer
      @return   HTML (table with 'lecturer' data)
  */
  function c_lecturer_generateForm()
  {
    if ($this->val['do'] == "save")
    {
      // check saving data
      $sErr = $this->c_lecturer_validateData($arSAVE, $arDEL);

      if ($sErr=="")
      {
        // saving
        for ($i=0; $i<count($arSAVE); $i++)
        {
          // take all lecturers
          $arField[$i]['STRING']['LEC_LNAME'] = $arSAVE[$i]['LEC_LNAME'];
          $arField[$i]['STRING']['LEC_GNAME'] = $arSAVE[$i]['LEC_GNAME'];
          $arField[$i]['STRING']['LEC_TIT'] = $arSAVE[$i]['LEC_TIT'];
          $arField[$i]['STRING']['LEC_TEL'] = $arSAVE[$i]['LEC_TEL'];

          // insert data
          if ($this->model->mdl_insert_data($arField, array("LEC_ID", $arSAVE[$i]['LEC_ID']),"LECTURER", $arSAVE[$i]['_STATUS']) ) {$sErr = $this->language->language_getLabel(8); break;}
        }
        
        if (is_array($arDEL))
        {
          if ($sErr=="")
          {
            foreach($arDEL as $key => $value)
            {
              $this->model->mdl_delete_data(array("LEC_ID", $key), "LECTURER");
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
      for ($i=1; $i<count($this->val['data']['LEC_ID']); $i++)
      {
        $arDATA[$iCnt]['LEC_ID'] = $this->val['data']['LEC_ID'][$i];
        $arDATA[$iCnt]['LEC_LNAME'] = $this->val['data']['LEC_LNAME'][$i];
        $arDATA[$iCnt]['LEC_GNAME'] = $this->val['data']['LEC_GNAME'][$i];
        $arDATA[$iCnt]['LEC_TIT'] = $this->val['data']['LEC_TIT'][$i];
        $arDATA[$iCnt]['LEC_TEL'] = $this->val['data']['LEC_TEL'][$i];

        $arDATA[$iCnt]['ERR']['LEC_LNAME'] = $this->val['data']['ERR']['LEC_LNAME'][$i];
        $arDATA[$iCnt]['ERR']['LEC_GNAME'] = $this->val['data']['ERR']['LEC_GNAME'][$i];
        $arDATA[$iCnt]['ERR']['LEC_TIT'] = $this->val['data']['ERR']['LEC_TIT'][$i];
        $arDATA[$iCnt]['ERR']['LEC_TEL'] = $this->val['data']['ERR']['LEC_TEL'][$i];
        $iCnt++;
      }

    } else
    {
      // show database data
      $arDATA = $this->model->mdl_execute_simple_queries("lecturer", null, null, "LEC_LNAME, LEC_GNAME");
    }
    
    // generate table with 'lecturer' data
    $sMain = $this->v_lecturer->v_lecturer_getFormHtml($arDATA, $this->val['site'], $sErr, $this->val['do']);
    
    // call function that generates the whole HTML-site
    return $this->v_lecturer->v_lecturer_generate_site($sMain);
  }
  
  







  /**
      @brief    validate posted data
      @ingroup  c_lecturer
      @return   $arSAVE (function-parameter) array containing records to save
      @return   $arDEL (function-parameter) array containing records to delete
      @return   error message
  */
  function c_lecturer_validateData(&$arSAVE, &$arDEL)
  {
    $sErr = "";

    // necessary to identify deleted records: query all 'lecturer' data
    $arFLD = $this->model->mdl_execute_simple_queries("lecturer");
    for ($i=0; $i<count($arFLD); $i++) {$arDEL[$arFLD[$i]['LEC_ID']]=true;}
    
    // check all records
    $iCnt = 0;
    unset($arDOPL);
    for ($i=1; $i<count($this->val['data']['LEC_ID']); $i++)
    {
      $bChange = FALSE;
      $bNewRecord = FALSE;

      // format strings
      $this->val['data']['LEC_LNAME'][$i] = stripslashes($this->val['data']['LEC_LNAME'][$i]);
      $this->val['data']['LEC_GNAME'][$i] = stripslashes($this->val['data']['LEC_GNAME'][$i]);
      $this->val['data']['LEC_TIT'][$i] = stripslashes($this->val['data']['LEC_TIT'][$i]);
      $this->val['data']['LEC_TEL'][$i] = stripslashes($this->val['data']['LEC_TEL'][$i]);

      if ($this->val['data']['LEC_ID'][$i] != -9999) // existing record
      {
        // query current record
        $arCHK = $this->model->mdl_execute_simple_queries("lecturer", "lec_id", array(intval($this->val['data']['LEC_ID'][$i])));

        // record changed?
        if ($this->val['data']['LEC_LNAME'][$i] != $arCHK[0]['LEC_LNAME']) {$bChange = TRUE;}
        if ($this->val['data']['LEC_GNAME'][$i] != $arCHK[0]['LEC_GNAME']) {$bChange = TRUE;}
        if ($this->val['data']['LEC_TIT'][$i] != $arCHK[0]['LEC_TIT']) {$bChange = TRUE;}
        if ($this->val['data']['LEC_TEL'][$i] != $arCHK[0]['LEC_TEL']) {$bChange = TRUE;}
      
      } else  // new record
      {
        $bChange = TRUE;
        $bNewRecord = TRUE;
      }
      
      // validate changed data
      if ($bChange)
      {
        if (strlen($this->val['data']['LEC_LNAME'][$i]) < 1 or strlen($this->val['data']['LEC_LNAME'][$i]) > 30) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['LEC_LNAME'][$i] = str_replace(array("<#L1#>", "<#L2#>"), array(1,30), $this->language->language_getLabel(6));}
        if (strlen($this->val['data']['LEC_GNAME'][$i]) < 1 or strlen($this->val['data']['LEC_GNAME'][$i]) > 30) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['LEC_GNAME'][$i] = str_replace(array("<#L1#>", "<#L2#>"), array(1,30), $this->language->language_getLabel(6));}
        if (strlen($this->val['data']['LEC_TIT'][$i]) > 10) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['LEC_TIT'][$i] = str_replace(array("<#L1#>", "<#L2#>"), array(0,10), $this->language->language_getLabel(6));}
        if (strlen($this->val['data']['LEC_TEL'][$i]) > 20) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['LEC_TEL'][$i] = str_replace(array("<#L1#>", "<#L2#>"), array(0,20), $this->language->language_getLabel(6));}
        
        $arSAVE[$iCnt]['LEC_ID'] = intval($this->val['data']['LEC_ID'][$i]);
        $arSAVE[$iCnt]['LEC_LNAME'] = $this->val['data']['LEC_LNAME'][$i];
        $arSAVE[$iCnt]['LEC_GNAME'] = $this->val['data']['LEC_GNAME'][$i];
        $arSAVE[$iCnt]['LEC_TIT'] = $this->val['data']['LEC_TIT'][$i];
        $arSAVE[$iCnt]['LEC_TEL'] = $this->val['data']['LEC_TEL'][$i];
        if ($bNewRecord) {$arSAVE[$iCnt]['_STATUS'] = "insert"; } else {$arSAVE[$iCnt]['_STATUS'] = "update"; }
        $iCnt++;
      }

      // check doubled records
      if (isset($arDOPL[$this->val['data']['LEC_LNAME'][$i].$this->val['data']['LEC_GNAME'][$i]]))
           {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['LEC_LNAME'][$i] = $this->language->language_getLabel(16); $this->val['data']['ERR']['LEC_GNAME'][$i] = $this->language->language_getLabel(16);}
      else {$arDOPL[$this->val['data']['LEC_LNAME'][$i].$this->val['data']['LEC_GNAME'][$i]]="";}

      // necessary to identify deleted records: mark all existing records
      unset($arDEL[$this->val['data']['LEC_ID'][$i]]);
    }

    // deleting records
    if (is_array($arDEL))
    {
      foreach ($arDEL as $pk_value => $bDelete)
      {
        $iChk = $this->model->mdl_check_foreign_key("curriculum", array("lec_id", $pk_value));

        if ($iChk>0)
        {
          // get record
          $arH = $this->model->mdl_execute_simple_queries("lecturer", "lec_id", array($pk_value));

          // add record to data array
          $this->val['data']['LEC_ID'][] = $pk_value;
          $this->val['data']['LEC_LNAME'][] = $arH[0]['LEC_LNAME'];
          $this->val['data']['LEC_GNAME'][] = $arH[0]['LEC_GNAME'];
          $this->val['data']['LEC_TIT'][] = $arH[0]['LEC_TIT'];
          $this->val['data']['LEC_TEL'][] = $arH[0]['LEC_TEL'];

          // error message
          $sErr .= str_replace(array("<#NAME#>", "<#ANZAHL#>", "<#FK_NAME#>"), array($arH[0]['LEC_GNAME']." ".$arH[0]['LEC_LNAME'], $iChk, $this->language->language_getLabel(22)) , $this->language->language_getLabel(9));

        }
      }
    }
    return $sErr;
  }
}

?>