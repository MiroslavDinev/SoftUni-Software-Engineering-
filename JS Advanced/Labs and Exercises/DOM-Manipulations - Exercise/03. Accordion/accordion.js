function toggle() {
    let button = document.getElementsByTagName("span")[0];
    let msgDiv = document.getElementById("extra");
    
    if(button.textContent === "More"){
        button.textContent = "Less";
        msgDiv.style.display = "block";
    }
    else{
        button.textContent = "More";
        msgDiv.style.display = "none";
    }
}