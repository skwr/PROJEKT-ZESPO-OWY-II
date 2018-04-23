var socket = require('socket.io');

module.exports = function(app, io, users, findUserInArray) {
  app.post('/sendMessage', (req, res) => {
	//wywolywane w momencie odebrania żądania 'sendMessage'
	
	console.log(req.body)	//log tresci przekazanej w żądaniu
	message = req.body.text;	//wyłuskanie wiadomosci z tresci przekazanej w żądaniu
	
	io.sockets.emit('newMessage', message);	//wywolanie eventu socket.io - rozeslanie zdobytej wiadomosci do wszystkich podlaczonych clientów
		
		
	res.send(message)	//odpowiedz na żądanie
	});
	
	app.post('/logMe', (req, res) => {
		
		users[findUserInArray(socket.socket.id)].name = req.body.name;
		
		console.log(req.body.name + ' logged in');
		res.send('witaj ' + req.body.name + '\n\n[ przesłane z index.js do login.js ]');
	});

};