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
  10.07.2008            no        it05mg1   created
  28.07.2008  1.0.0     yes       it05mg1   upload
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
      @return   HTML (table with 'defaultroom' data)
  */
  function c_defaultroom_generateForm()
  {
    // saving
    if ($this->val['do'] == "save")
    {
      // check saving data
      $sErr = $this->c_defaultroom_validateData($arSAVE, $arDEL);

      if ($sErr=="")
      {
        // deleting all existing records
        $this->model->mdl_delete_defaultrooms($this->val['CLASS_ID']);

        // create all saving records
        for ($i=0; $i<count($arSAVE); $i++)
        {
          // take all classs
          $arField[$i]['NUMBER']['ROOM_ID'] = $arSAVE[$i]['ROOM_ID'];
          $arField[$i]['NUMBER']['PRIORITY'] = $arSAVE[$i]['PRIORITY'];

          // insert data
          if ($this->model->mdl_insert_data($arField, array("CLASS_ID", $arSAVE[$i]['CLASS_ID']), "defaultrooms", $arSAVE[$i]['_STATUS']) ) {$sErr = $this->language->language_getLabel(8); break;}
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

    // show class overview?
    if ($this->val['do'] == "show_class" or $this->val['do']=="save")
    {
      // error?
      if ($sErr!="")
      {
        // show form data
        $iCnt = 0;
        for ($i=1; $i<count($this->val['data']['ROOM_ID']); $i++)
        {
          $arDATA[$iCnt]['ROOM_ID'] = $this->val['data']['ROOM_ID'][$i];
          $arDATA[$iCnt]['priority'] = $this->val['data']['PRIORITY'][$i];

          $arDATA[$iCnt]['ERR']['ROOM_ID'] = $this->val['data']['ERR']['ROOM_ID'][$i];
          $arDATA[$iCnt]['ERR']['PRIORITY'] = $this->val['data']['ERR']['PRIORITY'][$i];
          $iCnt++;
        }
      } else
      {
        // show database data
        $arDATA = $this->model->mdl_execute_simple_queries("defaultrooms", "CLASS_ID", array($this->val['CLASS_ID']), "priority");
      }

      // load 'room'-data
      $arFK = $this->model->mdl_execute_simple_queries("room", null, null, "ROOM_NR");
      for ($i=0; $i<count($arFK); $i++) {$arFK[$i]['ROOM_NR'] = $arFK[$i]['ROOM_NR'].' ('.$arFK[$i]['ROOM_NAME'].')';}

      // generate table with 'defaultrooms' data
      $sMain = $this->v_defaultroom->v_defaultroom_getFormHtml($arDATA, $this->val['site'], 2, $this->val['CLASS_ID'], $arFK, $sErr, $this->val['do']);
      
      // load 'class' name
      $arC = $this->model->mdl_execute_simple_queries("class", "CLASS_ID", array($this->val['CLASS_ID']));
      $sCLASS_NAME = $arC[0]['CLASS_NAME'];
    } else
    {
      // show database data
      $arDATA = $this->model->mdl_execute_simple_queries("class", null, null, "CLASS_NAME");

      // generate table with 'class' data
      $sMain = $this->v_defaultroom->v_defaultroom_getFormHtml($arDATA, $this->val['site'], 1);
      
      // set 'class' name
      $sCLASS_NAME="";
    }

    // call function that generates the whole HTML-site
    return $this->v_defaultroom->v_defaultroom_generate_site($sMain, $sCLASS_NAME);
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
    
    // check all records
    $iCnt = 0;
    unset($arDOPL);
    for ($i=1; $i<count($this->val['data']['ROOM_ID']); $i++)
    {
      $bChange = FALSE;
      $bNewRecord = FALSE;

      // format numbers
      $this->val['data']['ROOM_ID'][$i] = intval($this->val['data']['ROOM_ID'][$i]);
      $this->val['data']['PRIORITY'][$i] = intval($this->val['data']['PRIORITY'][$i]);

      // validate changed data
      $arCHK = $this->model->mdl_execute_simple_queries("room", "room_id", array($this->val['data']['ROOM_ID'][$i]));
      if (count($arCHK) != 1) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['ROOM_ID'][$i] = $this->language->language_getLabel(28);}
      if ($this->val['data']['PRIORITY'][$i] != 1 and $this->val['data']['PRIORITY'][$i] != 2 and $this->val['data']['PRIORITY'][$i] != 3 and $this->val['data']['PRIORITY'][$i] != 4 and $this->val['data']['PRIORITY'][$i] != 5) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['PRIORITY'][$i] = $this->language->language_getLabel(23);}

      $arSAVE[$iCnt]['CLASS_ID'] = intval($this->val['CLASS_ID']);
      $arSAVE[$iCnt]['ROOM_ID'] = $this->val['data']['ROOM_ID'][$i];
      $arSAVE[$iCnt]['PRIORITY'] = $this->val['data']['PRIORITY'][$i];
      $arSAVE[$iCnt]['_STATUS'] = "insert";
      $iCnt++;

      // check doubled records
      if (isset($arDOPL[$this->val['data']['ROOM_ID'][$i]])) {$sErr = $this->language->language_getLabel(7); $this->val['data']['ERR']['ROOM_ID'][$i] = $this->language->language_getLabel(11);}
      else {$arDOPL[$this->val['data']['ROOM_ID'][$i]]="";}
    }

    return $sErr;
  }
}

?>