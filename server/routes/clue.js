var express = require('express');
var router = express.Router();
var mongoose = require('mongoose');

var clue = require('../models/clue');

//this allows the file to access the compiled Model object: Clue
var Clue = mongoose.model("Clue");

function formatResult(clue){
	return "GameData:" + clue.treasure_hunt_id + ":" + clue.clue_sequence + ":" + clue.clue + ":" + clue.latitude + ":" + clue.longitude;
}

router.get('/:treasure_hunt_id/:clue_sequence', function(req, res, next) {

	var treasure_hunt_id = req.params.treasure_hunt_id;
	var clue_sequence = req.params.clue_sequence;

	Clue.find({ treasure_hunt_id: treasure_hunt_id, clue_sequence: clue_sequence }, function(err, results){
		if(!err){
			var returnedClue = JSON.parse(JSON.stringify(results[0]));
			res.render('clue', { title: formatResult(returnedClue) });
		}
		else{
			console.log("Error");
		}
	});

});

module.exports = router;
