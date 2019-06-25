<?php
// Headers -> for å acesse med REST
header('Access-Control-Allow-Origin: *');
header('Content-Type: application/json');

include_once '../../config/Database.php';
include_once '../../models/Post.php';

//instatiate DB &connect
$database = new Database();
$db = $database->connect();

//initiate blog post
$post = new Post($db);

//blog post query
$result = $post->read();
//get row count
$num = $result->rowCount();

//check if posts
if($num > 0){
    //Post array
    $posts_arr = array();
    $posts_arr['data'] = array();

    while($row = $result->fetch(PDO::FETCH_ASSOC)){
        extract($row); // <-- extracts each row to a variable

        $post_item = array(
          'id'=> $id,
          'title'=> $title,
          'body'=> html_entity_decode($body),
          'author'=> $author,
          'category_id'=> $category_id,
          'category_name'=> $category_name
        );

        //push to "data"
        array_push($posts_arr['data'], $post_item);
    }
    //turn into JSON & output
    echo json_encode($posts_arr);
}else { 
    echo json_encode(
        array('message'=> 'No Posts Found.')
    );
}

