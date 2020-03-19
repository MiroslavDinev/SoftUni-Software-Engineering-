function solve(arr){
    let result = {};
      for(let sentence of arr){
        [town, product, price] = sentence.split(" | ");
        if(!result.hasOwnProperty(product)){
            result[product] = {};
        }
        if(!result[product].hasOwnProperty(town)){
          result[product][town]=0;
        }     
          result[product][town] = Number(price);
        
      }
  
      for(let product in result){
        let lowestPrice = Number.MAX_SAFE_INTEGER;
        let lowestTown = "";
          for(let town in result[product]){
            let currPrice = result[product][town];
            if(currPrice<lowestPrice){
              lowestPrice = currPrice;
              lowestTown = town;
            }
          }
          console.log(`${product} -> ${lowestPrice} (${lowestTown})`);
      }
  }

solve(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']
);