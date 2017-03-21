var mongoose = require('mongoose');
var expect = require('chai').expect;
var clue = require('../models/clue');
//
//this allows the file to access the compiled Model object: Clue
var Clue = mongoose.model("Clue");


var MongoClient = require('mongodb').MongoClient;

MongoClient.connect("mongodb://localhost:27017/treasureHunt_test", function(err, db){

	var collection = db.collection("clues");

	//collection.remove({});

	var testData = {
		treasure_hunt_id: 5,
		clue_sequence: 5,
		clue: "under the bed",
		longitude: 78.989,
		latitude: 65.989
	};

	collection.insert(testData);

  describe('Clue Test', function() {

    it("should find a clue by treasure hunt id and clue sequence", function(){

      var clue = Clue.find({treasure_hunt_id: 5, clue_sequence: 5});

      //console.log("1" + clue.treasure_hunt_id);
      //console.log("2" + clue[0].treasure_hunt_id);
      console.log("3" + JSON.stringify(clue));
      var clue2 = JSON.parse(JSON.stringify(clue));

      expect(clue2.treasure_hunt_id).to.equal(5);

      // Clue.find({treasure_hunt_id: 5, clue_sequence: 5}, function(err, result){
      //
      //   console.log(result);
      //   console.log(result[0]);
      //
      //   var result2 = JSON.parse(result[0]);
      //   console.log(result2);
      //
      //   expect(result2).to.equal('bla');
      // });

    });

  });


});
