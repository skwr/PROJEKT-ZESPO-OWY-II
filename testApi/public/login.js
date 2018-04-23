

$( document ).ready(function() {
    $("#ok").click(function(){
		
		$("#wrapper").fadeIn(1000);
		$("#login").hide();
		
		var nick = $("#nick").val();
		sendUserName(nick);
		
		
		return false;
		
		
	});
	$("#submit").click(function()
	{
		var scrollowanko = $("#foo");
		
		
	
	});
	
});

function sendUserName(nick)
{
	socket.emit('login', nick);
}