<?php

/**

  @defgroup frame class frame
  @brief frame of the HTML-GUI
  @ingroup VIEW

  <pre>
  --------------------------------------------------------------------------------
  FILE-HISTORY
  --------------------------------------------------------------------------------
  Description
    frame of the HTML-GUI
  --------------------------------------------------------------------------------
  date        version   upload    who?      change description
  10.07.2008            no        it05mg1   created
  --------------------------------------------------------------------------------
  </pre>
*/

class frame
{
  var $language;
  var $site;


  /**
      @brief    constructor (initiate language class)
      @ingroup  frame
      @param    $lan_id current language
  */
  function frame($val)
  {
    $this->language = new language($val['lang']);
    $this->site = $val['site'];
  }









  /**
      @brief    contains whole HTML site; include the $sMain parameter in the main area of the website
      @ingroup  frame
      @param    $sHeadline headline of the main area
      @param    $sMain content of the main area
  */
  function frame_getFrame($sHeadline, $sMain, $lan_id)
  {
    if ($lan_id == 1)
    {
      // german
      return '
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="en" xml:lang="en">
<head>

<!-- title browser title bar -->

<title>UniSchedSys</title>
<meta http-equiv="content-type" content="text/html; charset=iso-8859-1" />
<meta name="Ba-Projekt" content="dreamLogic" />
<meta name="University Scheduling System" content="Stundeplan- und Raumplanung " />
<link rel="stylesheet" href="css/style.css" type="text/css" />

</head>

<body>

<div id="wrap">

<div id="sidebar">
<a href="index.html"><img src="css/logo-uss2.gif" alt="University Scheduling System - Project" /></a>
<br />

<div id="navcontainer">
<ul id="navlist">
<li><a href="index.html">Start</a></li> <!-- Home --> <!-- index.html-->
<li><a href="../produkt.html">Produktbeschreibung</a></li> <!-- our product --> <!-- produkt.html-->

<li><br></li>
<li><a href="index.php?site=0&lang='.$lan_id.'">Stammdatenpflege</a></li> <!-- master date -->
<li class="navlist_low"><a href="index.php?site=4&lang='.$lan_id.'">Räume</a></li>
<li class="navlist_low"><a href="index.php?site=9&lang='.$lan_id.'">Standardraum</a></li>
<li class="navlist_low"><a href="index.php?site=2&lang='.$lan_id.'">Dozenten</a></li>
<li class="navlist_low"><a href="index.php?site=3&lang='.$lan_id.'">Fächer</a></li>
<li class="navlist_low"><a href="index.php?site=1&lang='.$lan_id.'">Studienrichtung</a></li>
<li class="navlist_low"><a href="index.php?site=5&lang='.$lan_id.'">Seminargruppen</a></li>
<li class="navlist_low"><a href="index.php?site=6&lang='.$lan_id.'">Studienzeitraum</a></li>
<li class="navlist_low"><a href="index.php?site=7&lang='.$lan_id.'">Curriculum</a></li>

<li><br></li>
<li><a href="../timetable.php">Planerstellung</a></li> <!-- scheduling -->
<li><br></li>
<li><a href="impressum.html">Impressum</a></li> <!-- About us -->
<!-- <li><a href="http://validator.w3.org/check?uri=referer">Validate</a></li> -->
<li><br></li>
<li><a href="index.php?site='.$this->site.'&lang=2">Deutsch - Englisch</a></li>
</ul>
</div>

<!--end sidebar-->
</div>

<div id="container">

<div id="content1">
  <h3>'.$sHeadline.'</h3>

<!-- page content -->
<center>
  '.$sMain.'
</center>

<!-- end page content -->

</div>
<div id="content2">
&nbsp;
</div>


<div id="footer">  <br />
<!-- it\'d be super if you left this link intact -->

<a href="http://www.dream-logic.com">Web Design by dreamLogic</a> |
<a href="#">Privacy Policy</a> |

<a href="#">Terms and Conditions</a>
</div>

<!-- end container -->
</div>


<!-- end wrap-->
</div>

</body>
</html>';
    } else
    { // english
      return '<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="en" xml:lang="en">
<head>

<!-- title browser title bar -->

<title>UniSchedSys</title>
<meta http-equiv="content-type" content="text/html; charset=iso-8859-1" />
<meta name="Ba-Projekt" content="dreamLogic" />
<meta name="University Scheduling System" content="Stundeplan- und Raumplanung " />
<link rel="stylesheet" href="css/style.css" type="text/css" />

</head>

<body>


<div id="wrap">

<div id="sidebar">
<a href="index-en.html"><img src="css/logo-uss2.gif" alt="University Scheduling System - Project" /></a>
<br />

<div id="navcontainer">
<ul id="navlist">
<li><a href="index.html">Home</a></li> <!-- Home --> <!-- index.html-->
<li><a href="produkt.html">Our Product</a></li> <!-- our product --> <!-- produkt.html-->
<li><br></li>
<li><a href="index.php?site=0&lang='.$lan_id.'">Master Data</a></li> <!-- master date -->
<li class="navlist_low"><a href="index.php?site=4&lang='.$lan_id.'">room</a></li>
<li class="navlist_low"><a href="index.php?site=9&lang='.$lan_id.'">default room</a></li>
<li class="navlist_low"><a href="index.php?site=2&lang='.$lan_id.'">lecturer</a></li>
<li class="navlist_low"><a href="index.php?site=3&lang='.$lan_id.'">subject</a></li>
<li class="navlist_low"><a href="index.php?site=1&lang='.$lan_id.'">field</a></li>
<li class="navlist_low"><a href="index.php?site=5&lang='.$lan_id.'">class</a></li>
<li class="navlist_low"><a href="index.php?site=6&lang='.$lan_id.'">class period</a></li>
<li class="navlist_low"><a href="index.php?site=7&lang='.$lan_id.'">curriculum</a></li>
<li><br></li>
<li><a href="../timetable.php">Scheduling</a></li> <!-- scheduling -->
<li><br></li>
<li><a href="impressum.html">About Us</a></li> <!-- About us -->
<!-- <li><a href="http://validator.w3.org/check?uri=referer">Validate</a></li> -->
<li><br></li>
<li><a href="index.php?site='.$this->site.'&lang=1">English - German</a></li>
</ul>
</div>

<!--end sidebar-->
</div>

<div id="container">


<div id="content1">
  <h3>'.$sHeadline.'</h3>

<!-- page content -->
<center>
  '.$sMain.'
</center>

<!-- end page content -->

</div>
<div id="content2">
&nbsp;
</div>



<div id="footer">  <br />
<!-- it\'d be super if you left this link intact -->

<a href="http://www.dream-logic.com">Web Design by dreamLogic</a> |
<a href="#">Privacy Policy</a> |
<a href="#">Terms and Conditions</a>
</div>

<!-- end container -->
</div>


<!-- end wrap-->
</div>

</body>
</html>';
    }
  }
}
?>