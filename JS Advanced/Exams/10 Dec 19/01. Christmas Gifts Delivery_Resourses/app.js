function solution() {
    let giftsList = [];
    let giftNameInputElement = document.querySelector("body > div > section:nth-child(1) > div > input[type=text]");
    let listOfGiftsUl = document.querySelector("body > div > section:nth-child(2) > ul");
    let sentGiftsUl = document.querySelector("body > div > section:nth-child(3) > ul");
    let discardedGiftsUl = document.querySelector("body > div > section:nth-child(4) > ul");
    let addGiftBtn = document.querySelector("body > div > section:nth-child(1) > div > button");

    addGiftBtn.addEventListener("click", function () {
        let giftName = giftNameInputElement.value;

        if (giftName) {
            listOfGiftsUl.innerHTML = "";
            giftsList.push(giftName);
            giftsList.sort((a, b) => a.localeCompare(b));
            for (let i = 0; i < giftsList.length; i++) {
                let currGift = giftsList[i];
                let li = document.createElement("li");
                li.classList.add("gift");
                li.textContent = currGift;

                let sendGiftBtn = document.createElement("button");
                sendGiftBtn.id = "sendButton";
                sendGiftBtn.textContent = "Send";

                let discardGiftBtn = document.createElement("button");
                discardGiftBtn.id = "discardButton";
                discardGiftBtn.textContent = "Discard";

                li.appendChild(sendGiftBtn);
                li.appendChild(discardGiftBtn);

                listOfGiftsUl.appendChild(li);
                giftNameInputElement.value = "";

                sendGiftBtn.addEventListener("click", function () {
                    listOfGiftsUl.removeChild(li);
                    li.removeChild(sendGiftBtn);
                    li.removeChild(discardGiftBtn);
                    sentGiftsUl.appendChild(li);
                    giftsList = [];
                });

                discardGiftBtn.addEventListener("click", function () {
                    listOfGiftsUl.removeChild(li);
                    li.removeChild(sendGiftBtn);
                    li.removeChild(discardGiftBtn);
                    discardedGiftsUl.appendChild(li);
                    giftsList = [];
                });
            }
        }
    });
}