function solve() {

    let exprInput = document.getElementById("expressionOutput");
    let resultOutput = document.getElementById("resultOutput");

    Array.from(document.getElementsByTagName("button")).map(x => x.addEventListener("click", calculate));

    function calculate() {
        if (this.value !== "=" && this.value !== "Clear") {
            if (this.value === '/' || this.value === '-' || this.value === '*' || this.value === '+') {
                exprInput.textContent += ` ${this.value} `;
            } else {
                exprInput.textContent += this.value;
            }

        } else if (this.value === "Clear") {
            exprInput.textContent = "";
            resultOutput.textContent = "";
        } else {
            let resultString = exprInput.textContent;
            let numbers = resultString.match(/\d*\.*\d+/g);
            let operators = resultString.match(/[\+\*\-\/]/g);
            let result = Number(numbers[0]);
            if (operators) {
                for (let i = 0; i < operators.length; i++) {
                    let operator = operators[i];
                    let number = Number(numbers[i + 1]);
                    switch (operator) {
                        case"+":
                            result += number;
                            break;
                        case"-":
                            result -= number;
                            break;
                        case"*":
                            result *= number;
                            break;
                        case"/":
                            result /= number;
                            break;
                    }

                }
            }
            resultOutput.textContent = result;

        }
    }
}