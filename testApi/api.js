const express = require('express');		//dołączenie 'express'
const app = express();					//

const bodyParser = require('body-parser');	//dołączenie parsera dla tresci przesylanych przez POST

app.use(express.static('public')); //dopisanie dodatkowych plikow

var server = require('http').createServer(app);		//dołączenie servera http

var io = require('socket.io').listen(server);		//dolaczenie servera socket.io i uruchomienie nasluchiwania server

const port = 3000;	//okreslenie portu do nasluchiwania

io.sockets.on('connection', onConnect);		//wywolanie funkcji onConnect po podlaczeniu dowolnego clienta

app.use(bodyParser.urlencoded({ extended: true }));		//przypisanie parsera

require('./index.js')(app, io);		//dołączenie index.js, ktore odpowiada za odbieranie żądan POST

server.listen(port, () => {
	//wywolywane w momencie rozpoczecia nasluchiwania na porcie
	
	console.log('Listen on: ' + port);
});

app.get('/', function(req, res){
	//reakcja na żądanie GET adresu głównego strony
	res.sendFile(__dirname + '/index.html');	//odeslanie do przegladarki pliku 'index.html'
});

function onConnect(socket)
{	
	//wywolywane w momencie podlaczenia dowolnego clienta do servera
	console.log('client connected');
}


