function solve(arr){
    let result = new Set();
    for (const entry of arr) {
        result.add(entry);
    }

    let resultAsArr = Array.from(result);
    let output = resultAsArr.sort((a,b)=> a.length - b.length || a.localeCompare(b));
    output.forEach(element=>{
        console.log(element);
    });
}

solve(['Ashton',
'Kutcher',
'Ariel',
'Lilly',
'Keyden',
'Aizen',
'Billy',
'Braston']
);