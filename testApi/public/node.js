
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
		$('#wiadom').val('');
		}
		updateScroll();
	});
	
	socket.on('newUsersList', function(message)
	{
		//TO DO: usuniecie i wyswietlenie w calosci nowej listy uzytkownikow
		
		//wywolywana jest w momencie podania przez kogokolwiek nicku i w momencie wylogowania kogokolwiek (rowniez odswiezenie strony)
		//w ramach "bezpieczenstwa" mozna docelowo przerobić na przesylanie listy jedynie nickow, bez ID
		//na tą chwile przesylani sa wszyscy uzytkownicy, rowniez ci podlaczeni ale nie zalogowani (niezalogowani posiadaja jedynie ID)

		
		for(i = 0; i < message.length; i++)
		{
		if(i != 0)
		{
		var element =  document.createElement("p");
		element.id = "foo";
		var wiadomosc = document.createTextNode(message);
		element.appendChild(wiadomosc);
		var okno = document.getElementById("chatbox");
		okno.appendChild(element);
		}
		}
	});
  

