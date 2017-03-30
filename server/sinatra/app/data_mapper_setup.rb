require 'dm-postgres-adapter'
require 'data_mapper'
require_relative 'models/clue'
require_relative 'models/treasurehunt'


DataMapper.setup(:default, ENV['DATABASE_URL'] || "postgres://localhost/treasure_#{ENV['RACK_ENV']}")
DataMapper.finalize
DataMapper.auto_upgrade!
