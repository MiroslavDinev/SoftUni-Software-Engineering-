function solve() {
    let textAreas = document.getElementsByTagName("textarea");
    let inputArea = textAreas[0];
    let resultArea = textAreas[1];

    let buttons = document.getElementsByTagName("button");
    let generateBtn = buttons[0];
    let buyBtn = buttons[1];

    let boughtProducts = [];
    let totalPrice = 0;
    let totalFactor = 0.0;
    let allFactors = 0;

    let tableBody = document.getElementsByTagName("tbody")[0];
    document.getElementsByTagName("input")[0].disabled = false;
    let firstRow = document.getElementsByTagName("tr")[1];

    generateBtn.addEventListener("click", addEntry);
    buyBtn.addEventListener("click", showResult);

    function showResult() {

        let allInputBtns = document.getElementsByTagName("input");
        for (let i = 0; i < allInputBtns.length; i++) {
            if (allInputBtns[i].checked) {
                let name = tableBody.getElementsByTagName("tr")[i].getElementsByTagName("td")[1].getElementsByTagName("p")[0].textContent;
                let price = tableBody.getElementsByTagName("tr")[i].getElementsByTagName("td")[2].getElementsByTagName("p")[0].textContent;
                let factor = tableBody.getElementsByTagName("tr")[i].getElementsByTagName("td")[3].getElementsByTagName("p")[0].textContent;
                boughtProducts.push(name);
                totalPrice += +price;
                totalFactor += +factor;
                allFactors++;
            }
        }

        resultArea.value += `Bought furniture: ${boughtProducts.join(", ")}\n`;
        resultArea.value += `Total price: ${totalPrice.toFixed(2)}\n`;
        resultArea.value += `Average decoration factor: ${totalFactor / allFactors}`;
    }

    function addEntry() {
        let json = inputArea.value;
        let entries = JSON.parse(json);
        for (let currEntry of entries) {
            let newRow = firstRow.cloneNode(true);
            addFurniture(currEntry, newRow);
        }
    }

    function addFurniture(currEntry, newRow) {
        newRow.getElementsByTagName("td")[0].innerHTML = `<img src=${currEntry.img}>`;
        newRow.getElementsByTagName("td")[1].innerHTML = `<p>${currEntry.name}</p>`;
        newRow.getElementsByTagName("td")[2].innerHTML = `<p>${currEntry.price}</p>`;
        newRow.getElementsByTagName("td")[3].innerHTML = `<p>${currEntry.decFactor}</p>`;
        newRow.getElementsByTagName("td")[4].innerHTML = `<input type="checkbox"/>`;
        tableBody.appendChild(newRow);
    }
}