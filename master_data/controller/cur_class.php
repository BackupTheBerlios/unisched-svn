<?php

/**

  @defgroup c_cur_class class c_cur_class
  @brief library to interconnect presentation and model for the edit-form for the curriculum of one 'class' web form
  @ingroup CONTROLLER

  <pre>
  --------------------------------------------------------------------------------
  FILE-HISTORY
  --------------------------------------------------------------------------------
  Description
    handle edit form
  --------------------------------------------------------------------------------
  date        version   upload    who?      change description
  21.07.2008            no        it05mg1   created
  --------------------------------------------------------------------------------
  </pre>
*/


class c_cur_class
{
  var $v_cur_class; // VIEW
  var $model;
  var $val;
  var $language;
  
  /**
      @brief    constructor (initiate v_cur_class, mdl and language class)
      @ingroup  c_cur_class
      @param    $val  array with all posted parameters
  */
  function c_cur_class($val)
  {
    $this->val = $val;

    $this->v_cur_class = new v_cur_class($val);
    $this->model = new mdl;
    $this->language = new language($val['lang']);
  }









  /**
      @brief    generate form (main part of the application website)
      @ingroup  c_cur_class
      @param    $site current site
      @return   HTML (table with 'cur_class' data)
  */
  function c_cur_class_generateForm()
  {
    if ($this->val['do'] == "save")
    {
      // check saving data
      $sErr = $this->c_cur_class_validateData($arSAVE, $arDEL);

      if ($sErr=="")
      {
        // saving
        for ($i=0; $i<count($arSAVE); $i++)
        {
          // take all classs
          $arField[$i]['NUMBER']['CLASS_PERIOD_ID'] = $arSAVE[$i]['CLASS_PERIOD_ID'];
          $arField[$i]['NUMBER']['SUB_ID'] = $arSAVE[$i]['SUB_ID'];
          $arField[$i]['NUMBER']['LEC_ID'] = $arSAVE[$i]['LEC_ID'];
          $arField[$i]['NUMBER']['CLASS_ID'] = $arSAVE[$i]['CLASS_ID'];
          $arField[$i]['NUMBER']['CUR_CNT_SUB'] = $arSAVE[$i]['CUR_CNT_SUB'];

          // insert data
          if ($this->model->mdl_insert_data($arField, array("CUR_ID", $arSAVE[$i]['CUR_ID']),"CURRICULUM", $arSAVE[$i]['_STATUS']) ) {$sErr = $this->language->language_getLabel(8); break;}
        }

        if (is_array($arDEL))
        {
          if ($sErr=="")
          {
            foreach($arDEL as $key => $value)
            {
              $this->model->mdl_delete_data(array("CUR_ID", $key), "CURRICULUM");
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
      for ($i=1; $i<count($this->val['data']['CUR_ID']); $i++)
      {
        if ($this->val['data']['CUR_ID'][$i] != "") // extract hidden record
        {
          $arCUR[$iCnt]['CUR_ID'] = $this->val['data']['CUR_ID'][$i];
          $arCUR[$iCnt]['CLASS_PERIOD_ID'] = $this->val['data']['CLASS_PERIOD_ID'][$i];
          $arCUR[$iCnt]['SUB_ID'] = $this->val['data']['SUB_ID'][$i];
          $arCUR[$iCnt]['CLASS_ID'] = $this->val['data']['CLASS_ID'][$i];
          $arCUR[$iCnt]['CUR_CNT_SUB'] = $this->val['data']['CUR_CNT_SUB'][$i];
          $arCUR[$iCnt]['lec_id'] = $this->val['data']['LEC_ID'][$i];

          $arCUR[$iCnt]['ERR']['SUB_ID'] = $this->val['data']['ERR']['SUB_ID'][$i];
          $arCUR[$iCnt]['ERR']['CLASS_ID'] = $this->val['data']['ERR']['CLASS_ID'][$i];
          $arCUR[$iCnt]['ERR']['CUR_CNT_SUB'] = $this->val['data']['ERR']['CUR_CNT_SUB'][$i];
          $iCnt++;
        }
      }
    } else
    {
      // query curriculum
      $arCUR = $this->model->mdl_execute_simple_queries("curriculum", "class_id", array($this->val['CLASS_ID']));
    }

    // query class period
    $arPERIOD = $this->model->mdl_execute_simple_queries("class_period", "class_id", array($this->val['CLASS_ID']), "CLASS_PERIOD_BEGIN");

    // query subject
    $arSUB = $this->model->mdl_execute_simple_queries("subject", null, null, "SUB_NAME");

    // query lecture
    $arLEC = $this->model->mdl_execute_simple_queries("lecturer", null, null, "LEC_LNAME, LEC_GNAME");

    // generate table with 'cur_class' data
    $sMain = $this->v_cur_class->v_cur_class_getFormHtml($arPERIOD, $arCUR, $arSUB, $arLEC, $this->val['site'], $this->val['CLASS_ID'], $sErr, $this->val['do']);
    
    // class name
    $arCLASS = $this->model->mdl_execute_simple_queries("class", "class_id", array($this->val['CLASS_ID']));
    
    // call function that generates the whole HTML-site
    return $this->v_cur_class->v_cur_class_generate_site($sMain, $arCLASS[0]['CLASS_NAME']);
  }
  
  







  /**
      @brief    validate posted data
      @ingroup  c_cur_class
      @return   $arSAVE (function-parameter) array containing records to save
      @return   $arDEL (function-parameter) array containing records to delete
      @return   error message
  */
  function c_cur_class_validateData(&$arSAVE, &$arDEL)
  {
    $sErr = "";

    // necessary to identify deleted records: query all 'curriculum' data
    $arFLD = $this->model->mdl_execute_simple_queries("curriculum", "class_id", array($this->val['CLASS_ID']));
    for ($i=0; $i<count($arFLD); $i++) {$arDEL[$arFLD[$i]['CUR_ID']]=true;}
    
    // check all records
    $iCnt = 0;
    unset($arDOPL);
    for ($i=1; $i<count($this->val['data']['CUR_ID']); $i++)
    {
      if ($this->val['data']['CUR_ID'][$i] != "") // extract hidden record
      {
        $bChange = FALSE;
        $bNewRecord = FALSE;

        // numbers strings
        $this->val['data']['CLASS_PERIOD_ID'][$i] = intval($this->val['data']['CLASS_PERIOD_ID'][$i]);
        $this->val['data']['SUB_ID'][$i] = intval($this->val['data']['SUB_ID'][$i]);
        $this->val['data']['CLASS_ID'][$i] = intval($this->val['CLASS_ID']);
        $this->val['data']['CUR_CNT_SUB'][$i] = intval($this->val['data']['CUR_CNT_SUB'][$i]);
        $this->val['data']['LEC_ID'][$i] = intval($this->val['data']['LEC_ID'][$i]);

        if ($this->val['data']['CUR_ID'][$i] != -9999) // existing record
        {
          // query current record
          $arCHK = $this->model->mdl_execute_simple_queries("curriculum", "cur_id", array(intval($this->val['data']['CUR_ID'][$i])));

          // record changed?
          if ($this->val['data']['SUB_ID'][$i] != $arCHK[0]['SUB_ID']) {$bChange = TRUE;}
          if ($this->val['data']['CUR_CNT_SUB'][$i] != $arCHK[0]['CUR_CNT_SUB']) {$bChange = TRUE;}
          if ($this->val['data']['LEC_ID'][$i] != $arCHK[0]['lec_id']) {$bChange = TRUE;}

        } else  // new record
        {
          $bChange = TRUE;
          $bNewRecord = TRUE;
        }

        // validate changed data
        if ($bChange)
        {
          $arCHK = $this->model->mdl_execute_simple_queries("subject", "SUB_ID", array($this->val['data']['SUB_ID'][$i]));
          if (count($arCHK) != 1) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['SUB_ID'][$i] = $this->language->language_getLabel(23); echo "sub_error<br/>";}
          $arCHK = $this->model->mdl_execute_simple_queries("lecturer", "lec_id", array($this->val['data']['LEC_ID'][$i]));
          if (count($arCHK) != 1) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['LEC_ID'][$i] = $this->language->language_getLabel(23); echo "lec_error<br/>";}

          if ($this->val['data']['CUR_CNT_SUB'][$i] < 1 or $this->val['data']['CUR_CNT_SUB'][$i] > 999) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['CUR_CNT_SUB'][$i] = str_replace(array("<#N1#>", "<#N2#>"), array(1, 999), $this->language->language_getLabel(27));}


          $arSAVE[$iCnt]['CUR_ID'] = intval($this->val['data']['CUR_ID'][$i]);
          $arSAVE[$iCnt]['CLASS_ID'] = intval($this->val['data']['CLASS_ID'][$i]);
          $arSAVE[$iCnt]['CLASS_PERIOD_ID'] = intval($this->val['data']['CLASS_PERIOD_ID'][$i]);
          $arSAVE[$iCnt]['CUR_CNT_SUB'] = intval($this->val['data']['CUR_CNT_SUB'][$i]);
          $arSAVE[$iCnt]['LEC_ID'] = intval($this->val['data']['LEC_ID'][$i]);
          $arSAVE[$iCnt]['SUB_ID'] = intval($this->val['data']['SUB_ID'][$i]);
          if ($bNewRecord) {$arSAVE[$iCnt]['_STATUS'] = "insert"; } else {$arSAVE[$iCnt]['_STATUS'] = "update"; }
          $iCnt++;
        }

        // check doubled records
//        if (isset($arDOPL[$arSAVE[$iCnt]['CLASS_PERIOD_ID'].$this->val['data']['SUB_ID'][$i].$this->val['data']['LEC_ID'][$i]])) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['SUB_ID'][$i] = $this->language->language_getLabel(11); $this->val['data']['ERR']['LEC_ID'][$i] = $this->language->language_getLabel(11);} else {$arDOPL[$arSAVE[$iCnt]['CLASS_PERIOD_ID'].$this->val['data']['SUB_ID'][$i].$this->val['data']['LEC_ID'][$i]]="";}

        // necessary to identify deleted records: mark all existing records
        unset($arDEL[$this->val['data']['CUR_ID'][$i]]);
      }
    }

    // deleting records
    if (is_array($arDEK))
    {
      foreach ($arDEL as $pk_value => $bDelete)
      {
        $iChk = $this->model->mdl_check_foreign_key("booking", array("cur_id", $pk_value));

        if ($iChk>0)
        {
          // get record
          $arH = $this->model->mdl_execute_simple_queries("curriculum", "cur_id", array($pk_value));

          // add record to data array
          $this->val['data']['CUR_ID'][] = $pk_value;
          $this->val['data']['CLASS_PERIOD_ID'][] = $arH[0]['CLASS_PERIOD_ID'];
          $this->val['data']['CLASS_ID'][] = $arH[0]['CLASS_ID'];
          $this->val['data']['SUB_ID'][] = $arH[0]['SUB_ID'];
          $this->val['data']['LEC_ID'][] = $arH[0]['lec_id'];
          $this->val['data']['CUR_CNT_SUB'][] = $arH[0]['CUR_CNT_SUB'];

          // label
          $arL1 = $this->model->mdl_execute_simple_queries("subject", "sub_id", array($arH[0]['SUB_ID']));
          $arL2 = $this->model->mdl_execute_simple_queries("lecturer", "lec_id", array($arH[0]['lec_id']));

          // error message
          $sErr .= str_replace(array("<#NAME#>", "<#ANZAHL#>", "<#FK_NAME#>"), array($arL1[0]['SUB_NAME']."-".$arL1[0]['LEC_LNAME'], $iChk, $this->language->language_getLabel(12)) , $this->language->language_getLabel(9));
        }
      }
    }
    return $sErr;
  }
}

?>