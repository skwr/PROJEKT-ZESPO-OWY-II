const express = require('express');
const MonoClient = require('mongodb').MongoClient;
const bodyParser = require('body-parser');

const app = express();

var server = require('http').createServer(app);
var io = require('socket.io').listen(server);

express.static('public');

const port = 3000;



app.use(bodyParser.urlencoded({ extended: true }));

//require('./app/routes')(app, {});
require('./index.js')(app, io);

server.listen(port, () => {
	console.log('Listen on: ' + port);
});

app.get('/', function(req, res){
	res.sendFile(__dirname + '/index.html');
});




