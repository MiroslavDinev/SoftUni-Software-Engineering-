import {monkeys} from "./monkeys.js";

(() => {
    
    loadMonkeys();

    function loadMonkeys(){
        let source = document.getElementById("monkey-template").innerHTML;

        let template = Handlebars.compile(source);
        let context = {monkeys};
        let monkeysHtml = template(context);

        document.getElementsByClassName("monkeys")[0].innerHTML = monkeysHtml;
    }

    Array.from(document.getElementsByTagName("button"))
    .map(x=>x.addEventListener("click", function(){
        let infoDiv = this.parentNode.children[3];

        if(infoDiv.style.display === "block"){
            infoDiv.style.display = "none";
        }
        else{
            infoDiv.style.display = "block";
        } 
    }));
})();