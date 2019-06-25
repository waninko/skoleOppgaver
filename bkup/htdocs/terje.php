<?php
//$DB = new DB_Sql();
$module = $_GET['module'];

if ($module == "kake") {
    kake();
} else if ($module == "pizza") {
    pizza();
} else {
    echo "{error: 'ukjent module: $module'}";
}

function kake()
{
    $id = $_GET['id'];
    echo "Kake " . $id;
    // echo jsonFromResultset("select id,kakenavn,kokk from kake where id=@id", $id, "id,kakenavn,kokk");
    $row = new stdClass();
    $fieldName = "Navn";
    $row->{$fieldName} = "Terje";
    echo json_encode($row);
}

function pizza()
{
    $id = $_GET['id'];
    echo "Pizza " . $id;
}

function jsonFromResultset($sql, $params, $fields)
{
    $DB->prepareAndExecute($sql, $params);
    $dataArray = [];
    $fieldArray = explode($field, ",");

    do {
        $row = new stdClass();
        foreach ($field as $fields) {
            $row->{$field} = $DB1->getField($field);
        }
        $dataArray[] = $row;
    } while ($DB->MoveNext());
    return json_encode($dataArray);
}
