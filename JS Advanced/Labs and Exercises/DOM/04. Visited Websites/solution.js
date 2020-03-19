function solve() {

  let allLinks = document.getElementsByTagName("a");
  let allVisits = document.getElementsByTagName("p");

  for (let i = 0; i < allLinks.length; i++) {
    updateCount(allLinks[i], allVisits[i]);
  }

  function updateCount(link, visit) {
    link.addEventListener ("click", function () {
      countOfVisits = Number(visit.innerHTML.match(/\d+/gim));
      countOfVisits++;
      visit.innerHTML = `visited ${countOfVisits} times`;
    });
  }
}

