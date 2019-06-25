<?php

$options = array(
	'http' => array(
		'method' => 'POST',
		'content' => json_encode($data)
		)
	);

$context = stream_context_create( $options);
$result = file_get_contents( $url, false, $context);
$response = json_decode ($result);

#var recievedFromServer = '{"name" : "recieved name test", "comment" : "recieved test dummycomment"}';

$datatest = obj; #<----- Her skal verdiene fra feltene inn! de ligger i obj var i .js fila :|
$data = array(
	'name' => 'testtt',
	'comment' => 'commenttt'
	);

?>