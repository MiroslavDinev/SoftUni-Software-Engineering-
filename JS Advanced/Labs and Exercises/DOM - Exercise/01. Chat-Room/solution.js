function solve() {
   let sendBtn = document.getElementById("send");
   let textInputElement = document.getElementById("chat_input");
   sendBtn.addEventListener("click", sendMsg);

   function sendMsg() {
      let writtenMsg = textInputElement.value;
      let newDiv = document.createElement("div");
      newDiv.classList.add("message", "my-message");
      newDiv.textContent = writtenMsg;
      let currDiv = document.getElementById("chat_messages");
      currDiv.appendChild(newDiv);
      textInputElement.value = "";
   }
}


