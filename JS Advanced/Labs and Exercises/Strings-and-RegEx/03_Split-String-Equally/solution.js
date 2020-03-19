function solve() {
    let string = document.getElementById("text").value;
    let number = document.getElementById("number").value;
    let resultElement = document.getElementById("result");
    number = Number(number);

    let result = splitString(string, number);

    resultElement.textContent = result;

    function splitString(string, number) {
        if (number == string.length) {
            return string;
        } else if (number > string.length) {
            let output = "";
            let wholeTimes = Math.floor(number / string.length);
            let remainder = number % string.length;

            output += string.repeat(wholeTimes);
            for (let i = 0; i < remainder; i++) {
                let currLetter = string[i];
                output += currLetter;
            }

            return output;
        } else {
            let output = "";
            let currResult = "";
            for (let i = 0; i < string.length; i++) {
                let currElement = string[i];
                if (i % number == 0 && i !== 0) {
                    currResult += " ";
                    output += currResult;
                    currResult = "";
                }
                currResult += currElement;
            }

            if (currResult) {
                let remainder = number - currResult.length;
                for (let i = 0; i < remainder; i++) {
                    let element = string[i];
                    currResult += element;
                }
                output += currResult;
            }
            return output;
        }
    }
}