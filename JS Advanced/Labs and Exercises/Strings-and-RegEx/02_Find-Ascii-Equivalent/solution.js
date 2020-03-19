function solve() {

  let input = document.getElementById("text").value;
  input = input.split(" ");
  let resultWord = "";
  let wholeResult = [];

  for (let i = 0; i < input.length; i++) {
    let currWord = input[i];
    if (isNaN(currWord)) {
      let currNumsStr = "";

      for (let i = 0; i < currWord.length; i++) {
        let currElement = currWord[i];
        if (currElement !== " ") {
          let ascii = currElement.charCodeAt(0);
          if (i > 0) {
            currNumsStr += " ";
          }
          currNumsStr += String(ascii);
        } else {
          currNumsStr += " ";
        }
      }
      wholeResult.push(currNumsStr);
    } else {
      let strAsNum = Number(currWord);
      let letter = String.fromCharCode(strAsNum);
      resultWord += letter;
    }
  }

  wholeResult.push(resultWord);

  let resultSpan = document.getElementById("result");

  for (let i = 0; i < wholeResult.length; i++) {
    let element = wholeResult[i];
    let p = document.createElement("p");
    p.textContent = element;
    resultSpan.appendChild(p);
  }
}