// function focus() {
//     Array.from(document.getElementsByTagName("input")).map(x => x.addEventListener("mouseover", setInput));
//     Array.from(document.getElementsByTagName("input")).map(x => x.addEventListener("mouseout", resetColor));

//     function setInput(e) {
//         let selectedDiv = e.target.parentNode;
//         selectedDiv.className = "focused";
//     }

//     function resetColor(e) {
//         let selectedDiv = e.target.parentNode;
//         selectedDiv.className = "";
//     }
// }

function focus() {
    function highlight() {
        this.parentNode.className = 'focused';
    }

    function unhighlight() {
        this.parentNode.removeAttribute('class');
    }

    let inputElements = document.getElementsByTagName('input');

    Array.from(inputElements).forEach(i => {
        i.addEventListener('focus', highlight);
        i.addEventListener('blur', unhighlight);
    });
}