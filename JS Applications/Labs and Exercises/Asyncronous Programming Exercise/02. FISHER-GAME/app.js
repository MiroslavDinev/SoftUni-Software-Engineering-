function attachEvents() {
    let catchesDiv = document.querySelector("#catches");
    
    let addFormEntries = {
        anglerInputElement : () => document.querySelector("#addForm > input.angler"),
        weigthInputElement : () => document.querySelector("#addForm > input.weight"),
        speciesInputElement : () => document.querySelector("#addForm > input.species"),
        locationInputElement : () => document.querySelector("#addForm > input.location"),
        baitInputElement : () => document.querySelector("#addForm > input.bait"),
        captureTimeElement : () => document.querySelector("#addForm > input.captureTime"),
        addBtn : () => document.querySelector("#addForm > button"),
        loadBtn : () => document.querySelector("body > aside > button")
    };

    addFormEntries.addBtn().addEventListener("click", addCatchToDb);
    addFormEntries.loadBtn().addEventListener("click",listAllCatches);

    function addCatchToDb() {

        let angler = addFormEntries.anglerInputElement().value;
        let weight = addFormEntries.weigthInputElement().value;
        let species = addFormEntries.speciesInputElement().value;
        let location = addFormEntries.locationInputElement().value;
        let bait = addFormEntries.baitInputElement().value;
        let captureTime = addFormEntries.captureTimeElement().value;

        if(angler && weight && species && location && bait && captureTime) {
            let headers = {
                method : "POST",
                headers : {
                    "Content-Type" : "application/json"
                },
                body : JSON.stringify({angler, bait, captureTime, location, species, weight})
            };

            fetch("https://fisher-game.firebaseio.com/catches.json",headers)
            .then()
            .catch(console.error);
        }
    }

    function listAllCatches() {
        fetch("https://fisher-game.firebaseio.com/catches.json")
        .then(res=>res.json())
        .then(data => {
            Object.entries(data).forEach(currArr=>{
                let [id, catchData] = currArr;
                let {angler, bait, captureTime, location, species, weight} = catchData;
                let catchElement = createEntryDisplayElement(id,angler, bait, captureTime, location, species, weight);
                catchesDiv.appendChild(catchElement);
            });
        })
        .catch(console.error);
    }

    function createEntryDisplayElement(id,angler, bait, captureTime, location, species, weight) {
        let catchDiv = document.createElement("div");
        catchDiv.classList.add("catch");
        catchDiv.setAttribute("data-id", id);

        let anglerLabel = document.createElement("label");
        anglerLabel.textContent = "Angler";

        let anglerInput = document.createElement("input");
        anglerInput.type = "text";
        anglerInput.classList.add("angler");
        anglerInput.value = angler;

        let anglerHr = document.createElement("hr");

        let weightLabel = document.createElement("label");
        weightLabel.textContent = "Weight";

        let weigthInput = document.createElement("input");
        weigthInput.type = "number";
        weigthInput.classList.add("weigth");
        weigthInput.value = weight;

        let weigthHr = document.createElement("hr");

        let speciesLabel = document.createElement("label");
        speciesLabel.textContent = "Species";

        let speciesInput = document.createElement("input");
        speciesInput.type = "text";
        speciesInput.classList.add("species");
        speciesInput.value = species;

        let speciesHr = document.createElement("hr");

        let locationLabel = document.createElement("label");
        locationLabel.textContent = "Location";

        let locationInput = document.createElement("input");
        locationInput.type = "text";
        locationInput.classList.add("location");
        locationInput.value = location;

        let locationHr = document.createElement("hr");

        let baitLabel = document.createElement("label");
        baitLabel.textContent = "Bait";

        let baitInput = document.createElement("input");
        baitInput.type = "text";
        baitInput.classList.add("bait");
        baitInput.value = bait;

        let baitHr = document.createElement("hr");

        let captureLabel = document.createElement("label");
        captureLabel.textContent = "Capture Time";

        let captureInput = document.createElement("input");
        captureInput.type = "number";
        captureInput.classList.add("captureTime");
        captureInput.value = captureTime;

        let captureHr = document.createElement("hr");

        let updateBtn = document.createElement("button");
        updateBtn.classList.add("update");
        updateBtn.textContent = "Update";

        let deleteBtn = document.createElement("button");
        deleteBtn.classList.add("delete");
        deleteBtn.textContent = "Delete";

        catchDiv.appendChild(anglerLabel);
        catchDiv.appendChild(anglerInput);
        catchDiv.appendChild(anglerHr);

        catchDiv.appendChild(weightLabel);
        catchDiv.appendChild(weigthInput);
        catchDiv.appendChild(weigthHr);

        catchDiv.appendChild(speciesLabel);
        catchDiv.appendChild(speciesInput);
        catchDiv.appendChild(speciesHr);

        catchDiv.appendChild(locationLabel);
        catchDiv.appendChild(locationInput);
        catchDiv.appendChild(locationHr);

        catchDiv.appendChild(baitLabel);
        catchDiv.appendChild(baitInput);
        catchDiv.appendChild(baitHr);

        catchDiv.appendChild(captureLabel);
        catchDiv.appendChild(captureInput);
        catchDiv.appendChild(captureHr);

        catchDiv.appendChild(updateBtn);
        catchDiv.appendChild(deleteBtn);
        
        updateBtn.addEventListener("click", updateEntry);
        deleteBtn.addEventListener("click",deleteEntry);

        return catchDiv;
    }

    function updateEntry() {
        let idNeeded = this.parentNode.getAttribute("data-id");
        
        let headers = {
            method : "PUT",
            headers : {
                "Content-Type" : "application/json"
            },
            body : JSON.stringify({angler:this.parentNode.children[1].value, bait:this.parentNode.children[13].value, captureTime:this.parentNode.children[16].value, location:this.parentNode.children[10].value, species:this.parentNode.children[7].value, weight:this.parentNode.children[4].value})
        };

        fetch(`https://fisher-game.firebaseio.com/catches/${idNeeded}.json`,headers)
        .then(()=>{
            catchesDiv.innerHTML="";
            listAllCatches();
        })       
        .catch(console.error);
    }

    function deleteEntry() {
        let idNeeded = this.parentNode.getAttribute("data-id");
        let parentElement = this.parentNode;
        let catchDiv = this.parentNode.parentNode;

        let headers = {
            method : "DELETE"
        };

        fetch(`https://fisher-game.firebaseio.com/catches/${idNeeded}.json`,headers)
        .then(res=>{
            catchDiv.removeChild(parentElement);
        })
        .catch(console.error);       
    }
}

attachEvents();