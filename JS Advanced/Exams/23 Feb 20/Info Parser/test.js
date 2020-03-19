const Parser = require("../Problem 2/solution");
const assert = require("chai").assert;

describe("Parser", function(){
    it("tests initializes correctly", function(){
        let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
        assert.isObject(parser);
        assert.property(parser,"_data");
        assert.property(parser,"_log");
        assert.property(parser,"_addToLog");
        assert.isFunction(parser._addToLog);
        assert.isFunction(parser._addToLogInitial());
        assert.deepEqual(parser._data,[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]);
        assert.deepEqual(parser._log,[]);
        assert.deepEqual(parser._addToLog(),"Added to log");
    });
    it("tests gat data returns correct result", function(){
        let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
        const msg = parser.data;
        assert.deepEqual(msg,[{"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"}]);
    });
    it("tests addEntries(entries) adds correctly", function(){
        let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
        const msg = parser.addEntries("Steven:tech-support Edd:administrator");
        assert.deepEqual(parser._addToLog(),"Added to log");
        assert.equal(msg,"Entries added!");
        assert.deepEqual(parser._data,[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"}, {"Steven":"tech-support"}, {"Edd":"administrator"} ]);
        assert.deepEqual(parser._log[0],"0: addEntries");
        const msg1 = parser.data;
        assert.deepEqual(msg1,[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"}, {"Steven":"tech-support"}, {"Edd":"administrator"} ]);
    });
    it("tests removeEntry(key) throws error", function(){
        let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
        assert.throw(()=>parser.removeEntry("Gosho"),"There is no such entry!");
    }); 
    it("tests removeEntry(key) returns correct msg", function(){
        let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
        const msg = parser.removeEntry("Kate");
        assert.equal(msg,"Removed correctly!");
    }); 
    it("tests removeEntry(key) works correctly", function(){
        let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
        parser.removeEntry("Kate");
        assert.deepEqual(parser._data,[ {"Nancy":"architect"},{"John":"developer"},{"Kate":"HR","deleted":true}]);
        assert.deepEqual(parser._addToLog(),"Added to log");
    }); 
    it("tests _addToLog(command) works correctly", function(){
        let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
        parser._addToLog("Test");
        parser._addToLog("Test1");
        assert.deepEqual(parser._addToLog(),"Added to log");
        assert.deepEqual(parser._log[0],"0: Test");
        assert.deepEqual(parser._log[1],"1: Test1");
    });	
    it("tests print() works correctly", function(){
        let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
        parser.removeEntry("Kate");
        assert.deepEqual(parser._addToLog(),"Added to log");
        const msg = parser.print();
        let expected = [];
        expected.push("id|name|position");
        expected.push("0|Nancy|architect");
        expected.push("1|John|developer");
        assert.equal(msg,expected.join("\n"));
    });
});