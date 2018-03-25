const express = require('express');
const MonoClient = require('mongodb').MongoClient;
const bodyParser = require('body-parser');

const app = express();

express.static('public');

const port = 3000;



app.use(bodyParser.urlencoded({ extended: true }));

require('./app/routes')(app, {});

app.listen(port, () => {
	console.log('Listen on: ' + port);
});

app.get('/', function(req, res){
	res.sendFile(__dirname + '/index.html');
});