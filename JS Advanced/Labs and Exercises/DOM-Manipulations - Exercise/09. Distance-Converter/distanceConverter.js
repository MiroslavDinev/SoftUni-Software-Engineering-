function attachEventsListeners() {

    let distanceToMeters = {
        "km": 1000,
        "m": 1,
        "cm": 0.01,
        "mm": 0.001,
        "mi": 1609.34,
        "yrd": 0.9144,
        "ft": 0.3048,
        "in": 0.0254
    };
    let convertBtn = document.getElementById("convert");
    let inputOptions = document.getElementById("inputUnits");
    let outputOptions = document.getElementById("outputUnits");
    let inputTextArea = document.getElementById("inputDistance");
    let outputTextArea = document.getElementById("outputDistance");

    convertBtn.addEventListener("click", convertUnits);

    function convertUnits() {
        let number = inputTextArea.value;
        let inputOption = inputOptions.value;
        // for (let option of inputOptions.children) {
        //     if (option.selected === true) {
        //         inputOption = option.value;
        //         break;
        //     }
        // }
        let outputOption = outputOptions.value;
        // for (let option of outputOptions.children) {
        //     if (option.selected === true) {
        //         outputOption = option.value;
        //         break;
        //     }
        // }

        let distanceInMeters = Number(number) * distanceToMeters[inputOption];
        let result = distanceInMeters / distanceToMeters[outputOption];
        outputTextArea.value = result;
    }
}