var Browser = require('zombie');
Browser.localhost('localhost', 3000);

var MongoClient = require('mongodb').MongoClient;

MongoClient.connect("mongodb://localhost:27017/treasureHunt_test", function(err, db){

	var collection = db.collection("clues");

	//collection.remove({});

	var clue = {
		treasure_hunt_id: 10,
		clue_sequence: 10,
		clue: "under the bed",
		longitude: 78.989,
		latitude: 65.989
	};

	collection.insert(clue);

});




describe('API test', function() {

  var browser = new Browser();

  before(function(done) {
    browser.visit('/clue/10/10', done);
  });

  describe('make a request to GameData:10:10', function() {

    it('should see data GameData:10:10', function() {
      browser.assert.text('title', 'GameData:10:10:under the bed:65.989:78.989');
    });
  });
});
