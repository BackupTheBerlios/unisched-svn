<?php

/**

  @defgroup c_subject class c_subject
  @brief library to interconnect presentation and model for the 'subject' web form
  @ingroup CONTROLLER

  <pre>
  --------------------------------------------------------------------------------
  FILE-HISTORY
  --------------------------------------------------------------------------------
  Description
    handle subject form
  --------------------------------------------------------------------------------
  date        version   upload    who?      change description
  18.07.2008            no        it05mg1   created
  --------------------------------------------------------------------------------
  </pre>
*/


class c_subject
{
  var $v_subject; // VIEW
  var $model;
  var $val;
  var $language;
  
  /**
      @brief    constructor (initiate v_subject, mdl and language class)
      @ingroup  c_subject
      @param    $val  array with all posted parameters
  */
  function c_subject($val)
  {
    $this->val = $val;

    $this->v_subject = new v_subject($val);
    $this->model = new mdl;
    $this->language = new language($val['lang']);
  }









  /**
      @brief    generate form (main part of the application website)
      @ingroup  c_subject
      @param    $site current site
      @return   HTML (table with 'subject' data)
  */
  function c_subject_generateForm()
  {
    // ---- save lectures and examinations ----
    if ($this->val['do'] == "save_ve")
    {
      // check saving data
      $sErr = $this->c_subject_validateData($arSAVE, $arDEL);

      if ($sErr=="")
      {
        // saving
        for ($i=0; $i<count($arSAVE); $i++)
        {
          // take all subjects
          $arField[$i]['STRING']['SUB_NAME'] = $arSAVE[$i]['SUB_NAME'];
          $arField[$i]['STRING']['SUB_LONG_NAME'] = $arSAVE[$i]['SUB_LONG_NAME'];
          $arField[$i]['NUMBER']['SUB_TYP'] = $arSAVE[$i]['SUB_TYP'];
          $arField[$i]['NUMBER']['MOD_ID'] = $arSAVE[$i]['MOD_ID'];

          // insert data
          if ($this->model->mdl_insert_data($arField, array("SUB_ID", $arSAVE[$i]['SUB_ID']),"SUBJECT", $arSAVE[$i]['_STATUS']) ) {$sErr = $this->language->language_getLabel(8); break;}
        }
        
        if (is_array($arDEL))
        {
          if ($sErr=="")
          {
            foreach($arDEL as $key => $value)
            {
              $this->model->mdl_delete_data(array("SUB_ID", $key), "SUBJECT");
            }
          }
        }
      }
    }


    // ---- save moduls ----
    if ($this->val['do'] == "save_mod")
    {
      // check saving data
      $sErr = $this->c_subject_validateModData($arSAVE, $arDEL); // $arSAVE and $arDEL are 'return variables'

      if ($sErr=="")
      {
        // saving
        for ($i=0; $i<count($arSAVE); $i++)
        {
          // take all subjects
          $arField[$i]['STRING']['SUB_NAME'] = $arSAVE[$i]['SUB_NAME'];
          $arField[$i]['STRING']['SUB_LONG_NAME'] = $arSAVE[$i]['SUB_LONG_NAME'];
          $arField[$i]['NUMBER']['SUB_TYP'] = $arSAVE[$i]['SUB_TYP'];
          $arField[$i]['NUMBER']['MOD_ID'] = $arSAVE[$i]['MOD_ID'];

          // insert data
          if ($this->model->mdl_insert_data($arField, array("SUB_ID", $arSAVE[$i]['SUB_ID']),"SUBJECT", $arSAVE[$i]['_STATUS']) ) {$sErr = $this->language->language_getLabel(8); break;}
        }

        if (is_array($arDEL))
        {
          if ($sErr=="")
          {
            foreach($arDEL as $key => $value)
            {
              $this->model->mdl_delete_data(array("SUB_ID", $key), "SUBJECT");
            }
          }
        }
      }
    }

    // ---- error? ----
    if ($sErr!="")
    {
      if ($this->val['do'] == "save_ve")
      {
        // show form data (lectures and examination)
        $iCnt = 0;
        for ($i=1; $i<count($this->val['data']['SUB_ID']); $i++)
        {
          $arDATA[$iCnt]['SUB_ID'] = $this->val['data']['SUB_ID'][$i];
          $arDATA[$iCnt]['SUB_NAME'] = $this->val['data']['SUB_NAME'][$i];
          $arDATA[$iCnt]['SUB_LONG_NAME'] = $this->val['data']['SUB_LONG_NAME'][$i];
          $arDATA[$iCnt]['SUB_TYP'] = $this->val['data']['SUB_TYP'][$i];

          $arDATA[$iCnt]['ERR']['SUB_NAME'] = $this->val['data']['ERR']['SUB_NAME'][$i];
          $arDATA[$iCnt]['ERR']['SUB_LONG_NAME'] = $this->val['data']['ERR']['SUB_LONG_NAME'][$i];
          $arDATA[$iCnt]['ERR']['SUB_TYP'] = $this->val['data']['ERR']['SUB_TYP'][$i];
          $iCnt++;
        }
        
        // show database data (moduls)
        $arM = $this->c_subject_getModData();
      } else
      {
        // show form data (moduls)
        $iCnt = 0;
        foreach($this->val['data'] as $key => $arVAL)
        {
          if ($key != -9999)
          {
            for ($i=1; $i<count($arVAL['SUB_ID']); $i++)
            {
              $arM[$key]['SUB_ID'][] = $arVAL['SUB_ID'][$i];
              $arM[$key]['SUB_NAME'][] = $arVAL['SUB_NAME'][$i];
              $arM[$key]['SUB_LONG_NAME'][] = $arVAL['SUB_LONG_NAME'][$i];
              $arM[$key]['SUB_TYP'] = $arVAL['SUB_TYP'][$i];
              
              $arM[$key]['ERR']['SUB_NAME'][] = $this->val['data'][$key]['ERR']['SUB_NAME'][$i];
              $arM[$key]['ERR']['SUB_LONG_NAME'][] = $this->val['data'][$key]['ERR']['SUB_LONG_NAME'][$i];
              $arM[$key]['ERR']['SUB_TYP'] = $this->val['data'][$key]['ERR']['SUB_TYP'];
            }
          }
        }

        // show database data (lecutres and examination)
        $arDATA = $this->c_subject_getVeData();
      }

    } else
    {
      // show database data (lecture and examination)
      $arDATA = $this->c_subject_getVeData();
      
      // show database data (moduls)
      $arM = $this->c_subject_getModData();
    }
    
    // generate table with 'subject' data
    $sMain = $this->v_subject->v_subject_getFormHtml($arDATA, $arM, $this->val['site'], $sErr, $this->val['do']);
    
    // call function that generates the whole HTML-site
    return $this->v_subject->v_subject_generate_site($sMain);
  }
  
  







