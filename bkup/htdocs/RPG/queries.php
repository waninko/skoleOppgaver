<?php
$db = mysqli_connect('localhost', 'root', '', 'rpg', 3307, null);
if(!$db){die('connection error: '. mysqli_error($db));}
//$_POST = json_decode(file_get_contents('php://input'), true);
$data = json_decode(file_get_contents("php://input"));

$id = (int)$data->hiddenEnemyId;
//$data[isset($_POST['hiddenEnemyId']) ? $_POST['hiddenEnemyId'] : ""];
//isset($_POST['hiddenEnemyId']) ? $_POST['hiddenEnemyId'] : '';
$enemyID=2;

echo "dette ligger i PHP var'en:  "; 
var_dump($id);


$sql = "SELECT enemyType FROM enemies WHERE id = $id ";
if($result = mysqli_query($db, $sql)){
    if(mysqli_num_rows($result) > 0){
        
        while($row = mysqli_fetch_array($result)){
         
             $GLOBALS['getEnemy'] = $row['enemyType'];    
        }
        mysqli_free_result($result);

    }else {echo "Finner ingen slike felt ($id) "; }
}else {echo " feil - klarte ikke kjøre $sql. " . mysqli_error($db);}

$enemyOutput = json_encode($getEnemy);
printf($enemyOutput);
//var_dump($enemyID);
//mysqli_close($db); 