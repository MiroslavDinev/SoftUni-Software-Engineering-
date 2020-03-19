function solve() {
  let insertTextElement = document.getElementById("input");
  let insertedTextValue = insertTextElement.innerHTML;

  let outputElement = document.getElementById("output");

  if (insertedTextValue) {
    let allSentences = insertedTextValue.split(".");

    let sentencesToAdd = "";
    let counter = 1;

    for (let i = 0; i < allSentences.length; i++) {
      let currSentence = allSentences[i];
      currSentence += ".";
      sentencesToAdd += currSentence;

      if (counter % 3 == 0) {
        let contentElement = document.createElement("p");
        contentElement.textContent = sentencesToAdd;
        outputElement.appendChild(contentElement);
        sentencesToAdd = "";
        contentElement.value = "";
      }

      counter++;
    }

    if (sentencesToAdd) {
      let contentElement = document.createElement("p");
      contentElement.textContent = sentencesToAdd.slice(0,sentencesToAdd.length-1);
      outputElement.appendChild(contentElement);
    }
  }
}