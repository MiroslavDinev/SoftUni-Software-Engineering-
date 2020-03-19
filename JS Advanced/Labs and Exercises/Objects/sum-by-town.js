function solve(arr){
    let towns = {};
    for (let currEntry = 0; currEntry < arr.length; currEntry+=2) {
        let townName = arr[currEntry];
        let townIncome = Number(arr[currEntry+1]);

        if(!towns.hasOwnProperty(townName)){
            towns[townName]=0;
        }

        towns[townName] += townIncome;
    }

    towns = JSON.stringify(towns);

    console.log(towns);
}

solve(['Sofia',
'20',
'Varna',
'3',
'sofia',
'5',
'varna',
'4']
);