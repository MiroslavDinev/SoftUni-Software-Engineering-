function solve(arr){
    let result =[];
    for(let sentence of arr){
      sentence = sentence.match(/\w+/gim);
      for(let word of sentence){
        word = word.toLowerCase();
        if(!result.includes(word)){
            result.push(word);
        }
      }
    }

    console.log(result.join(", "));
}

solve(['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Pellentesque quis hendrerit dui.', 
'Quisque fringilla est urna, vitae efficitur urna vestibulum fringilla.', 
'Vestibulum dolor diam, dignissim quis varius non, fermentum non felis.', 
'Vestibulum ultrices ex massa, sit amet faucibus nunc aliquam ut.', 
'Morbi in ipsum varius, pharetra diam vel, mattis arcu.', 
'Integer ac turpis commodo, varius nulla sed, elementum lectus.', 
'Vivamus turpis dui, malesuada ac turpis dapibus, congue egestas metus.']
);