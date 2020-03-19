function attachEventsListeners() {

    let daysBtn = document.getElementById("daysBtn");
    let hoursBtn = document.getElementById("hoursBtn");
    let minsBtn = document.getElementById("minutesBtn");
    let secsBtn = document.getElementById("secondsBtn");

    let daysInputElement = document.getElementById("days");
    let hoursInputElement = document.getElementById("hours");
    let minsInputElement = document.getElementById("minutes");
    let secsInputElement = document.getElementById("seconds");

    daysBtn.addEventListener("click", calcDays);
    hoursBtn.addEventListener("click", calcHours);
    minsBtn.addEventListener("click", calcMins);
    secsBtn.addEventListener("click", calcSecs);

    function calcDays() {
        let days = daysInputElement.value;
        let hours = days * 24;
        let mins = hours * 60;
        let secs = mins * 60;
        hoursInputElement.value = hours;
        minsInputElement.value = mins;
        secsInputElement.value = secs;
    }

    function calcHours() {
        let hours = hoursInputElement.value;
        let days = hours / 24;
        let mins = hours * 60;
        let secs = mins * 60;
        daysInputElement.value = days;
        minsInputElement.value = mins;
        secsInputElement.value = secs;
    }

    function calcMins() {
        let mins = minsInputElement.value;
        let hours = mins / 60;
        let days = hours / 24;
        let secs = mins * 60;
        daysInputElement.value = days;
        hoursInputElement.value = hours;
        secsInputElement.value = secs;
    }

    function calcSecs() {
        let secs = secsInputElement.value;
        let mins = secs / 60;
        let hours = mins / 60;
        let days = hours / 24;
        daysInputElement.value = days;
        hoursInputElement.value = hours;
        minsInputElement.value = mins;
    }
}