
	var form = document.getElementById('wiadomosc');		//zapisanie formularza jako zmienna
	
	var socket = io.connect();	//ustanowienie polaczenia socket.io
	
	
	
	form.onsubmit = function(e)
	{
		//wykonuje się w momencie zaakceptowania formularza (po nacisnieciu przycisku)
		
		var text = document.getElementById('wiadom');	//zapisanie pola tekstowego jako zmienna
		e.preventDefault();	//blokada przeładowywania strony po zaakceptowaniu formularza
				
		var http = new XMLHttpRequest();	//utworzenie obiektu żądania
		var url = '/sendMessage';	//okreslenie adresu POST
		
		var params = 'text=' + text.value;	//tworzenie tresci przekazywanej za pomoca POST
		http.open("POST", url, true);	//ustanowienie polaczenia
		
		http.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");	//konfiguracja żądania
		
		http.onreadystatechange = function()
		{
			if(http.readyState == 4 && http.status == 200)
			{
			}
		}
		
		http.send(params);	//przesyłanie żądania 
	};
	
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
	});
