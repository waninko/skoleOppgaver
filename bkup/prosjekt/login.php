<?php
include("../../../lib/initiate.inc");
include(NOCACHE_H);
include(COMMON_INC_H);

session_start();

$jsonData = json_decode(file_get_contents("php://input"));
$DB = new DB_Sql();

$returnValue = new stdClass();
$returnValue->login = false;
$returnValue->name = '';

doLog($jsonData);
doLog($jsonData->username);
    
   // $DB->prepareAndExecute("SELECT visual FROM hgoffline.user WHERE username = $1 AND password = $2",
$DB->prepareAndExecute(
  "SELECT id, name FROM system.usr WHERE lower(username)=lower($1) AND password=crypt($2,password) AND disabled=0",
  [$jsonData->username, $jsonData->password]
);
if ($DB->numRows() > 0) {
  $name = $DB->getField("name");
  $id = $DB->getField("id");
  doLog($name);

  $DB->prepareAndExecute("SELECT department_id,  application_id  FROM hgoffline.usr_dep AS ud WHERE ud.id = $1", $id);
  if ($DB->numRows() > 0) {
    $returnValue->login = true;
    $_SESSION['username'] = $jsonData->username; //ta vare på login navn
    $_SESSION['usr_id'] = $id; // Saves user id
    $_SESSION['dep_id'] = $DB->getField("department_id"); //saves users department id
    $_SESSION['app_id'] = $DB->getField("application_id"); // saves users application id
    $returnValue->name = $name;

    if ($DB->getField("department_id") >= 0)
      $returnValue->page = "user.html";
    else
      $returnValue->page = "main.html";


  }
} else {
  doLog("fail");
}
printf(json_encode($returnValue));