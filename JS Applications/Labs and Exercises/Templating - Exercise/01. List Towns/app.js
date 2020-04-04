(function () {

    let loadTownsBtn = document.getElementById("btnLoadTowns")
        .addEventListener("click", async function () {

            let towns = document.getElementById("towns").value.split(", ");

            let source = await fetch("./towns.hbs")
                .then(res => res.text());

            let template = Handlebars.compile(source);
            let context = {towns};
            let townsHtml = template(context);
            document.getElementById("root").innerHTML = townsHtml;
        });
}());