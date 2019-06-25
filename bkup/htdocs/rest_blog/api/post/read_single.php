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

//Get ID fra URL
$post->id = isset($_GET['id']) ? $_GET['id'] : die();

$post->read_single();

//make array
$post_arr = array(
    'id'=> $post->id,
    'title'=> $post->title,
    'body'=> $post->body,
    'author'=> $post->author,
    'category_id'=> $post->category_id,
    'category_name'=> $post->category_name
);
//make JSON
print_r(json_encode($post_r));