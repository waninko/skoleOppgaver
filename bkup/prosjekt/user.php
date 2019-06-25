<?php
include("../../../lib/initiate.inc");
include(NOCACHE_H);
include(COMMON_INC_H);

session_start();

$username = $_SESSION['username'];
$usr_id = $_SESSION['usr_id'];
$dep_id = $_SESSION['dep_id'];
$app_id = $_SESSION['app_id'];
$selectedDep =  $_SESSION['selected_dep'];

$DB = new DB_Sql();
$jsonData = json_decode(file_get_contents("php://input"));

$DB->prepareAndExecute("SELECT visual, id FROM hgoffline.user hu WHERE hu.application_id=$1 AND hu.department=$2", [$app_id, $dep_id]);
//select visual, id FROM hgoffline.user hu WHERE hu.department=$2", $selectedDep;

if ($DB->getField("department") >= 0) {
    do {
        $row = new stdClass();
        $row->name = $DB->getField("visual");
        $row->id = $DB->getField("id");
        $dataArray[] = $row;
    } while ($DB->MoveNext());
}
/*else if($DB->getField("department") == -1){
    do {
        $row = new stdClass();
        $row->name = $DB->getField("visual");
        $row->id = $DB->getField("id");
    
        
        $dataArray[] = $row;
    }while ($DB->MoveNext());
}*/

dolog($selectedDep);
$user = json_encode($dataArray);
echo $user;