class Treasurehunt

  include DataMapper::Resource

  has n, :clues

  property :id,                  Serial
  property :title,               String, required: true

  def self.return_object(longitude, latitude)
    hunts = Treasurehunt.all
    hunts.map {|hunt| hunt["title"]}.join(":")
  end

end
