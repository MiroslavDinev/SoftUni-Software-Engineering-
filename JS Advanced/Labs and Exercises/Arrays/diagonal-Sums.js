function solve(arr){
    let result =[];
    let mainDiagonal =0;
    let secondaryDiagonal =0;
    for (let row = 0; row < arr.length; row++) {
        mainDiagonal += arr[row][row];
        secondaryDiagonal += arr[row][arr.length-1-row];
    }

    result.push(mainDiagonal, secondaryDiagonal);
    console.log(result.join(" "));
}

solve([[3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]   
   );