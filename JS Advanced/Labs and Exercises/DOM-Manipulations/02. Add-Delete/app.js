function addItem() {
    let inputElements = document.getElementsByTagName("input");
    let inputArea = inputElements[0];
    let text = inputArea.value;

    let allEntries = document.getElementById("items");
    let newLi = document.createElement("li");
    newLi.textContent = text;
    allEntries.appendChild(newLi);
    inputArea.value = "";

    let deleteLink = document.createElement("a");
    deleteLink.textContent = "[Delete]";
    deleteLink.href = "#";
    deleteLink.addEventListener("click", deleteItem);
    newLi.appendChild(deleteLink);

    function deleteItem() {
        allEntries.removeChild(newLi);
    }
}