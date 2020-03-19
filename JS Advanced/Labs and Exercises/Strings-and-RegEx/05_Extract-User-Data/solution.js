function solve() {

    let inputArr = JSON.parse(document.getElementById("arr").value);
    const regex = /^([A-Z][a-z]* [A-Z][a-z]*) (\+359( |-)\d( |-)\d{3}( |-)\d{3}) ([a-z0-9]+@[a-z]+\.[a-z]{2,3})$/gm;
    let resultArea = document.getElementById("result");

    for (let entry of inputArr) {
        let m = regex.exec(entry);

        if (m) {
            let name = m[1];
            let phone = m[2];
            let mail = m[6];

            let nameP = document.createElement("p");
            let phoneP = document.createElement("p");
            let mailP = document.createElement("p");

            nameP.textContent = `Name: ${name}`;
            phoneP.textContent = `Phone Number: ${phone}`;
            mailP.textContent = `Email: ${mail}`;

            resultArea.appendChild(nameP);
            resultArea.appendChild(phoneP);
            resultArea.appendChild(mailP);
        } else {
            let textP = document.createElement("p");
            textP.textContent = "Invalid data";

            resultArea.appendChild(textP);
        }

        let linesP = document.createElement("p");
        linesP.textContent = "- - -";
        resultArea.appendChild(linesP);
    }
}