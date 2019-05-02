var express = require('express');
var app = express();

var games = [
	{ "uid": 1, "name": "Meu primeiro jogo" },
	{ "uid": 2, "name": "Onde Estou?" },
];

var bodyParser = require('body-parser');
app.use(bodyParser.json()); // support json encoded bodies
app.use(bodyParser.urlencoded({ extended: true })); // support encoded bodies

app.get('/', function (req, res) {
	res.send(games);
});

app.post('/', function(req, res) {
	console.log("game: " + req.body.game);
});

app.listen(3000, function () {
  	console.log("listening at 3000");
});
