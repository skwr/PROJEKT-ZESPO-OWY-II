
	var form = document.getElementById('wiadomosc');		//zapisanie formularza jako zmienna
	
	var socket = io.connect();	//ustanowienie polaczenia socket.io
	
	
	
	form.onsubmit = function(e)
	{
		
		
		var text = document.getElementById('wiadom').value;	//zapisanie wartosci pola tekstowego jako zmienna
		socket.emit('clientMessage', text);
		e.preventDefault();
		
	};
	
	socket.on('newMessage', function(message)
	{	
		//wywoluje się w momencie otrzymania nowej wiadomosci
		
		console.log('socket - ' + message);
	});
