<?php

/**

  @mainpage University Scheduling System (master data)
  @version 0.1
  @author Michael Dietzmann, Martin Wenzel, Michael Garbe
  @date 25-07-2008
  @brief source code documentation

  @defgroup MODEL Package MODEL
  @brief data mapper layer

  @defgroup VIEW Package VIEW
  @brief presentation layer (GUI)

  @defgroup CONTROLLER Package CONTROLLER
  @brief logical layer
*/


/** <!-- FILE -->

  @defgroup index class index
  @brief central application file; any request start here
  @ingroup CONTROLLER

  <pre>
  --------------------------------------------------------------------------------
  FILE-HISTORY
  --------------------------------------------------------------------------------
  Description
    central application file
    control every request
  --------------------------------------------------------------------------------
  date        version   upload    who?      change description
  10.07.2008            no        it05mg1   created
  28.07.2008  1.0.0     yes       it05mg1   upload
  --------------------------------------------------------------------------------
  </pre>
*/

include_once("controller/parameter.php");

$run = new index($val);


class index
{
  /**
      @brief    constructor
      @ingroup  index
  */
  function index($val)
  {
    include_once("model/model.php");
    include_once("view/language.php");
    include_once("view/frame.php");

    // run requested site
    switch ($val['site'])
    {
      // start page
      case 0:
        include_once('view/first_page.php');
        $class = new v_first_page($val);
        $site = $class->v_first_page_getFormHtml();
      break;
      // field of study
      case 1:
        include_once('controller/field.php');
        include_once('view/field.php');
        $class = new c_field($val);
        $site = $class->c_field_generateForm();
      break;
      // lecturer
      case 2:
        include_once('controller/lecturer.php');
        include_once('view/lecturer.php');
        $class = new c_lecturer($val);
        $site = $class->c_lecturer_generateForm();
      break;
      // subject
      case 3:
        include_once('controller/subject.php');
        include_once('view/subject.php');
        $class = new c_subject($val);
        $site = $class->c_subject_generateForm();
      break;
      // room
      case 4:
        include_once('controller/room.php');
        include_once('view/room.php');
        $class = new c_room($val);
        $site = $class->c_room_generateForm();
      break;
      // class
      case 5:
        include_once('controller/class.php');
        include_once('view/class.php');
        $class = new c_class($val);
        $site = $class->c_class_generateForm();
      break;
      // class period
      case 6:
        include_once('controller/class_period.php');
        include_once('view/class_period.php');
        $class = new c_class_period($val);
        $site = $class->c_class_period_generateForm();
      break;
      // curriculum
      case 7:
        include_once('controller/curriculum.php');
        include_once('view/curriculum.php');
        $class = new c_curriculum($val);
        $site = $class->c_curriculum_generateForm();
      break;
      // cur_class
      case 8:
        include_once('controller/cur_class.php');
        include_once('view/cur_class.php');
        $class = new c_cur_class($val);
        $site = $class->c_cur_class_generateForm();
      break;
      // defaultroom
      case 9:
        include_once('controller/defaultroom.php');
        include_once('view/defaultroom.php');
        $class = new c_defaultroom($val);
        $site = $class->c_defaultroom_generateForm();
      break;
      default:
        die('<center><b>not existing page</b></center>');
    }
    
    // show site
    echo $site;
  }
}
?>