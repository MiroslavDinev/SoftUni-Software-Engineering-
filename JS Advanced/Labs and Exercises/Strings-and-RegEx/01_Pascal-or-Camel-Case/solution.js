function solve() {
  let text = document.getElementById("text").value;
  let criteria = document.getElementById("naming-convention").value;
  let resultArea = document.getElementById("result");

  let allWords = text.split(" ");

  if (criteria === "Camel Case") {
    let result = "";
    for (let i = 0; i < allWords.length; i++) {
      let currWord = allWords[i];
      if (i == 0) {
        result += currWord.toLowerCase();
        continue;
      }
      let newWord = currWord.substring(0, 1).toUpperCase() + currWord.substring(1).toLowerCase();
      result += newWord;
    }
    resultArea.textContent = result;
  }

  else if (criteria === "Pascal Case") {
    let result = "";
    for (let i = 0; i < allWords.length; i++) {
      let currWord = allWords[i];
      let newWord = currWord.substring(0, 1).toUpperCase() + currWord.substring(1).toLowerCase();
      result += newWord;
    }
    resultArea.textContent = result;
  }

  else {
    resultArea.textContent = "Error!";
  }
}