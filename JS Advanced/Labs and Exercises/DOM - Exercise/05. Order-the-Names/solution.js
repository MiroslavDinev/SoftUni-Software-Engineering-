function solve() {

    let db = {
        A: [],
        B: [],
        C: [],
        D: [],
        E: [],
        F: [],
        G: [],
        H: [],
        I: [],
        J: [],
        K: [],
        L: [],
        M: [],
        N: ["Nixon"],
        O: [],
        P: ["Peterson"],
        Q: [],
        R: [],
        S: [],
        T: [],
        U: [],
        V: [],
        W: [],
        X: [],
        Y: [],
        Z: []
    };

    let list = document.querySelector("#exercise > div > ol").children;
    let inputElement = document.getElementsByTagName("input")[0];

    let addBtn = document.getElementsByTagName("button")[0];
    addBtn.addEventListener("click", addToDb);

    function addToDb() {
        let name = inputElement.value;
        name = name.substring(0, 1).toUpperCase() + name.substring(1).toLowerCase();
        let firstLetter = name[0];
        db[firstLetter].push(name);
        list[firstLetter.charCodeAt(0) - 65].textContent = db[firstLetter].join(", ");
        inputElement.value = "";
    }
}