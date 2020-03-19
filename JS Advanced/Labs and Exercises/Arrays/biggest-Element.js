function solve(arr){
    let biggestElement = Math.max(...arr.flat());
    console.log(biggestElement);
}

solve([[3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]]
   );