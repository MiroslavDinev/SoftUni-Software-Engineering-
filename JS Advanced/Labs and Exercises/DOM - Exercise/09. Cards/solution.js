// function solve() {
//    let historyDiv = document.getElementById("history");

//    Array.from(document.getElementsByTagName("img")).map(x => x.addEventListener("click", calculate));

//    let resultSpans = document.getElementById("result");
//    let firstSpan = resultSpans.firstChild;
//    let lastSpan = resultSpans.lastChild;

//    function calculate(e) {
//       let card = e.target;
//       card.src = "./images/whiteCard.jpg";
//       card.removeEventListener("click", calculate);
//       let cardValue = card.name;
//       let cardParent = card.parentNode;
//       if (cardParent.id === "player1Div") {
//          firstSpan.textContent = cardValue;
//       } else if (cardParent.id === "player2Div") {
//          lastSpan.textContent = cardValue;
//       }

//       if (firstSpan.textContent && lastSpan.textContent) {
//          let winner;
//          let loser;

//          if (+firstSpan.textContent > +lastSpan.textContent) {
//             winner = document.querySelector(`#player1Div img[name="${firstSpan.textContent}"]`);
//             loser = document.querySelector(`#player2Div img[name="${lastSpan.textContent}"]`);
//          } else {
//             winner = document.querySelector(`#player2Div img[name="${lastSpan.textContent}"]`);
//             loser = document.querySelector(`#player1Div img[name="${firstSpan.textContent}"]`);
//          }

//          winner.style.border = "2px solid green";
//          loser.style.border = "2px solid red";

//          historyDiv.textContent += `[${firstSpan.textContent} vs ${lastSpan.textContent} ]`;

//          // setTimeout(() => {
//             firstSpan.textContent = "";
//             lastSpan.textContent = "";
//          // }, 2000);
//       }
//    }
// }

function solve() {
   const playerOne = document.getElementById('player1Div');
   const playerTwo = document.getElementById('player2Div');
   const result = document.getElementById('result').children;
   const history = document.getElementById('history');

   let playerOneCard = '';
   let playerTwoCard = '';

   [playerOne, playerTwo].map(player => player.addEventListener('click', function (c) {
      if (c.target.name === undefined) {
         return '';
      }

      player === playerOne ?
         playerOneCard = showCard(playerOneCard, result[0], c) :
         playerTwoCard = showCard(playerTwoCard, result[2], c);

      if (result[0].textContent !== '' && result[2].textContent !== '') {
         Number(playerOneCard.name) > Number(playerTwoCard.name) ?
            createBorder(playerOneCard, playerTwoCard) :
            createBorder(playerTwoCard, playerOneCard);

         saveHistory();
         defaultValues();
      }
   }));

   function createBorder(card1, card2) {
      card1.style.border = "2px solid green";
      card2.style.border = "2px solid red";
   }

   function showCard(player, span, c) {
      c.target.src = "images/whiteCard.jpg";
      span.textContent = c.target.name;
      player = c.target;
      return player;
   }

   function defaultValues() {
      result[0].textContent = '';
      result[2].textContent = '';
      playerOneCard = '';
      playerTwoCard = '';
   }

   function saveHistory() {
      history.textContent += `[${playerOneCard.name} vs ${playerTwoCard.name}] `;
   }
}