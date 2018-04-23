

$( document ).ready(function() {
    $("#ok").click(function(){
		
		$("#wrapper").fadeIn(1000);
		$("#login").hide();
		
		var nick = $("#nick").val();
		sendUserName(nick);
		
		
		return false;
	});
	
});

/*function sendUserName(nick)
{
	socket.emit('login', nick);
}
*/
