function solve(area, vol, input) {
    let result = [];
    let inputArr = JSON.parse(input);
    for (const element of inputArr) {
        let obj = {
            area: Math.abs(area.call(element, element.x, element.y)),
            volume: Math.abs(vol.call(element, element.x, element.y, element.z))
        };

        result.push(obj);
    }
    return result;
}

function vol() {
    return this.x * this.y * this.z;
}

function area() {
    return this.x * this.y;
}

console.log(solve(
    area, vol, `[
        {"x":"1","y":"2","z":"10"},
        {"x":"7","y":"7","z":"10"},
        {"x":"5","y":"2","z":"10"}
        ]`
));