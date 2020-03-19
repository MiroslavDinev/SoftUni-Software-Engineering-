function solve(arr) {
    let speed = arr[0];
    let area = arr[1];

    let speedRules = {
        'city': 50,
        'residential': 20,
        'interstate': 90,
        'motorway': 130
    };

    let speedExcess = 0;

    speedExcess = speed - speedRules[area];

    if (speedExcess <= 20 && speedExcess>0) {
        console.log("speeding");
    } else if (speedExcess > 20 && speedExcess <= 40) {
        console.log("excessive speeding");
    } else if (speedExcess > 40) {
        console.log("reckless driving");
    }
}

solve([120, 'interstate']);