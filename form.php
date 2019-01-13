<!DOCTYPE html>
<html>
<head>
  <title>PHP CRUDs</title>
</head>
<body>
<? PHP
  $name = '':
  $gender = '';
  $color = '';

  if(isset($_POST['submit'])){
      $ok = true;
      if(!isset($_POST['name']) || $_POST['name'] === '' ){
        $ok = false;
      } else{
          $name = $_POST['name'];
      }

      if(!isset($_POST['gender']) || $_POST['gender'] === '' ){
        $ok = false;
      } else{
          $gender = $_POST['gender'];
      }

      if(!isset($_POST['color']) || $_POST['color'] === '' ){
        $ok = false;
      } else{
          $color = $_POST['color'];
      }

      if ($ok){
      printf('User name: %s
      <br>Gender: %s
      <br>Color: %s',
      htmlspecialchars($_POST['name']),
      htmlspecialchars($_POST['gender']),
      htmlspecialchars($_POST['color']);
   }
  }
?>
<form method="post" action="">
  User name: <input type="text" name="name" value="<?php
    echo htmlspecialchars($name);
  ?>"> <br>
  
  Gender:
    <input type="radio" name="gender" value="f" <?php
      if ($gender === 'f'){
      echo ' checked';
      }
    ?>>female
    <input type="radio" name="gender" value="m" <?php
      if ($gender === 'm'){
      echo ' checked';
      }
    ?>>male

  Favorite color:
      <select name="color">
          <option value="#f00">red</option>
          <option value="#0f0">green</option>
          <option value="#00f">blue</option>
      </select><br>
      <input type="submit" name="submit" value="submit">
  </form>
  </body>
  </html>
