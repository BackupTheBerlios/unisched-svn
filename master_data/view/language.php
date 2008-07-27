<?php

/**

  @defgroup language class language
  @brief Library for the multilanguage GUI
  @ingroup VIEW

  <pre>
  --------------------------------------------------------------------------------
  FILE-HISTORY
  --------------------------------------------------------------------------------
  Description
    multilanguage
  --------------------------------------------------------------------------------
  date        version   upload    who?      change description
  10.07.2008            no        it05mg1   created
  --------------------------------------------------------------------------------
  </pre>
*/

class language
{
  var $objMdl;
  var $lan_id;
  
  /**
      @brief    constructor (initiate mdl class)
      @ingroup  language
      @param    $lan_id current language
  */
  function language($lan_id)
  {
    $this->objMdl = new mdl;
    $this->lan_id = $lan_id;
  }









  /**
      @brief    load the text of the requested label in the current language
      @ingroup  language
      @param    $label_id requested label
  */
  function language_getLabel($label_id)
  {
    return $this->objMdl->mdl_get_label($label_id, $this->lan_id);
  }
}
?>