function stopwatch() {
    let startButton = document.getElementById("startBtn");
    let stopBtn = document.getElementById("stopBtn");
    let timeArea = document.getElementById("time");

    let currTime;
    let intervalId;

    startButton.addEventListener("click", startTime);
    stopBtn.addEventListener("click", stopTime);

    function stopTime(){
        clearInterval(intervalId);
        startButton.disabled = false;
        stopBtn.disabled = true;
    }

    function startTime(){
        currTime = -1;
        incrementTime();
        intervalId = setInterval(incrementTime, 1000);
        startButton.disabled = true;
        stopBtn.disabled = false;
    }

    function incrementTime(){
        currTime++;
        timeArea.textContent = 
        ("0" + Math.trunc(currTime /60)).slice(-2) + ":" + ("0" + (currTime % 60)).slice(-2);
    }
}