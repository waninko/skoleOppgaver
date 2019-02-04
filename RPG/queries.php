<?php
$db = mysqli_connect('localhost', 'root', '', 'rpg', 3307, null);
$jsonEnemyId = json_decode(file_get_contents("php://input")); //json id fra js
$getEnemy = mysql_query("SELECT type, img
FROM enemies WHERE id = $jsonEnemyId");