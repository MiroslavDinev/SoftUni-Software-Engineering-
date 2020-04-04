function solve() {
    let firstElement;
    let secondElement;
    let resultElement;

    return {
        init: () => {
            firstElement = document.getElementById("num1");
            secondElement = document.getElementById("num2");
            resultElement = document.getElementById("result");
        },

        add: () => resultElement.value = Number(firstElement.value) + Number(secondElement.value),
        subtract: () => resultElement.value = Number(firstElement.value) - Number(secondElement.value),
    };
}