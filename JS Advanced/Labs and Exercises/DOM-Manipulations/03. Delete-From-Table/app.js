function deleteByEmail() {
    let table = document.getElementsByTagName("tbody")[0];
    let inputEmailElement = document.getElementsByTagName("input")[0];
    let email = inputEmailElement.value;
    let allTableRows = table.children;
    let deleted = false;
    for (let i = 0; i < allTableRows.length; i++) {
        let currRow = allTableRows[i];
        let currMail = currRow.children[1].textContent;
        if (email === currMail) {
            deleted = true;
            table.removeChild(currRow);
            break;
        }
    }

    let resultDiv = document.getElementById("result");

    if (!deleted) {
        resultDiv.textContent = "Not found.";
    } else {
        resultDiv.textContent = "Deleted";
    }
}