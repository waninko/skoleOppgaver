<?php
$db = mysqli_connect('localhost', 'root', '', 'rpg', 3307, null);
$jsonData = json_decode(file_get_contents("php://input"));
$enemyID =  1;//json id fra js- på et vis
$getEnemy = mysql_query("SELECT type
FROM enemies WHERE id = $enemyID");

printf($getEnemy);
