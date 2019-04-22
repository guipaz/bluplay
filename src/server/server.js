var express = require('express');
var app = express();

var bodyParser = require('body-parser');
app.use(bodyParser.json()); // support json encoded bodies
app.use(bodyParser.urlencoded({ extended: true })); // support encoded bodies

app.get('/', function (req, res) {
	console.log('hallo');
	res.send('[{ "uid": 1, "name": "Meu primeiro jogo" }]');
});

app.post('/', function(req, res) {
	console.log("game: " + req.body.game);
});

app.listen(3000, function () {
  	console.log("listening at 3000");
});