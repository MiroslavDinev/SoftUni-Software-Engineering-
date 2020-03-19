function solve(arr){
    let townNames =[];
    let result = {};
       for(let sentence of arr){
         let townName = sentence.split(" -> ")[0];
         let product = sentence.split(" -> ")[1];
         let qunatities = sentence.split(" -> ")[2];
         let quantity = Number(qunatities.split(" : ")[0]);
         let price = Number(qunatities.split(" : ")[1]);
         let total = quantity * price;
  
          if(!townNames.includes(townName)){
            townNames.push(townName);
            console.log(`Town - ${townName}`);
            console.log(`$$$${product} : ${total}`);
          }
          else{
            console.log(`$$$${product} : ${total}`);
          }
       }
  }

solve(['Sofia -> Laptops HP -> 200 : 2000',
    'Sofia -> Raspberry -> 200000 : 1500',
    'Sofia -> Audi Q7 -> 200 : 100000',
    'Montana -> Portokals -> 200000 : 1',
    'Montana -> Qgodas -> 20000 : 0.2',
    'Montana -> Chereshas -> 1000 : 0.3']
);