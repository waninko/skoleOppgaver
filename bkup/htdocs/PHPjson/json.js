function submitForm() {
    var name = document.getElementById('name').value;
    var comment = document.getElementById('comment').value;
    var FormData = {
        name: name,
        comment: comment
    };

    var jsonData = JSON.stringify(FormData);
    console.log(jsonData);


    return false;
};

var recievedFromServer = '{"name" : "recieved name test", "comment" : "recieved test dummycomment"}';
var obj = JSON.parse(recievedFromServer);
document.getElementById("testoutput").innerHTML = obj.name + " - " + obj.comment;

