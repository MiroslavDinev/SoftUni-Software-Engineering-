let SkiResort = require('./solution');
const assert = require("chai").assert;

describe('SkiResort', function () {
    it("tests initializes correctly", function(){
        let resort = new SkiResort("Borovetz");
        assert.isObject(resort);
        assert.equal(resort.name,"Borovetz");
        assert.property(resort,"name");
        assert.property(resort,"voters");
        assert.property(resort,"hotels");
        assert.equal(resort.voters,0);
        assert.deepEqual(resort.hotels,[]);
    });
    it("tests build(name, beds) throws name error", function(){
        let resort = new SkiResort("Borovetz");
        assert.throw(()=>resort.build("",1),"Invalid input");
    });
    it("tests build(name, beds) throws beds error", function(){
        let resort = new SkiResort("Borovetz");
        assert.throw(()=>resort.build("Some",0),"Invalid input");
    });
    it("tests build(name, beds) adds correctly", function(){
        let resort = new SkiResort("Borovetz");
        resort.build("Some",1);
        assert.equal(resort.hotels.length,1);
        assert.deepEqual(resort.hotels[0],{name:"Some",beds:1,points: 0});
    });
    it("tests build(name, beds) return correct msg", function(){
        let resort = new SkiResort("Borovetz");
        const msg = resort.build("Some",1);
        assert.equal(msg,"Successfully built new hotel - Some");
    });
    it("tests book(name, beds) throws name error", function(){
        let resort = new SkiResort("Borovetz");
        assert.throw(()=>resort.book("",1),"Invalid input");
    });
    it("tests book(name, beds) throws beds error", function(){
        let resort = new SkiResort("Borovetz");
        assert.throw(()=>resort.book("Some",0),"Invalid input");
    });
    it("tests book(name, beds) throws no such hotel error", function(){
        let resort = new SkiResort("Borovetz");
        assert.throw(()=>resort.book("Some",1),"There is no such hotel");
    });
    it("tests book(name, beds) throws not enough beds", function(){
        let resort = new SkiResort("Borovetz");
        resort.build("Some",1);
        assert.throw(()=>resort.book("Some",2),"There is no free space");
    });
    it("tests book(name, beds) works correctly", function(){
        let resort = new SkiResort("Borovetz");
        resort.build("Some",1);
        resort.book("Some",1);
        assert.deepEqual(resort.hotels[0].beds,0);
    });
    it("tests book(name, beds) return correct msg", function(){
        let resort = new SkiResort("Borovetz");
        resort.build("Some",1);
        const msg = resort.book("Some",1);
        assert.equal(msg,"Successfully booked");
    });
    it("tests leave(name, beds, points) throws name error", function(){
        let resort = new SkiResort("Borovetz");
        assert.throw(()=>resort.leave("",1,1),"Invalid input");
    });
    it("tests leave(name, beds, points) throws beds error", function(){
        let resort = new SkiResort("Borovetz");
        assert.throw(()=>resort.leave("Some",0,1),"Invalid input");
    });
    it("tests leave(name, beds, points) throws no such hotel error", function(){
        let resort = new SkiResort("Borovetz");
        assert.throw(()=>resort.leave("Some",1,1),"There is no such hotel");
    });
    it("tests leave(name, beds, points) works correctly", function(){
        let resort = new SkiResort("Borovetz");
        resort.build("Some",10);
        resort.book("Some",5);
        resort.leave("Some",5,10);
        assert.deepEqual(resort.hotels[0].points,50);
        assert.deepEqual(resort.hotels[0].beds,10);
        assert.equal(resort.voters,5);
    });
    it("tests leave(name, beds, points) returns correct msg", function(){
        let resort = new SkiResort("Borovetz");
        resort.build("Some",10);
        resort.book("Some",5);
        const msg = resort.leave("Some",5,10);
        assert.equal(msg,"5 people left Some hotel");
    });
    it("tests averageGrade() with no voters", function(){
        let resort = new SkiResort("Borovetz");
        const msg = resort.averageGrade();
        assert.equal(msg, "No votes yet");
    });
    it("tests averageGrade() with voters", function(){
        let resort = new SkiResort("Borovetz");
        resort.build("Some",10);
        resort.book("Some",5);
        resort.leave("Some",5,10);
        const msg = resort.averageGrade();
        assert.equal(msg, "Average grade: 10.00");
    });
    it("tests get bestHotel() with no voters", function(){
        let resort = new SkiResort("Borovetz");
        const msg = resort.bestHotel;
        assert.equal(msg, "No votes yet");
    });
    it("tests get bestHotel() with voters", function(){
        let resort = new SkiResort("Borovetz");
        resort.build("Some",10);
        resort.book("Some",5);
        resort.leave("Some",5,10);
        resort.build("Other",2);
        resort.book("Other",1);
        resort.leave("Other",1,4);
        const msg = resort.bestHotel;
        assert.equal(msg, "Best hotel is Some with grade 50. Available beds: 10");
    });
});
