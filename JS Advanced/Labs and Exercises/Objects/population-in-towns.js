function solve(arr){
    let result = {};
    for(let townInfo of arr){
      townInfo = townInfo.split(" <-> ");
      let townName = townInfo[0];
      let population = Number(townInfo[1]);

      if(!result.hasOwnProperty(townName)){
        result[townName]=0;
      }
      result[townName]+= population;
    }

    for(let key in result){
      let keyName = key;
      let townPopulation = result[key];
      console.log(`${keyName} : ${townPopulation}`);
    }  
}

solve(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000'
]);