require('../models/clue');
var mongoose = require('mongoose');
var Clue = mongoose.model("Clue");

var newClue1 = new Clue({
	treasure_hunt_id: 15,
	clue_sequence: 15,
	clue: "under the bed",
	longitude: 78.989,
	latitude: 65.989
});

Clue.db.collection("clues", newClue1 );

newClue1.save( function(err,doc){
	console.log("Is Document new? " + newClue1.isNew);
	console.log("\nSaved document: " + doc);
});

Clue.create(newClue1, function(err, doc){
	console.log("\nCreated document: " + doc);
});


const Browser = require('zombie');
Browser.localhost('localhost', 3000);

describe('API test', function() {

  const browser = new Browser();

  before(function(done) {
    browser.visit('/clue/15/15', done);
  });

  describe('make a request to GameData:15:15', function() {

    it('should see data GameData:1:1', function() {
      browser.assert.text('title', 'GameData:15:15:Clue 1:78.989:65.989');
    });
  });
});
