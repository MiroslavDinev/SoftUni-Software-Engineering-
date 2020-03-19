function solve(arr){
    let heroes = [];
    for (const entry of arr) {
        let [name, level, items] = entry.split(" / ");
        level = Number(level);
        items = items ? items.split(", ") : [];
        let hero = {name, level, items};
        heroes.push(hero);
    }

    console.log(JSON.stringify(heroes));
}

solve(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
);