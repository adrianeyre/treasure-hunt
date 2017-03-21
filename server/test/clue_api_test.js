const Browser = require('zombie');
Browser.localhost('localhost', 3000);

describe('API test', function() {

  const browser = new Browser();

  before(function(done) {
    browser.visit('/clue/1/2', done);
  });

  describe('make a request to GameData:1:2:Clue 2:53.1344768:-1.2338095', function() {

    it('should see data GameData:1:2', function() {
      browser.assert.text('title', 'GameData:1:2:Clue 2:53.1344768:-1.2338095');
    });
  });
});
