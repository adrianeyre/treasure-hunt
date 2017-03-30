class Clue

  include DataMapper::Resource

  belongs_to :treasurehunt,      required: true

  property :id,                  Serial
  property :clueID,              Integer, required: true
  property :clueText,            String, required: true
  property :longitude,           Float, required: true
  property :latitude,            Float, required: true

  def self.return_object(treasureID, clueID)
    clue = Clue.all(:treasurehunt_id => treasureID, :clueID => clueID)
    if clue.empty?
      "GameComplete:#{treasureID}:#{clueID}"
    else
      "GameData:#{treasureID}:#{clueID}:#{clue[0]["clueText"]}:#{clue[0]["longitude"]}:#{clue[0]["latitude"]}"
    end
  end

  def self.add(treasureID, clueText, longitude, latitude)
    clues = Clue.all(:treasurehunt_id => treasureID)
    Clue.create(treasurehunt_id: treasureID, clueID: clues.length + 1,
                clueText: clueText, longitude: longitude, latitude: latitude)
  end

end
