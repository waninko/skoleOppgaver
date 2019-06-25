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
$DB1->prepareAndExecute("SELECT application.name, usr_dep.department_id FROM hgoffline.application, hgoffline.usr_dep");


//doLog($dep_id);
if ($dep_id == -1) 
 { 
  do {$DB1->NumRows() > 0;
    $row = new stdClass();
    $row->name = $DB1->getField("name");
    $dataArray[] = $row;

  } while ($DB1->MoveNext()); //her skulle den stoppa når det ikke var flere names igjen i tabellen. Men nei. fire ganger til ¯\_(ツ)_/¯
} 
    else { 
  $DB->NumRows() > 0;
  do{
    $row = new stdClass();
    $row->name = $DB->getField("name");
    $dataArray[] = $row;
  }while ($DB->MoveNext());
    
}
doLog($dataArray);
printf(json_encode($dataArray));