module.exports = function(app, io) {
  app.post('/sendMessage', (req, res) => {
	//wywolywane w momencie odebrania żądania 'sendMessage'
	
	console.log(req.body)	//log tresci przekazanej w żądaniu
	message = req.body.text;	//wyłuskanie wiadomosci z tresci przekazanej w żądaniu
	
	io.sockets.emit('newMessage', message);	//wywolanie eventu socket.io - rozeslanie zdobytej wiadomosci do wszystkich podlaczonych clientów
		
		
	res.send(message)	//odpowiedz na żądanie
	});

};