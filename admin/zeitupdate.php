<?php
require '../lib/funcs.php';

for($i=15*60*4*24*365*30;$i<=2147483647;$i+=15*60) {
  mysql_query("INSERT INTO uhr VALUES ('".$i."')");
}
?>