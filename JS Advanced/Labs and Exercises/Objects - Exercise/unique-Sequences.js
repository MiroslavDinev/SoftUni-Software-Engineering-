function solve(arr){
    let result = [];
    let arrays = arr.map(JSON.parse);
    
    for (const currArr of arrays) {
        let sum = currArr.reduce((a,b) => a+b,0);
        
        if(!result.some((x)=> x.reduce((a,b) => a+b,0)===sum)){
            result.push(currArr.sort((a,b)=>b-a));
        }
    }

    let sortedResult = result.sort((a,b) => a.length - b.length);
    console.log(sortedResult.map((arr)=> `[${arr.join(", ")}]`).join("\n"));
}

solve(["[7.14, 7.180, 7.339, 80.099]",
"[7.339, 80.0990, 7.140000, 7.18]",
"[7.339, 7.180, 7.14, 80.099]"]
);