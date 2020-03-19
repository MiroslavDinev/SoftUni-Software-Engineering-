function validate() {
    let inputArea = document.getElementById("email");
    inputArea.addEventListener("change", checkInput);

    function checkInput() {
        let writtenMail = inputArea.value;
        let result = writtenMail.match(/\b[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}\b/gim);
        if (result) {
            inputArea.className = "";
        } else {
            inputArea.className = "error";
        }
    }
}