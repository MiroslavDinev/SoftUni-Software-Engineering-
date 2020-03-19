const ChristmasMovies = require("../ChristmasMovies/02. Christmas Movies_Resources");
const assert = require("chai").assert;

describe("ChristmasMovies", function(){
    it("tests initialize correctly", function(){
        let video = new ChristmasMovies();
        assert.isObject(video);
        assert.property(video,"movieCollection");
        assert.property(video,"watched");
        assert.property(video,"actors");
        assert.deepEqual(video.movieCollection,[]);
        assert.deepEqual(video.actors,[]);
        assert.deepEqual(video.watched,{});
    });
    it("tests buyMovie(movieName, actors) throws Error", function(){
        let video = new ChristmasMovies();
        video.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci']);
        assert.throw(()=>video.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci']),"You already own Home Alone in your collection!");
    });
    it("tests buyMovie(movieName, actors) adds correctly", function(){
        let video = new ChristmasMovies();
        video.buyMovie("Home Alone", ["Macaulay Culkin", "Joe Pesci", "Joe Pesci"]);
        assert.equal(video.movieCollection.length,1);
        assert.deepEqual(video.movieCollection[0],{name:"Home Alone",actors: ["Macaulay Culkin", "Joe Pesci"]});
    });
    it("tests buyMovie(movieName, actors) returns correct msg", function(){
        let video = new ChristmasMovies();
        const msg = video.buyMovie("Home Alone", ["Macaulay Culkin", "Joe Pesci", "Joe Pesci"]);
        assert.equal(msg,"You just got Home Alone to your collection in which Macaulay Culkin, Joe Pesci are taking part!");
    });
    it("tests discardMovie(movieName) throws no such movie Error", function(){
        let video = new ChristmasMovies();
        assert.throw(()=>video.discardMovie("Home Alone"),"Home Alone is not at your collection!");
    });
    it("tests discardMovie(movieName) throws not watched movie Error", function(){
        let video = new ChristmasMovies();
        video.buyMovie("Home Alone", ["Macaulay Culkin", "Joe Pesci", "Joe Pesci"]);
        assert.throw(()=>video.discardMovie("Home Alone"),"Home Alone is not watched!");
    });
    it("tests discardMovie(movieName) removes movie from the movieCollection", function(){
        let video = new ChristmasMovies();
        video.buyMovie("Home Alone", ["Macaulay Culkin", "Joe Pesci", "Joe Pesci"]);
        video.watchMovie("Home Alone");
        video.discardMovie("Home Alone");
        assert.equal(video.movieCollection.length,0);
        assert.deepEqual(video.watched,{});
    });
    it("tests discardMovie(movieName) returns correct msg", function(){
        let video = new ChristmasMovies();
        video.buyMovie("Home Alone", ["Macaulay Culkin", "Joe Pesci", "Joe Pesci"]);
        video.watchMovie("Home Alone");
        const msg = video.discardMovie("Home Alone");
        assert.equal(msg,"You just threw away Home Alone!");
    });
    it("tests watchMovie(movieName) throws error", function(){
        let video = new ChristmasMovies();
        assert.throw(()=>video.watchMovie("Home Alone"),"No such movie in your collection!");
    });
    it("tests watchMovie(movieName) works correctly", function(){
        let video = new ChristmasMovies();
        video.buyMovie("Home Alone", ["Macaulay Culkin", "Joe Pesci", "Joe Pesci"]);
        video.watchMovie("Home Alone");
        assert.equal(video.watched["Home Alone"],1);
        video.watchMovie("Home Alone");
        assert.equal(video.watched["Home Alone"],2);
    });
    it("tests favouriteMovie() throws error", function(){
        let video = new ChristmasMovies();
        video.buyMovie("Home Alone", ["Macaulay Culkin", "Joe Pesci", "Joe Pesci"]);
        assert.throw(()=>video.favouriteMovie(),"You have not watched a movie yet this year!");
    });
    it("tests favouriteMovie() returns correct msg", function(){
        let video = new ChristmasMovies();
        video.buyMovie("Home Alone", ["Macaulay Culkin", "Joe Pesci", "Joe Pesci"]);
        video.buyMovie("Home Alone 2", ["Macaulay Culkin", "Joe Pesci", "Joe Pesci"]);
        video.watchMovie("Home Alone");
        video.watchMovie("Home Alone");
        video.watchMovie("Home Alone 2");
        const msg = video.favouriteMovie();
        assert.equal(msg,"Your favourite movie is Home Alone and you have watched it 2 times!");
    });
    it("tests mostStarredActor() throws error", function(){
        let video = new ChristmasMovies();
        assert.throw(()=>video.mostStarredActor(),"You have not watched a movie yet this year!");
    });
    it("tests mostStarredActor() returns correct msg", function(){
        let video = new ChristmasMovies();
        video.buyMovie("Home Alone", ["Macaulay Culkin", "Joe Pesci", "Joe Pesci"]);
        video.buyMovie("Home Alone 2", ["Macaulay Culkin", "Gosho", "Ivan"]);
        const msg = video.mostStarredActor();
        assert.equal(msg, "The most starred actor is Macaulay Culkin and starred in 2 movies!");
    });
});