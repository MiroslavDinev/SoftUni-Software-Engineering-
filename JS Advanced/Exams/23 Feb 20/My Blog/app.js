function solve() {
   let allArticles = [];
   let authorElement = document.querySelector("#creator");
   let titleElement = document.querySelector("#title");
   let categoryElement = document.querySelector("#category");
   let contentElement = document.querySelector("#content");

   let articlesSection = document.querySelector("body > div > div > main > section");
   let archiveSectionUl = document.querySelector("body > div > div > aside > section.archive-section > ul");

   let createBtn = document.querySelector("body > div > div > aside > section:nth-child(1) > form > button");


   createBtn.addEventListener("click", function (e) {
      e.preventDefault();
      let author = authorElement.value;
      let title = titleElement.value;
      let category = categoryElement.value;
      let content = contentElement.value;

      if (author && title && category && content) {
         let article = document.createElement("article");

         let h1 = document.createElement("h1");
         h1.textContent = title;

         let categoryP = document.createElement("p");
         categoryP.textContent = "Category:";

         let categoryStorng = document.createElement("strong");
         categoryStorng.textContent = category;

         categoryP.appendChild(categoryStorng);

         let creatorP = document.createElement("p");
         creatorP.textContent = "Creator:";

         let creatorStrong = document.createElement("strong");
         creatorStrong.textContent = author;

         creatorP.appendChild(creatorStrong);

         let contentP = document.createElement("p");
         contentP.textContent = content;

         let buttonsDiv = document.createElement("div");
         buttonsDiv.classList.add("buttons");

         let deleteBtn = document.createElement("button");
         deleteBtn.classList.add("btn");
         deleteBtn.classList.add("delete");
         deleteBtn.textContent = "Delete";

         let archiveBtn = document.createElement("button");
         archiveBtn.classList.add("btn");
         archiveBtn.classList.add("archive");
         archiveBtn.textContent = "Archive";

         buttonsDiv.appendChild(deleteBtn);
         buttonsDiv.appendChild(archiveBtn);

         article.appendChild(h1);
         article.appendChild(categoryP);
         article.appendChild(creatorP);
         article.appendChild(contentP);
         article.appendChild(buttonsDiv);

         articlesSection.appendChild(article);

         deleteBtn.addEventListener("click", function () {
            articlesSection.removeChild(article);
         });

         archiveBtn.addEventListener("click", function () {
            articlesSection.removeChild(article);
            allArticles.push(title);
            archiveSectionUl.innerHTML = "";
            allArticles.sort((a, b) => a.localeCompare(b));
            for (let i = 0; i < allArticles.length; i++) {
               let currElement = allArticles[i];
               let li = document.createElement("li");
               li.textContent = currElement;
               archiveSectionUl.appendChild(li);
            }
         });
      }
   });
}