  /**
      @brief    validate posted data
      @ingroup  c_subject
      @return   $arSAVE (function-parameter) array containing records to save
      @return   $arDEL (function-parameter) array containing records to delete
      @return   error message
  */
  function c_subject_validateData(&$arSAVE, &$arDEL)
  {
    $sErr = "";

    // necessary to identify deleted records: query all 'subject' data
    $arFLD = $this->model->mdl_execute_simple_queries("subject", null, null, null, "MOD_ID is null");
    for ($i=0; $i<count($arFLD); $i++) {$arDEL[$arFLD[$i]['SUB_ID']]=true;}
    
    // check all records
    $iCnt = 0;
    unset($arDOPL);
    for ($i=1; $i<count($this->val['data']['SUB_ID']); $i++)
    {
      $bChange = FALSE;
      $bNewRecord = FALSE;

      // format strings
      $this->val['data']['SUB_NAME'][$i] = stripslashes($this->val['data']['SUB_NAME'][$i]);
      $this->val['data']['SUB_LONG_NAME'][$i] = stripslashes($this->val['data']['SUB_LONG_NAME'][$i]);

      // format integers
      $this->val['data']['SUB_TYP'][$i] = intval($this->val['data']['SUB_TYP'][$i]);

      if ($this->val['data']['SUB_ID'][$i] != -9999) // existing record
      {
        // query current record
        $arCHK = $this->model->mdl_execute_simple_queries("subject", "sub_id", array(intval($this->val['data']['SUB_ID'][$i])));

        // record changed?
        if ($this->val['data']['SUB_NAME'][$i] != $arCHK[0]['SUB_NAME']) {$bChange = TRUE;}
        if ($this->val['data']['SUB_LONG_NAME'][$i] != $arCHK[0]['SUB_LONG_NAME']) {$bChange = TRUE;}
        if ($this->val['data']['SUB_TYP'][$i] != $arCHK[0]['SUB_TYP']) {$bChange = TRUE;}
      
      } else  // new record
      {
        $bChange = TRUE;
        $bNewRecord = TRUE;
      }
      
      // validate changed data
      if ($bChange)
      {
        if (strlen($this->val['data']['SUB_NAME'][$i]) < 1 or strlen($this->val['data']['SUB_NAME'][$i]) > 8) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['SUB_NAME'][$i] = str_replace(array("<#L1#>","<#L2#>"), array(1,8), $this->language->language_getLabel(6));}
        if (strlen($this->val['data']['SUB_LONG_NAME'][$i]) < 1 or strlen($this->val['data']['SUB_LONG_NAME'][$i]) > 30) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['SUB_LONG_NAME'][$i] = str_replace(array("<#L1#>","<#L2#>"), array(1,30), $this->language->language_getLabel(6));}
        if (intval($this->val['data']['SUB_TYP'][$i]) != 1 && intval($this->val['data']['SUB_TYP'][$i]) != 2) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['SUB_TYP'][$i] = $this->language->language_getLabel(23);}
        
