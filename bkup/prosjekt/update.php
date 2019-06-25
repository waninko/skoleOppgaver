<?php
include("../../../lib/initiate.inc");
include(NOCACHE_H);
include(COMMON_INC_H);

session_start();

$username = $_SESSION['username'];
$usr_id = $_SESSION['usr_id'];
$dep_id = $_SESSION['dep_id'];
$app_id = $_SESSION['app_id'];

$DB = new DB_Sql();
$jsonData = json_decode(file_get_contents("php://input"));

$DB->prepareAndExecute("UPDATE hgoffline.user SET integrationcode = $1 WHERE condition ");
// UPDATE hgoffline . "user"
//     SET integrationcode = 'sgm'
//     WHERE id = 1 and application_id = < lovligID > and department = < lovligdep >;

// Hva vi må huske og ha med til brukeren som skal redigere - id, application_id og department.