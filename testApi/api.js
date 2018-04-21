const express = require('express');		//dołączenie 'express'
const app = express();					//

const bodyParser = require('body-parser');	//dołączenie parsera dla tresci przesylanych przez POST

app.use(express.static('public')); //dopisanie dodatkowych plikow

var server = require('http').createServer(app);		//dołączenie servera http

var io = require('socket.io').listen(server);		//dolaczenie servera socket.io i uruchomienie nasluchiwania server

const port = 3000;	//okreslenie portu do nasluchiwania

io.on('connection', function(socket){
	onConnect(socket);
	
	socket.on('disconnect', function () {
    onDisconnect(socket);
  });
});

//io.sockets.on('connection', onConnect);		//wywolanie funkcji onConnect po podlaczeniu dowolnego clienta

//io.sockets.on('disconnect', onDisconnect);	//wywolanie funkcji onDisconnect po odlaczeniu dowolnego clienta



app.use(bodyParser.urlencoded({ extended: true }));		//przypisanie parsera

require('./index.js')(app, io);		//dołączenie index.js, ktore odpowiada za odbieranie żądan POST

var users = [];

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
	console.log('client connected ' + socket.id);
	var elem = {"id":socket.id, "name":""};
	users.push(elem);
}

function onDisconnect(socket)
{
	//wywolywane w momencie odlaczenia dowolnego clienta od servera
	
	var index = -1;
	
	var i = 0;
	while(index < 0 && i < users.length)
	{
		if(users[i].id === socket.id)
		{
			index = i;
		}
		i++;
	}
	users.splice(index, 1);
	
	console.log('client disconnected ' + socket.id);
}


