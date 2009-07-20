/**

 @mainpage University Scheduling System (master data)
 @version 0.1
 @author Ivonne Seibt, Stephan Hilbrandt, Jan Walther
 @date 25-07-2008
 @brief source code documentation

 @defgroup JavaScript Package JS functions
 @brief frontend functions for handling user-driven events and calculate client-side
*/

/**
* @ingroup JavaScript
* @brief Function getContrast.
*
* get a contrast color to given RGB values for best readability in dependence of background color
*
* @param color (string) string of hexadecimal color without # sign (length of string is 6 -> red: 2, green: 2, blue 2)
* @return color string of the RGB values separated by commas -> ready for use in CSS rgb() function
*/
function getContrast(color) {
  var colors = color.split(",");
  
  var outR,outG,outB;
  outR = (colors[0]>150)?0:255;
  outG = (colors[1]>150)?0:255;
  outB = (colors[2]>150)?0:255;

  return outR+","+outG+","+outB;
}

/**
* @ingroup JavaScript
* @brief Function openRoomPlanning.
*
* open popup window for room planning
*
* @param url (string) url to be opened in the popup window
* @return void
*/
function openRoomPlanning(url) {
  pop = window.open('','','toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,fullscreen=0,width=800,height=400,top=0,left=0');
  pop.resizeTo(1024,768); 
  pop.moveTo(screen.availWidth / 2 - 400,screen.availHeight / 2 - 300);
  pop.location=url;
}