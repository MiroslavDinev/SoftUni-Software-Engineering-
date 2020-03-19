function solve(arr){
    let result =[];
    let first = Math.min(...arr);
    arr.splice(arr.indexOf(first),1);
    let second = Math.min(...arr);
    result.push(first,second);
    console.log(result.join(" "));
}

solve([3, 0, 10, 4, 7, 3]);