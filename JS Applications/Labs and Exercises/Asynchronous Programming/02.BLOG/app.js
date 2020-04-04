function attachEvents() {
    let postsSelectElement = document.getElementById("posts");
    let postTitleH1 = document.getElementById("post-title");
    let postBodyP = document.getElementById("post-body");
    let commentsUl = document.getElementById("post-comments");

    function showPosts() {
        fetch("https://blog-apps-c12bf.firebaseio.com/.json")
        .then(res => res.json())
        .then(loadPosts)
        .catch(console.error);
    }

    function viewPost() {
        let commentsId = "";
        let postBody = "";
        let postTitle = "";
        const postMainId = postsSelectElement.options[postsSelectElement.selectedIndex].value;
        fetch("https://blog-apps-c12bf.firebaseio.com/.json")
        .then(res => res.json())
        .then(data=>{
            let {posts} = data;
            Object.keys(posts).forEach(key=>{
                if(key === postMainId) {
                    let objNeeded = posts[key];
                    commentsId = objNeeded.id;
                    postBody = objNeeded.body;
                    postTitle = objNeeded.title;
                }
            });
        })
        .catch(console.error);

        fetch("https://blog-apps-c12bf.firebaseio.com/.json")
        .then(res => res.json())
        .then(data=>{
            postTitleH1.textContent = postTitle;
            postBodyP.textContent = postBody;
            commentsUl.innerHTML = "";
            let {comments} = data;
            Object.entries(comments).forEach(([key,objValue])=>{
                let {postId,text} = objValue;
                if(postId === commentsId) {
                    let li = document.createElement("li");
                    li.id = postMainId;
                    li.textContent = text;
                    commentsUl.appendChild(li);
                }
            });
        })
        .catch(console.error);
    }

    function loadPosts(data) {
        let {posts} = data;
            Object.entries(posts)
            .forEach(([key, value])=>{
                let {body, id, title} = value;
                let option = document.createElement("option");
                option.value = key;
                option.textContent = title;
                postsSelectElement.appendChild(option);
            });
    }

    return {
        showPosts,
        viewPost
    };
}

let result = attachEvents();