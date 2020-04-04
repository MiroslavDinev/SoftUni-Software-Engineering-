function getArticleGenerator(articles) {
    let contentDiv = document.getElementById("content");

    return function(){
        if(articles.length > 0){
            let currArticle = articles[0];
            let div = document.createElement("div");
            let article = document.createElement("article");
            article.textContent = currArticle;
            div.appendChild(article);
            contentDiv.appendChild(div);
            articles.shift();
        }
    };
}

