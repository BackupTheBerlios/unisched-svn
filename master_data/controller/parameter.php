<?php

/**

  @defgroup parameter file parameter
  @brief necessary to collect all send form values
  @ingroup CONTROLLER

  <pre>
  --------------------------------------------------------------------------------
  FILE-HISTORY
  --------------------------------------------------------------------------------
  Description
    nessecary to collect all send form values
  --------------------------------------------------------------------------------
  date        version   upload    who?      change description
  10.07.2008            no        it05mg1   created
  --------------------------------------------------------------------------------
  </pre>
*/

  // current site
  $site = getParam('site');
  $val['site'] = ($site=="") ? 0 : $site;
  $val['site'] = (is_numeric($val['site'])) ? $val['site'] : 0;
  
  // current language
  $lang = getParam('lang');
  $val['lang'] = ($lang==0) ? 1 : $lang;
  $val['lang'] = (is_numeric($val['lang'])) ? $val['lang'] : 0;

  // call requested site
  switch ($val['site'])
  {
    // field of study
    case 1:
      $val['data'] = getParam('data');
      $val['do'] = getParam('do');
    break;
    
    // class
    case 2:
      $val['data'] = getParam('data');
      $val['do'] = getParam('do');
    break;
    
    // subject
    case 3:
      $val['data'] = getParam('data');
      $val['do'] = getParam('do');
    break;
    
    // room
    case 4:
      $val['data'] = getParam('data');
      $val['do'] = getParam('do');
    break;
    
    // class
    case 5:
      $val['data'] = getParam('data');
      $val['do'] = getParam('do');
    break;

    // class period
    case 6:
      $val['data'] = getParam('data');
      $val['do'] = getParam('do');
    break;

    // cur class
    case 8:
      $val['data'] = getParam('data');
      $val['do'] = getParam('do');
      $val['CLASS_ID'] = getParam('CLASS_ID');;
    break;

  }









  /**
      @brief    check whether the requested parameter is in $_GET or $_POST
      @ingroup  parameter
      @param    $value  requested parameter
      @return   value from $_GET or $_POST
  */
  function getParam($value)
  {
    if ($_GET[$value]!="") {return $_GET[$value];} else {return $_POST[$value];}
  }
?>