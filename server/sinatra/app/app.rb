ENV['RACK_ENV'] ||= "development"

require 'sinatra/base'
require_relative 'data_mapper_setup'

class Database < Sinatra::Base
  enable :sessions
  set :session_secret, 'super secret'

  get '/' do
    @treasurehunts = Treasurehunt.all
    erb :index
  end

  get '/hunts/edit' do
    session["TreasureHuntID"] = params["TreasureHuntID"].to_i
    @treasure_hunt = Treasurehunt.all(:id => session["TreasureHuntID"])
    @clues = Clue.all(:treasurehunt_id => session["TreasureHuntID"])
    erb :'hunts/edit'
  end

  post '/hunts/edit' do
    Clue.add(session["TreasureHuntID"], params[:clueText], params[:longitude].to_f, params[:latitude].to_f)
    redirect '/'
  end

  get '/hunts/new' do
    erb :'hunts/new'
  end

  post '/hunts/new' do
    Treasurehunt.create(:title => params["title"])
    redirect '/'
  end

  get '/set' do
    Clue.return_object(params["TreasureHuntID"].to_i, params["ClueID"].to_i)
  end

  get '/menu' do
    Treasurehunt.return_object(params["Longitude"], params["Latitude"])
  end

  run! if app_file == $0
end
