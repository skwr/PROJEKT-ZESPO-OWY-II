
	var form = document.getElementById('wiadomosc');		//zapisanie formularza jako zmienna
	
	var socket = io.connect();	//ustanowienie polaczenia socket.io
	
	
	
	form.onsubmit = function(e)
	{
		
		
		var text = document.getElementById('wiadom').value;	//zapisanie wartosci pola tekstowego jako zmienna
		socket.emit('clientMessage', text);
		e.preventDefault();
		
	};
	
	//odswiezenie scrolla do nowych wiadomosci
	function updateScroll()
   {
   		var czatowanko = document.getElementById("chatbox");
    		czatowanko.scrollTop = czatowanko.scrollHeight;
	}

 	function sendUserName(nick)
  {
	socket.emit('login', nick);
  }
  
     //wyswietlanie wiadomosci w divie + zabezpiecznie przed nowymi elementami
   //gdy brakuje tekstu
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
		}
		updateScroll();
		$('#wiadom').val('');
	});
  

