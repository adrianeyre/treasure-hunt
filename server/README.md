### Mongo DB Setup and Basic Commands

To install Mongo DB, put the following commands in the terminal:

```
brew update
brew install mongodb
```

Then set up the directory to which the `mongodb` process will write data. By default, this is the `/data/db` directory. To set up this directory, put the following commands in the terminal:

```
mkdir -p /data/db
```

N.B. You may need to `sudo` in front of the above command if you are restricted.

Then make sure the `data/db` directory has the right permissions in it by putting the following commands in the terminal:

```
sudo chown -R `id -un` /data/db
> # Enter your password
```

Then put the following command in the terminal which runs the Mongo daemon (and, in turn should start the Mongo server):

```
mongod
```
To run the Mongo shell with the Mongo daemon running in one terminal, open up a new terminal window and type `mongo` in  that other terminal. This will run the Mongo shell which is an application to access data in MongoDB.

To exit the Mongo shell run `quit()`.

To stop the Mongo daemon hit `ctrl-c`.


### Connecting to Mongo DB via a Connection String

One approach to connecting to a MongoDB using the `MongoClient` is via a connection string. With this option, you use a simple connection string to create, open and authenticate a connection to the MongoDB database.

Unlike the case of connecting to MongoDB via a `MongoClient` object, there is no need to first create an instance of the `MongoClient` object and pass the two args: `Server` object and an object specifying database connection options. The connection string method does this in the background.

To connect to MongoDB via a connection string, you need to call `connect()` method on the `MongoClient` class; no instance required. The `connect()` method uses the following syntax:

`MongoClient.connect(connString, options, callback)`

In our case, we have created a `db.js` file in the root of our project where the we have instantiated a `MongoClient` and made that object and its methods in that file available to the program.

In the `app.js` file we have required the file in and assigned it to a variable `db` as follows: `var db = require('./db')`. Then in the same `app.js` file, we connect to the database when the application starts by calling the `connect` method on our `db` variable and passing in the two arguments: `connString` (which has the the following syntax: 'mongodb://localhost:27017/<database name>') and `callback`.

In each file where database calls need to be made you will need to require in the file as follows:
`var db = require('../db')`. Clearly, the path to the `db` file will vary depending on your project structure.

To make everything work, you will need to have the Mongo daemon running in the background by passing `mongod` in another terminal.
