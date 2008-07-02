function getContrast(color) {
  var colors = color.split(",");
  
  var outR,outG,outB;
  outR = (colors[0]>150)?0:255;
  outG = (colors[1]>150)?0:255;
  outB = (colors[2]>150)?0:255;

  return outR+","+outG+","+outB;
}

function openRoomPlanning(url) {
  pop = window.open('','','toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,fullscreen=0,width=800,height=400,top=0,left=0');
  pop.resizeTo(1024,768); 
  pop.moveTo(screen.availWidth / 2 - 400,screen.availHeight / 2 - 300);
  pop.location=url;
}