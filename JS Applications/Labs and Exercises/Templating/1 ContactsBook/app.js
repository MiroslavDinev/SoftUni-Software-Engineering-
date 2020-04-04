import {contacts} from "./contacts.js";

(() =>{

    renderContacts();

    async function renderContacts(){
        const contactsBlock = document.getElementById("contacts");
    
        const source = await fetch("./all-contacts.hbs")
        .then(res=>res.text());
    
        const template = Handlebars.compile(source);
        const context = {contacts};
        const html = template(context);
    
        contactsBlock.innerHTML = html;

        Array.from(document.getElementsByClassName("detailsBtn")).map(x=>x.addEventListener("click",function(){
            let infoDiv = this.parentNode.getElementsByClassName("details")[0];
            if(this.textContent === "Details"){
                this.textContent = "Back";
                infoDiv.style.display = "block";
            }
            else{
                this.textContent = "Details";
                infoDiv.style.display = "";
            }
        }));
}
})();