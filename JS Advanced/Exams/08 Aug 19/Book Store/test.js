const BookStore = require("../Book Store/02. Book Store_Ресурси");
const assert = require("chai").assert;

describe("BookStore" , function(){
    it("test constructor works properly", function(){
        let store = new BookStore('Store');
        assert.isObject(store);
        assert.property(store, "name");
        assert.property(store, "books");
        assert.property(store, "workers");
        assert.equal(store.name, "Store");
        assert.deepEqual(store.books,[]);
        assert.deepEqual(store.workers,[]);
    });
    it("tests stockBooks() to add correctly", function(){
        let store = new BookStore('Store');
        const result = store.stockBooks(['Inferno-Dan Braun']);
        assert.equal(store.books.length,1);
        assert.deepEqual(result,[{title: "Inferno", author: "Dan Braun"}]);
    });
    it("tests hire() throws Error", function(){
        let store = new BookStore('Store');
        store.hire('George', 'seller');
        assert.throw(()=> store.hire('George', 'seller'),'This person is our employee');
    });
    it("tests hire() adds correctly", function(){
        let store = new BookStore('Store');
        store.hire('George', 'seller');
        assert.equal(store.workers.length,1);
        assert.deepEqual(store.workers[0].name, "George");
        assert.deepEqual(store.workers[0].position, "seller");
        assert.deepEqual(store.workers[0].booksSold, 0);
    });
    it("tests hire() returns correct msg", function(){
        let store = new BookStore('Store');
        const msg = store.hire('George', 'seller');
        assert.equal(msg,"George started work at Store as seller");
    });
    it("tests fire() throws Error", function(){
        let store = new BookStore('Store');
        assert.throw(()=> store.fire("Pesho"),"Pesho doesn't work here");
    });
    it("tests fire() removes correctly", function(){
        let store = new BookStore('Store');
        store.hire('George', 'seller');
        store.fire("George");
        assert.equal(store.workers.length,0);
    });
    it("tests fire() return correct msg", function(){
        let store = new BookStore('Store');
        store.hire('George', 'seller');
        const msg = store.fire("George");
        assert.equal(msg,"George is fired");
    });
    it("tests sellBook() throws Error for book", function(){
        let store = new BookStore('Store');
        assert.throw(() => store.sellBook("Book", "Pesho"));
    });
    it("tests sellBook() throws Error for worker", function(){
        let store = new BookStore('Store');
        store.stockBooks(["Book1-Author1"]);
        assert.throw(() => store.sellBook("Book1", "Pesho"));
    });
    it("tests sellBook() works correctly", function(){
        let store = new BookStore('Store');
        store.stockBooks(["Book1-Author1"]);
        store.hire("Pesho", "seller");
        store.sellBook("Book1", "Pesho");
        assert.equal(store.books.length,0);
        assert.equal(store.workers[0].booksSold,1);
    });
    it("tests printWorkers() return correct msg", function(){
        let store = new BookStore('Store');
        store.hire("Pesho", "seller");
        let expected = "Name:Pesho Position:seller BooksSold:0";
        assert.equal(store.printWorkers(), expected);
    });
});