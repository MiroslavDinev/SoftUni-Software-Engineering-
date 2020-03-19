function encodeAndDecodeMessages() {
    let textAreas = document.getElementsByTagName("textarea");
    let inputTextArea = textAreas[0];
    let outputTextArea = textAreas[1];

    let allBtns = document.getElementsByTagName("button");
    let sendBtn = allBtns[0];
    let decondBtn = allBtns[1];

    sendBtn.addEventListener("click", encodeMsg);
    decondBtn.addEventListener("click", decodeMsg);

    function encodeMsg() {
        let text = inputTextArea.value;
        let encodedText = "";
        for (let letter of text) {
            let ascii = letter.charCodeAt(0);
            let encodedLetter = String.fromCharCode(ascii + 1);
            encodedText += encodedLetter;
        }
        outputTextArea.value = encodedText;
        inputTextArea.value = "";
    }

    function decodeMsg() {
        let text = outputTextArea.value;
        let decodedText = "";
        for (let letter of text) {
            let ascii = letter.charCodeAt(0);
            let decodedLetter = String.fromCharCode(ascii - 1);
            decodedText += decodedLetter;
        }
        outputTextArea.value = decodedText;
    }
}