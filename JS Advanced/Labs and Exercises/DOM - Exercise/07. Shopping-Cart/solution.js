function solve() {
   let products = new Set();
   let totalPrice = 0;
   let outputArea = document.getElementsByTagName("textarea")[0];
   let allProductTitles = document.querySelectorAll(".product-title");
   let allProductPrices = document.querySelectorAll(".product-line-price");
   let allAddBtns = document.querySelectorAll(".add-product");
   allAddBtns[0].addEventListener("click", addProducts1);
   allAddBtns[1].addEventListener("click", addProducts2);
   allAddBtns[2].addEventListener("click", addProducts3);

   let checkoutBtn = document.querySelectorAll(".checkout")[0];
   checkoutBtn.addEventListener("click", showResult);

   function addProducts1() {
      let price = Number(allProductPrices[0].textContent);
      totalPrice += price;
      let productTitle = allProductTitles[0].textContent;
      products.add(productTitle);
      outputArea.value += `Added ${productTitle} for ${price.toFixed(2)} to the cart.\n`;
   }

   function addProducts2() {
      let price = Number(allProductPrices[1].textContent);
      totalPrice += price;
      let productTitle = allProductTitles[1].textContent;
      products.add(productTitle);
      outputArea.value += `Added ${productTitle} for ${price.toFixed(2)} to the cart.\n`;
   }

   function addProducts3() {
      let price = Number(allProductPrices[2].textContent);
      totalPrice += price;
      let productTitle = allProductTitles[2].textContent;
      products.add(productTitle);
      outputArea.value += `Added ${productTitle} for ${price.toFixed(2)} to the cart.\n`;
   }

   function showResult() {

      allAddBtns[0].disabled = true;
      allAddBtns[1].disabled = true;
      allAddBtns[2].disabled = true;
      outputArea.value += `You bought ${Array.from(products).join(", ")} for ${totalPrice.toFixed(2)}.`;
      checkoutBtn.disabled = true;
   }
   outputArea.value = "";
}