(() => {
     renderCatTemplate();

     async function renderCatTemplate() {
         let source = await fetch("./all-cats.hbs")
         .then(res=>res.text());

         let template = Handlebars.compile(source);
         let context = {cats:window.cats};
         let catsHtml = template(context);

         document.getElementById("allCats").innerHTML = catsHtml;

         Array.from(document.getElementsByClassName("showBtn"))
         .map(x=>x.addEventListener("click",function(){
            let infoDiv = this.parentNode.children[1];

            if(this.textContent === "Show status code"){
                this.textContent = "Hide status code";
                infoDiv.style.display = "block";
            }
            else{
                this.textContent = "Show status code";
                infoDiv.style.display = "none";
            }
         }));
     }
})();