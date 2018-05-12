
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
		
		if(message.contents.length != 0)
		{
		var elementPierwszy =  document.createElement("p");
		elementPierwszy.id = "nazwaUzytkownika";
		var elementDrugi =  document.createElement("p");
		elementDrugi.id = "foo";
		///
		var wiadomoscPierwsza = document.createTextNode(message.sender +" napisał: ");
		elementPierwszy.appendChild(wiadomoscPierwsza);
		var wiadomoscDruga = document.createTextNode(message.contents);
		elementDrugi.appendChild(wiadomoscDruga);
		///
		var okno = document.getElementById("chatbox");
		okno.appendChild(elementPierwszy);
		okno.appendChild(elementDrugi);
		///
		$('#wiadom').val('');
		}
		updateScroll();
	});
	
	socket.on('newUsersList', function(users)
	{
		//TO DO: usuniecie i wyswietlenie w calosci nowej listy uzytkownikow
		
		//wywolywana jest w momencie podania przez kogokolwiek nicku i w momencie wylogowania kogokolwiek (rowniez odswiezenie strony)
		//w ramach "bezpieczenstwa" mozna docelowo przerobić na przesylanie listy jedynie nickow, bez ID
		//na tą chwile przesylani sa wszyscy uzytkownicy, rowniez ci podlaczeni ale nie zalogowani (niezalogowani posiadaja jedynie ID)
		
		$("#koledzy").empty()
		var i = 0;
		for(i ; i < users.length ; i++ )
		{
		var nickParagraf =  document.createElement("p");
		nickParagraf.id = "nazwaUzytkownika";
		var nick = document.createTextNode(users[i].name);
		nickParagraf.appendChild(nick)
		var oknoUzytkownicy = document.getElementById("koledzy");
		oknoUzytkownicy.appendChild(nickParagraf);
		}
});