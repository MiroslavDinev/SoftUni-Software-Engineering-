function getInfo() {
    let stopIdElement = document.getElementById("stopId");
    let stopNameDivElement = document.getElementById("stopName");
    let busesUlElement = document.getElementById("buses");

    let url = `https://judgetests.firebaseio.com/businfo/${stopIdElement.value}.json`;

    busesUlElement.innerHTML = "";
    stopIdElement.value = "";

    fetch(url)
    .then(res => res.json())
    .then(data => {
        let {buses, name} = data;
        stopNameDivElement.textContent = name;
        Object.entries(buses)
        .forEach(([busNum, mins]) =>{
            let li = document.createElement("li");
            li.textContent = `Bus ${busNum} arrives in ${mins} minutes`;
            busesUlElement.appendChild(li);
        });
    })
    .catch(err =>{
        stopNameDivElement.textContent = "Error";
    });     
}