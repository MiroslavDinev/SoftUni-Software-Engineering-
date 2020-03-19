function solve() {
   let totalPrice = 0;
   let productNameElement = document.querySelector("#add-new > input[type=text]:nth-child(2)");
   let productQtyElement = document.querySelector("#add-new > input[type=text]:nth-child(3)");
   let priceElement = document.querySelector("#add-new > input[type=text]:nth-child(4)");

   let availableProductsUl = document.querySelector("#products > ul");

   let filterInputElement = document.querySelector("#filter");
   let filterBtn = document.querySelector("#products > div > button");

   let myProductsUl = document.querySelector("#myProducts > ul");
   let totalPriceH1 = document.querySelector("body > h1:nth-child(4)");

   let buyBtn = document.querySelector("#myProducts > button");

   let addNewProductBtn = document.querySelector("#add-new > button");

   addNewProductBtn.addEventListener("click", function (e) {
      e.preventDefault();
      let productName = productNameElement.value;
      let productQty = productQtyElement.value;
      let productPrice = priceElement.value;

      if (productName && productQty && productPrice) {
         let li = document.createElement("li");

         let productNameSpan = document.createElement("span");
         productNameSpan.textContent = productName;

         let productQtyStrong = document.createElement("strong");
         productQtyStrong.textContent = `Available: ${productQty}`;

         let productPriceDiv = document.createElement("div");

         let productPriceStrong = document.createElement("strong");
         productPriceStrong.textContent = `${(+productPrice).toFixed(2)}`;

         let addToClientListBtn = document.createElement("button");
         addToClientListBtn.textContent = "Add to Client's List";

         productPriceDiv.appendChild(productPriceStrong);
         productPriceDiv.appendChild(addToClientListBtn);

         li.appendChild(productNameSpan);
         li.appendChild(productQtyStrong);
         li.appendChild(productPriceDiv);
         availableProductsUl.appendChild(li);

         productNameElement.value = "";
         productQtyElement.value = "";
         priceElement.value = "";

         addToClientListBtn.addEventListener("click", function () {
            if (+productQty > 1) {
               productQty -= 1;
               productQtyStrong.textContent = `Available: ${productQty}`;
               let productInCartLi = document.createElement("li");
               productInCartLi.textContent = productName;

               let productInCartStrong = document.createElement("strong");
               productInCartStrong.textContent = `${(+productPrice).toFixed(2)}`;

               productInCartLi.appendChild(productInCartStrong);
               myProductsUl.appendChild(productInCartLi);
               totalPrice += +productPrice;
               totalPriceH1.textContent = `Total Price: ${totalPrice.toFixed(2)}`;
            } else if (+productQty === 1) {
               availableProductsUl.removeChild(li);
               let productInCartLi = document.createElement("li");
               productInCartLi.textContent = productName;

               let productInCartStrong = document.createElement("strong");
               productInCartStrong.textContent = `${(+productPrice).toFixed(2)}`;

               productInCartLi.appendChild(productInCartStrong);
               myProductsUl.appendChild(productInCartLi);
               totalPrice += +productPrice;
               totalPriceH1.textContent = `Total Price: ${totalPrice.toFixed(2)}`;
            }
         });
      }
   });

   filterBtn.addEventListener("click", function () {
      let filterWord = filterInputElement.value;
      if (filterWord) {
         filterWord = filterWord.toLowerCase();
         let allProductsElements = availableProductsUl.children;
         for (let i = 0; i < allProductsElements.length; i++) {
            let liElement = allProductsElements[i];
            let nameOfProduct = liElement.firstChild.textContent.toLowerCase();
            if (!nameOfProduct.includes(filterWord)) {
               liElement.style.display = "none";
            } else {
               liElement.removeAttribute("style");
            }
         }

         filterInputElement.value = "";
      }
   });

   buyBtn.addEventListener("click", function () {
      myProductsUl.innerHTML = "";
      totalPriceH1.textContent = `Total Price: 0.00`;
   });
}