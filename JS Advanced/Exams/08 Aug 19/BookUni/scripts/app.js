function solve() {
    const [titleInput, yearInput, priceInput] = Array.from(document.getElementsByTagName("input"));
    const addBtn = Array.from(document.getElementsByTagName("button"))[0];
    let profit = 0;
    let totalProfitElement = Array.from(document.getElementsByTagName("h1"))[1];

    let [oldShelf, newShelf] = Array.from(document.getElementsByClassName("bookShelf"));

    addBtn.addEventListener("click", addBook);

    function addBook(e) {
        e.preventDefault();

        let title = titleInput.value;
        let year = Number(yearInput.value);
        let price = Number(priceInput.value);

        if (title && year > 0 && price > 0) {
            if (year >= 2000) {
                addNewBook(title, year, price);
            }
            else {
                addOldBook(title, year, price);
            }
        }
    }

    function addOldBook(title, year, price) {
        let oldBookDiv = document.createElement("div");
        oldBookDiv.classList.add("book");

        let p = document.createElement("p");
        p.textContent = `${title} [${year}]`;
        let buyBtn = document.createElement("button");
        buyBtn.textContent = `Buy it only for ${(price * 0.85).toFixed(2)} BGN`;

        oldBookDiv.appendChild(p);
        oldBookDiv.appendChild(buyBtn);

        oldShelf.appendChild(oldBookDiv);

        buyBtn.addEventListener("click", function () {
            oldShelf.removeChild(oldBookDiv);
            profit += price * 0.85;
            totalProfitElement.textContent = `Total Store Profit: ${profit.toFixed(2)} BGN`;
        });
    }

    function addNewBook(title, year, price) {
        let newBookDiv = document.createElement("div");
        newBookDiv.classList.add("book");

        let p = document.createElement("p");
        p.textContent = `${title} [${year}]`;
        let buyBtn = document.createElement("button");
        buyBtn.textContent = `Buy it only for ${price.toFixed(2)} BGN`;
        let moveBtn = document.createElement("button");
        moveBtn.textContent = "Move to old section";

        newBookDiv.appendChild(p);
        newBookDiv.appendChild(buyBtn);
        newBookDiv.appendChild(moveBtn);

        newShelf.appendChild(newBookDiv);

        buyBtn.addEventListener("click", function () {
            newShelf.removeChild(newBookDiv);
            profit += price;
            totalProfitElement.textContent = `Total Store Profit: ${profit.toFixed(2)} BGN`;
        });

        moveBtn.addEventListener("click", function () {

            let oldBookDiv = document.createElement("div");
            oldBookDiv.classList.add("book");

            let p = document.createElement("p");
            p.textContent = `${title} [${year}]`;
            let buyBtn = document.createElement("button");
            buyBtn.textContent = `Buy it only for ${(price * 0.85).toFixed(2)} BGN`;

            oldBookDiv.appendChild(p);
            oldBookDiv.appendChild(buyBtn);

            newShelf.removeChild(newBookDiv);

            oldShelf.appendChild(oldBookDiv);

            buyBtn.addEventListener("click", function () {
                oldShelf.removeChild(oldBookDiv);
                profit += price * 0.85;
                totalProfitElement.textContent = `Total Store Profit: ${profit.toFixed(2)} BGN`;
            });
        });
    }
}