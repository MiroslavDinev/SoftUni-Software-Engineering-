function solve() {
   let searchFieldElement = document.getElementById("searchField");
   let searchBtn = document.getElementById("searchBtn");
   let allRowElements = document.getElementsByTagName("tr");
   searchBtn.addEventListener("click", markNames);

   function markNames() {

      let writtenInput = searchFieldElement.value;
      for (let i = 1; i < allRowElements.length; i++) {
         
         let currRow = allRowElements[i];
         currRow.removeAttribute("class");

         if (currRow.textContent.toLowerCase().includes(writtenInput.toLowerCase())) {
            currRow.className = "select";
         }
      }

      searchFieldElement.value = "";
   }
}