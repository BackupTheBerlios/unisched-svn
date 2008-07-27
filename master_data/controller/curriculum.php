<?php

/**

  @defgroup c_curriculum class c_curriculum
  @brief library to interconnect presentation and model for the 'curriculum' web form
  @ingroup CONTROLLER

  <pre>
  --------------------------------------------------------------------------------
  FILE-HISTORY
  --------------------------------------------------------------------------------
  Description
    handle curriculum form
  --------------------------------------------------------------------------------
  date        version   upload    who?      change description
  10.07.2008            no        it05mg1   created
  --------------------------------------------------------------------------------
  </pre>
*/


class c_curriculum
{
  var $v_curriculum; // VIEW
  var $model;
  var $val;
  var $language;
  
  /**
      @brief    constructor (initiate v_curriculum, mdl and language class)
      @ingroup  c_curriculum
      @param    $val  array with all posted parameters
  */
  function c_curriculum($val)
  {
    $this->val = $val;

    $this->v_curriculum = new v_curriculum($val);
    $this->model = new mdl;
    $this->language = new language($val['lang']);
  }









  /**
      @brief    generate form (main part of the application website)
      @ingroup  c_curriculum
      @param    $site current site
      @return   HTML (table with 'curriculum' data)
  */
  function c_curriculum_generateForm()
  {
    // show database data
    $arDATA = $this->model->mdl_execute_simple_queries("class", null, null, "CLASS_NAME");

    // generate table with 'class' data
    $sMain = $this->v_curriculum->v_curriculum_getFormHtml($arDATA, $this->val['site']);
    
    
    
    
    // call function that generates the whole HTML-site
    return $this->v_curriculum->v_curriculum_generate_site($sMain);
  }
}

?>