var express = require('express');
var app = express();
var bodyParser = require('body-parser');
var mongoose = require('mongoose');

var port = 3000;
var db = 'mongodb://localhost/treasure'

mongoose.connect(db);

app.use(bodyParser.json())
app.use(bodyParser.urlencoded({
	extended:true
}));

app.listen(port, function() {
	console.log('listening on port ' + port);
});