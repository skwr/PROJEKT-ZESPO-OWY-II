
	var form = document.getElementById('wiadomosc');		//zapisanie formularza jako zmienna
	
	var socket = io.connect();	//ustanowienie polaczenia socket.io
	
	
	
	form.onsubmit = function(e)
	{
		
		
		var text = document.getElementById('wiadom').value;	//zapisanie wartosci pola tekstowego jako zmienna
		socket.emit('clientMessage', text);
		e.preventDefault();
		
<<<<<<< HEAD
=======
		http.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");	//konfiguracja żądania
		
		http.onreadystatechange = function()
		{
			if(http.readyState == 4 && http.status == 200)
			{
			}
		}
		
		http.send(params);	//przesyłanie żądania 
>>>>>>> cba6729be30be207d6d4a757c25a73b5275e822a
	};
	function updateScroll()
   	{
   		var element = document.getElementById("chatbox");
    		element.scrollTop = element.scrollHeight;
	}
	socket.on('newMessage', function(message)
	{	
		if(message.length != 0)
		{
		var element =  document.createElement("p");
		element.id = "foo";
		var wiadomosc = document.createTextNode(message);
		element.appendChild(wiadomosc);
		var okno = document.getElementById("chatbox");
		okno.appendChild(element);
		updateScroll();
		}
		
	});
