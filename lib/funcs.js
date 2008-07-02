function getContrast(color) {
  var colors = color.split(",");
  
  var outR,outG,outB;
  outR = (colors[0]>150)?0:255;
  outG = (colors[1]>150)?0:255;
  outB = (colors[2]>150)?0:255;

  return outR+","+outG+","+outB;
}