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
$DB1 = new DB_Sql();
$jsonData = json_decode(file_get_contents("php://input"));
$dataArray = [];

$DB->prepareAndExecute("SELECT name FROM hgoffline.application WHERE id = $1 ", $app_id);
$params = [$app_id];
$whereAdd = "";
if ($dep_id >= 0) {
  $whereAdd = " AND id=$2";
  $params[] = $dep_id;
}

$DB1->prepareAndExecute("SELECT department.name, department.id FROM hgoffline.department WHERE application_id=$1" . $whereAdd, $params);

doLog($dep_id);
if ($dep_id == -1) {

  do {
    $row = new stdClass();
    $row->id = $DB1->getField("id");
    $row->name = $DB1->getField("name");

    $dataArray[] = $row;
  } while ($DB1->MoveNext());
}


$department = json_encode($dataArray);
//skal "få tak i" kun id feltet til det departmentet som velges i main over til user.php (m/session) for å kunne bruke denne i et WHERE i en sql der
$_SESSION['selected_dep'] = array_column($dataArray, 'id');


doLog(X);
printf(json_encode($dataArray));