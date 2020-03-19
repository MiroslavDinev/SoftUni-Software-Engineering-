function addItem() {
    let selectElement = document.getElementById("menu");
    let newItemTextInputField = document.getElementById("newItemText");
    let newItemValueInputField = document.getElementById("newItemValue");

    let newOption = document.createElement("option");
    newOption.textContent = newItemTextInputField.value;
    newOption.value = newItemValueInputField.value;

    selectElement.appendChild(newOption);
    newItemTextInputField.value = "";
    newItemValueInputField.value = "";
}