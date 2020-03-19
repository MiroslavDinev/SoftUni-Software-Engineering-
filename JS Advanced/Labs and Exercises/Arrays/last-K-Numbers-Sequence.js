function solve(n,k){
    let result =[1];
    let sum =0;
    for (let i = 0; i < n; i++) {
        let lastKElements = result.slice(-k);
        sum = lastKElements.reduce((a,b)=> a+b);
        result[i] = sum;
    }

    console.log(result.join(" "));
}

solve(6, 3);