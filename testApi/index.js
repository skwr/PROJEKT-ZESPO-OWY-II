
//const noteRoutes = require('./note_routes');
module.exports = function(app, io) {
  app.post('/notes', (req, res) => {
		console.log(req.body)
		message = req.body.text;
		io.sockets.emit('res', message);
		
		
		
		
	
		res.send(message)
	});
  
  //noteRoutes(app, db);
  
  // Other route groups could go here, in the future
};