function solution(n){
    return function addTo5(x){
        return n+x;
    };
}

let add5 = solution(5);
console.log(add5(2));

