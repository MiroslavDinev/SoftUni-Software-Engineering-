function solve() {

    let numberInput = document.getElementById("input");
    let selectMenuElement = document.getElementById("selectMenuTo");
    let firstOption = document.createElement("option");
    firstOption.value = "binary";
    firstOption.textContent = "Binary";
    selectMenuElement.appendChild(firstOption);
    let secondOption = document.createElement("option");
    secondOption.value = "hexadecimal";
    secondOption.textContent = "Hexadecimal";
    selectMenuElement.appendChild(secondOption);

    let resultArea = document.getElementById("result");

    let convertBtn = document.getElementsByTagName("button")[0];
    convertBtn.addEventListener("click", function convertNums() {
        let numberToConvert = Number(numberInput.value);
        let result;
        let currentSelection = selectMenuElement.options[selectMenuElement.selectedIndex].text;
        if (currentSelection === "Binary") {
            result = (numberToConvert >>> 0).toString(2);
        }
        else if (currentSelection === "Hexadecimal") {
            result = numberToConvert.toString(16).toUpperCase();
        }

        resultArea.value = result;
    });
}