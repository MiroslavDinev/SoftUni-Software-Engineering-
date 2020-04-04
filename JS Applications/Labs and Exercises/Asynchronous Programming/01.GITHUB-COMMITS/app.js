function loadCommits() {
    let usernameElement = document.getElementById("username");
    let repoElement = document.getElementById("repo");
    let commitsUl = document.getElementById("commits");
    commitsUl.innerHTML = "";

    fetch(`https://api.github.com/repos/${usernameElement.value}/${repoElement.value}/commits`)
    .then(resp => {
        if(!resp.ok) {
            throw new Error(JSON.stringify({
                status : resp.status,
                statusText : resp.statusText
            }));
        }

        return resp;
    })
    .then(res => res.json())
    .then(data => {
        data.forEach(element => {
            let {commit} = element;
            let li = document.createElement("li");
            li.textContent = `${commit.author.name}: ${commit.message}`;
            commitsUl.appendChild(li);
        });
    })
    .catch(errorData =>{
        let error = JSON.parse(errorData.message);
        let li = document.createElement("li");
        li.textContent = `Error: ${error.status} (${error.statusText})`;
        commitsUl.appendChild(li);
    });
}