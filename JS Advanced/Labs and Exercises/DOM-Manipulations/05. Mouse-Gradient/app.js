function attachGradientEvents() {
    let gradientBtn = document.getElementById("gradient");
    let resultDiv = document.getElementById("result");

    gradientBtn.addEventListener("mousemove", calcPower);
    gradientBtn.addEventListener("mouseout", gradOut);

    function calcPower(e) {
        let power = e.offsetX / (e.target.clientWidth - 1);
        power = Math.trunc(power * 100);
        resultDiv.textContent = power + "%";
    }

    function gradOut(e) {
        resultDiv.textContent = "";
    }
}