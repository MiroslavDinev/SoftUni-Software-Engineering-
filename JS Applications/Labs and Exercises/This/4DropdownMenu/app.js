function solve() {
    let chooseStyleBtn = document.getElementById("dropdown");
    let dropdownUl = document.getElementById("dropdown-ul");
    let boxElement = document.getElementById("box");

    chooseStyleBtn.addEventListener("click", function () {

        if (dropdownUl.style.display === "block") {
            dropdownUl.style.display = "none";
            boxElement.style.backgroundColor = "black";
            boxElement.style.color = "white";
        } else {
            dropdownUl.style.display = "block";
            let allLiElements = Array.from(document.getElementsByTagName("li"))
                .map(x => x.addEventListener("click", changeColor));

            function changeColor(e) {
                let clickedElement = e.target;
                let colorNeeded = clickedElement.textContent;
                boxElement.style.backgroundColor = colorNeeded;
                boxElement.style.color = "black";
            }
        }
    });
}