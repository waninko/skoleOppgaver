<?php   
    class Post{
        private $conn;
        private $table = 'posts';

        //Post properties
        public $id;
        public $category_id;
        public $category_name;
        public $title;
        public $body;
        public $author;
        public $created_at;

        //Constructor - en method som kjører automatisk når man bruker klassen
        public function __construct($db){
            $this->conn = $db;
        }

        //Get Posts
        public function read() {
            //query:
            $query = 'SELECT c.name as category_name,
                             p.id,
                             p.category_id
                             p.title,
                             p.body,
                             p.author,
                             p.created_at
                            FROM    
                                ' .$this->table . ' p
                            LEFT JOIN
                                categories c ON p.categori_id = c.id
                            ORDER BY
                                p.created_at DESC';

            //prepare statement
            $stmt = $this->conn->prepare($query);

            //execute query
            $stmt->execute();

            return $stmt;

        }
        //get single post
        public function read_single(){
            $query = 'SELECT c.name as category_name,
                             p.id,
                             p.category_id
                             p.title,
                             p.body,
                             p.author,
                             p.created_at
                     FROM    
                            ' .$this->table . 'p
                    LEFT JOIN
                            categories c ON p.categori_id = c.id
                    WHERE
                            p.id = ?
                    LIMIT 0,1';
            //prep statement        
            $stmt = $this->conn->prepare($query);

            //bind ID
            $stmt->bindParam(1, $this->id);

            //execute
            $stmt->execute();

            $row = $stmt->fetch(PDO::FETCH_ASSOC);

            //Set properties til det som er returned
            $this->title = $row['title'];
            $this->body = $row['body'];
            $this->author = $row['author'];
            $this->category_id = $row['category_id'];
            $this->category_name = $row['category_name'];

        }
        //Create Post
        public function create(){
            $query = 'INSERT INTO ' . 
                $this->table . '
                SET
                    title = :title,
                    body = :body,
                    author = :author,
                    category_id = category_id';
            
                    //clean data
            $stmt = $this->conn->prepare($query);
            $this->title = htmlspecialchars(strip_tags($this->title));
            $this->body = htmlspecialchars(strip_tags($this->body));
            $this->author = htmlspecialchars(strip_tags($this->author));
            $this->category_id = htmlspecialchars(strip_tags($this->category_id));

            //bin data
            $stmt->bindParam(':title', $this->title);
            $stmt->bindParam(':body', $this->body);
            $stmt->bindParam(':author', $this->author);
            $stmt->bindParam(':category_id', $this->category_id);

            if($stmt->execute()){
                return true;
            } //print error
            printf("error: %s.\n", $stmt->error);

            return false;
        }
    }