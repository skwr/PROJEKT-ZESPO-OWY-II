

$( document ).ready(function() {

    $("#ok").click(function(){
		$("#wrapper").fadeIn(1000);
		$("#czesc").fadeIn(2000);
		$("#users").fadeIn(2000);
		$("#koledzy").fadeIn(2000);
		$("#nameff").fadeIn(2000);
		$("#login").hide();
		var nick = $("#nick").val();
		$("#czesc").html("Witamy na czacie:  " + nick);
		sendUserName(nick);
		return false;
	});
	
});

/*function sendUserName(nick)
{
	socket.emit('login', nick);
}
*/