        $arSAVE[$iCnt]['SUB_ID'] = intval($this->val['data']['SUB_ID'][$i]);
        $arSAVE[$iCnt]['SUB_NAME'] = $this->val['data']['SUB_NAME'][$i];
        $arSAVE[$iCnt]['SUB_LONG_NAME'] = $this->val['data']['SUB_LONG_NAME'][$i];
        $arSAVE[$iCnt]['SUB_TYP'] = $this->val['data']['SUB_TYP'][$i];
        $arSAVE[$iCnt]['MOD_ID'] = "";
        if ($bNewRecord) {$arSAVE[$iCnt]['_STATUS'] = "insert"; } else {$arSAVE[$iCnt]['_STATUS'] = "update"; }
        $iCnt++;
      }

      // check doubled records
      if (isset($arDOPL[$this->val['data']['SUB_NAME'][$i]]))
           {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['SUB_NAME'][$i] = $this->language->language_getLabel(24);}
      else {$arDOPL[$this->val['data']['SUB_NAME'][$i]]="";}

      // necessary to identify deleted records: mark all existing records
      unset($arDEL[$this->val['data']['SUB_ID'][$i]]);
    }

    // deleting records
    foreach ($arDEL as $pk_value => $bDelete)
    {
      $iChk = $this->model->mdl_check_foreign_key("curriculum", array("sub_id", $pk_value));
      
      if ($iChk>0)
      {
        // get record
        $arH = $this->model->mdl_execute_simple_queries("subject", "sub_id", array($pk_value));
      
        // add record to data array
        $this->val['data']['SUB_ID'][] = $pk_value;
        $this->val['data']['SUB_NAME'][] = $arH[0]['SUB_NAME'];
        $this->val['data']['SUB_LONG_NAME'][] = $arH[0]['SUB_LONG_NAME'];
        $this->val['data']['SUB_TYP'][] = $arH[0]['SUB_TYP'];

        // error message
        $sErr .= str_replace(array("<#NAME#>", "<#ANZAHL#>", "<#FK_NAME#>"), array($arH[0]['SUB_NAME'], $iChk, $this->language->language_getLabel(12)) , $this->language->language_getLabel(9));

      }
    }

    return $sErr;
  }
  
  
  
  
  
  
  
  
  
  /**
      @brief    validate posted modules data
      @ingroup  c_subject
      @return   $arSAVE (function-parameter) array containing records to save
      @return   $arDEL (function-parameter) array containing records to delete
      @return   error message
  */
  function c_subject_validateModData(&$arSAVE, &$arDEL)
  {
    $sErr = "";

    // necessary to identify deleted records: query all 'subject' data
    $arFLD = $this->model->mdl_execute_simple_queries("subject", null, null, null, "MOD_ID is not null");
    for ($i=0; $i<count($arFLD); $i++) {$arDEL[$arFLD[$i]['SUB_ID']]=true;}

    // check all records
    $iCnt = 0;
    unset($arDOPL);
    foreach ($this->val['data'] as $key => $arVAL)
    {
      // new MOD_ID?
      if ($key<0 and !$arNewModId[$key])
      {
        $arNewModId[$key] = $this->model->mdl_get_next_id("subject", "mod_id");
      }
    
      if ($key != -9999)
      {
        for ($i=1; $i<count($arVAL['SUB_ID']); $i++)
        {
          $bChange = FALSE;
          $bNewRecord = FALSE;

          // format strings
          $arVAL['SUB_NAME'][$i] = stripslashes($arVAL['SUB_NAME'][$i]);
          $arVAL['SUB_LONG_NAME'][$i] = stripslashes($arVAL['SUB_LONG_NAME'][$i]);

          // format integers
          $arVAL['SUB_TYP'] = intval($arVAL['SUB_TYP']);
          if ($arVAL['SUB_ID'][$i] != -9999) // existing record
          {
            // query current record
            $arCHK = $this->model->mdl_execute_simple_queries("subject", "sub_id", array(intval($arVAL['SUB_ID'][$i])));

            // record changed?
            if ($arVAL['SUB_NAME'][$i] != $arCHK[0]['SUB_NAME']) {$bChange = TRUE;}
            if ($arVAL['SUB_LONG_NAME'][$i] != $arCHK[0]['SUB_LONG_NAME']) {$bChange = TRUE;}
            if ($arVAL['SUB_TYP'] != $arCHK[0]['SUB_TYP']) {$bChange = TRUE;}

          } else  // new record
          {
            $bChange = TRUE;
            $bNewRecord = TRUE;
          }

          // validate changed data
          if ($bChange)
          {
            if (strlen($arVAL['SUB_NAME'][$i]) < 1 or strlen($arVAL['SUB_NAME'][$i]) > 8) {$sErr = $this->language->language_getLabel(7); $this->val['data'][$key]['ERR']['SUB_NAME'][$i] = str_replace(array("<#L1#>","<#L2#>"), array(1,8), $this->language->language_getLabel(6));}
            if (strlen($arVAL['SUB_LONG_NAME'][$i]) < 1 or strlen($arVAL['SUB_LONG_NAME'][$i]) > 30) {$sErr = $this->language->language_getLabel(7); $this->val['data'][$key]['ERR']['SUB_LONG_NAME'][$i] = str_replace(array("<#L1#>","<#L2#>"), array(1,30), $this->language->language_getLabel(6));}
            if (intval($arVAL['SUB_TYP']) != 1 && intval($arVAL['SUB_TYP']) != 2) {$sErr = $this->language->language_getLabel(7); $this->val['data'][$key]['ERR']['SUB_TYP'] = $this->language->language_getLabel(23);}

            $arSAVE[$iCnt]['SUB_ID'] = intval($arVAL['SUB_ID'][$i]);
            $arSAVE[$iCnt]['SUB_NAME'] = $arVAL['SUB_NAME'][$i];
            $arSAVE[$iCnt]['SUB_LONG_NAME'] = $arVAL['SUB_LONG_NAME'][$i];
            $arSAVE[$iCnt]['SUB_TYP'] = $arVAL['SUB_TYP'];
            $arSAVE[$iCnt]['MOD_ID'] = (($key<0) ? $arNewModId[$key] : $key);
            if ($bNewRecord) {$arSAVE[$iCnt]['_STATUS'] = "insert"; } else {$arSAVE[$iCnt]['_STATUS'] = "update"; }
            $iCnt++;
          }

          // check doubled records
          if (isset($arDOPL[$arVAL['SUB_NAME'][$i]]))
               {$sErr = $this->language->language_getLabel(7); $this->val['data'][$key]['ERR']['SUB_NAME'][$i] = $this->language->language_getLabel(24);}
          else {$arDOPL[$arVAL['SUB_NAME'][$i]]="";}

          // necessary to identify deleted records: mark all existing records
          unset($arDEL[$arVAL['SUB_ID'][$i]]);
        }
      }
    }




    // deleting records
    foreach ($arDEL as $pk_value => $bDelete)
    {
      $iChk = $this->model->mdl_check_foreign_key("curriculum", array("sub_id", $pk_value));

      if ($iChk>0)
      {
      // $this->val['data'][<#key#>]['SUB_ID'][]

        // get record
        $arH = $this->model->mdl_execute_simple_queries("subject", "sub_id", array($pk_value));

        // add record to data array
        $this->val['data'][$arH[0]['MOD_ID']]['SUB_ID'][] = $pk_value;
        $this->val['data'][$arH[0]['MOD_ID']]['SUB_NAME'][] = $arH[0]['SUB_NAME'];
        $this->val['data'][$arH[0]['MOD_ID']]['SUB_LONG_NAME'][] = $arH[0]['SUB_LONG_NAME'];
        $this->val['data'][$arH[0]['MOD_ID']]['SUB_TYP'][] = $arH[0]['SUB_TYP'];

        // error message
        $sErr .= str_replace(array("<#NAME#>", "<#ANZAHL#>", "<#FK_NAME#>"), array($arH[0]['SUB_NAME'], $iChk, $this->language->language_getLabel(12)) , $this->language->language_getLabel(9));

      }
    }
    return $sErr;
  }









  /**
      @brief    loading lectures and examination records
      @ingroup  v_subject
      @return   two dimensional resultset <i>(ar[<line>][<rowname>] = < value >)</i>
  */
  function c_subject_getVeData()
  {
      // show database data (lecture and examination)
      $arDATA = $this->model->mdl_execute_simple_queries("subject", null, null, "SUB_LONG_NAME", "MOD_ID is null");

      return $arDATA;
  }
  
  







  /**
      @brief    loading module records
      @ingroup  v_subject
      @return   two dimensional resultset <i>(ar[<MOD_ID>][<line>][<rowname>] = < value >)</i>
  */
  function c_subject_getModData()
  {
      // show database data (moduls)
      $arMOD = $this->model->mdl_execute_simple_queries("subject", null, null, "MOD_ID, SUB_LONG_NAME", "MOD_ID is not null");

      // format data
      for ($i=0; $i<count($arMOD); $i++)
      {
        $arM[$arMOD[$i]['MOD_ID']]['SUB_ID'][] = $arMOD[$i]['SUB_ID'];
        $arM[$arMOD[$i]['MOD_ID']]['SUB_NAME'][] = $arMOD[$i]['SUB_NAME'];
        $arM[$arMOD[$i]['MOD_ID']]['SUB_LONG_NAME'][] = $arMOD[$i]['SUB_LONG_NAME'];
        $arM[$arMOD[$i]['MOD_ID']]['SUB_TYP'] = $arMOD[$i]['SUB_TYP'];
      }
    return $arM;
  }
}

?>