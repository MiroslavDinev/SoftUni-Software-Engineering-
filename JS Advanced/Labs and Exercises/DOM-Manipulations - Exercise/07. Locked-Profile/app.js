function lockedProfile() {
    let showMoreBtns = document.getElementsByTagName("button");
    let allRadioBtns = document.querySelectorAll('input[type=radio]');

    let firstUserBtn = showMoreBtns[0];
    let secondUserBtn = showMoreBtns[1];
    let thirdUserBtn = showMoreBtns[2];

    firstUserBtn.addEventListener("click", firstUserInfo);
    secondUserBtn.addEventListener("click", secondUserInfo);
    thirdUserBtn.addEventListener("click", thirdUserInfo);

    function firstUserInfo() {
        if (allRadioBtns[1].checked) {
            let userOneHiddenDetails = document.getElementById("user1HiddenFields");
            if (userOneHiddenDetails.style.display === "inline-block") {
                userOneHiddenDetails.style.display = "";
                firstUserBtn.textContent = "Show more";
            } else {
                userOneHiddenDetails.style.display = "inline-block";
                firstUserBtn.textContent = "Hide it";
            }
        }
    }

    function secondUserInfo() {
        if (allRadioBtns[3].checked) {
            let userTwoHiddenDetails = document.getElementById("user2HiddenFields");
            if (userTwoHiddenDetails.style.display === "inline-block") {
                userTwoHiddenDetails.style.display = "";
                secondUserBtn.textContent = "Show more";
            } else {
                userTwoHiddenDetails.style.display = "inline-block";
                secondUserBtn.textContent = "Hide it";
            }
        }
    }

    function thirdUserInfo() {
        if (allRadioBtns[5].checked) {
            let userThreeHiddenDetails = document.getElementById("user3HiddenFields");
            if (userThreeHiddenDetails.style.display === "inline-block") {
                userThreeHiddenDetails.style.display = "";
                thirdUserBtn.textContent = "Show more";
            } else {
                userThreeHiddenDetails.style.display = "inline-block";
                thirdUserBtn.textContent = "Hide it";
            }
        }
    }
}