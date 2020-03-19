function create(words) {
   let contentDiv = document.getElementById("content");

   for (let i = 0; i < words.length; i++) {
      let currWord = words[i];
      let paragraph = document.createElement("p");
      paragraph.textContent = currWord;
      paragraph.style.display = "none";
      let div = document.createElement("div");
      div.appendChild(paragraph);
      contentDiv.appendChild(div);
   }

   Array.from(contentDiv.children)
      .map(x => x.addEventListener("click", showContent));

   function showContent(e) {
      let para = e.target.children[0];
      para.style.display = "";
   }
}