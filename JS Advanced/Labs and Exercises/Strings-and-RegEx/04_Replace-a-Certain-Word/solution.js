function solve() {

    let replacingWord = document.getElementById("word").value;
    let strings = JSON.parse(document.getElementById("text").value);
    let resultArea = document.getElementById("result");

    let neededWord = "";
    let regex = "";

    for (let i = 0; i < strings.length; i++) {
        let currElement = strings[i];
        if (i === 0) {
            neededWord = currElement.split(" ")[2].toLowerCase();
            regex = new RegExp(neededWord, "gi");
        }
        let p = document.createElement("p");
        currElement = currElement.replace(regex, replacingWord);
        p.textContent = currElement;
        resultArea.appendChild(p);
    }
}