function solve() {
  let correctAnswers = 0;
  let allSections = document.getElementsByTagName("section");

  for (let i = 0; i < allSections.length; i++) {
    let currSection = allSections[i];
    let nextSection = allSections[i + 1];
    let firstAnswer = currSection.querySelectorAll(".answer-text")[0];
    let secondAnswer = currSection.querySelectorAll(".answer-text")[1];

    firstAnswer.addEventListener("click", count);
    secondAnswer.addEventListener("click", count);

    function count(e) {
      if (e.target.innerHTML === "onclick"
        || e.target.innerHTML === "JSON.stringify()"
        || e.target.innerHTML === "A programming API for HTML and XML documents") {
        correctAnswers++;
      }

      if (nextSection) {
        currSection.style.display = "none";
        nextSection.style.display = "block";
      }
      else {
        let resultArea = document.getElementById("results");
        let resultValue = document.querySelector(".results-inner h1");

        if (correctAnswers === 3) {
          resultValue.textContent = "You are recognized as top JavaScript fan!";
        }
        else {
          resultValue.textContent = `You have ${correctAnswers} right answers`;
        }
        currSection.style.display = "none";
        resultArea.style.display = "block";
      }
    }
  }
}