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
	io.sockets.emit('newUsersList', users);
  });
  
  socket.on('clientMessage', function(data){
	console.log('[' + socket.id + '] [' + users[findUserInArray(socket.id)].name + '] wysłał wiadomość: ' + data)	//log tresci przekazanej w żądaniu
	//message = data;	//wyłuskanie wiadomosci z tresci przekazanej w żądaniu
	
	message = 
	{
		"contents":data,
		"sender": users[findUserInArray(socket.id)].name
	};
	
	io.sockets.emit('newMessage', message);	//wywolanie eventu socket.io - rozeslanie zdobytej wiadomosci do wszystkich podlaczonych clientów
	});
	
	socket.on('login', function(data){
		users[findUserInArray(socket.id)].name = data;
		console.log('zalogowano ' + socket.id + ' jako: ' + data);
		io.sockets.emit('newUsersList', users);
	});
});




app.use(bodyParser.urlencoded({ extended: true }));		//przypisanie parsera


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
	console.log('client connected [' + socket.id + ']');
	var elem = {"id":socket.id, "name":""};
	users.push(elem);
	
	
}

function onDisconnect(socket)
{
	//wywolywane w momencie odlaczenia dowolnego clienta od servera
	
	console.log('client disconnected: [' + socket.id + '] [' + users[findUserInArray(socket.id)].name + ']');
	users.splice(findUserInArray(socket.id), 1);
	
	
}

function findUserInArray(id)
{
	var index = -1;
	
	var i = 0;
	while(index < 0 && i < users.length)
	{
		if(users[i].id === id)
		{
			index = i;
		}
		i++;
	}
	
	return index;
}


