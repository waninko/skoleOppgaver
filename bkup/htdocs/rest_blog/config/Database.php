<?php
    class Database {
        //DB parametre
        private $host = 'localhost';
        private $db_name = 'myblog';
        private $port = 3307;
        private $username = 'root';
        private $password = '';
        private $conn;

        //sette opp connection til DB
        public function connect(){
            $this->conn=null;

            try{
                $this->conn = new PDO('mysql:host=' . $this->host . ';dbname= ' . $this->db_name,
                $this->port, $this->username, $this->password);
                $this->conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            }catch(PDOException $e){
                echo 'Conenction Error: ' . $e->getMessage();
            }
            return $this->conn;
        }
    }