function growingWord() {

    let growingWord = document.getElementsByTagName("p")[2];

    let allColors = ["blue","green","red"];
    let counter = allColors.indexOf(growingWord.style.color);

    let currentSize = Number(growingWord.style.fontSize.slice(0,-2));
    
    growingWord.style.fontSize = setSize();
    growingWord.style.color = allColors[++counter%3];

    function setSize(){
      if(currentSize<1){
        currentSize=1;
      }
      currentSize*=2;
      return currentSize + "px";
    }
}

