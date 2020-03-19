function solve(arr){
    let systems = {};
    for (const entry of arr) {
        let [systemName, componentName, subcomponentName] = entry.split(" | ");
        if(!systems.hasOwnProperty(systemName)){
            systems[systemName] = {};
        }

        let systemComponents = systems[systemName];

        if(!systemComponents.hasOwnProperty(componentName)){
            systemComponents[componentName] = [];
        }

        systemComponents[componentName].push(subcomponentName);
    }

    let systemsKeys = Object.keys(systems)
    .sort((a,b) => Object.keys(systems[b]).length - Object.keys(systems[a]).length || a.localeCompare(b));
    for (const currKey of systemsKeys) {
        console.log(currKey);
        let componentsKeys = Object.keys(systems[currKey])
        .sort((a,b)=> Object.keys(systems[currKey][b]).length - Object.keys(systems[currKey][a]).length);
        for (const currComponentKey of componentsKeys) {
            console.log(`|||${currComponentKey}`);
            let subcomponents = systems[currKey][currComponentKey];
            for (const subcomponent of subcomponents) {
                console.log(`||||||${subcomponent}`);
            }
        }
    }
}

solve(['SULS | Main Site | Home Page',
'SULS | Main Site | Login Page',
'SULS | Main Site | Register Page',
'SULS | Judge Site | Login Page',
'SULS | Judge Site | Submittion Page',
'Lambda | CoreA | A23',
'SULS | Digital Site | Login Page',
'Lambda | CoreB | B24',
'Lambda | CoreA | A24',
'Lambda | CoreA | A25',
'Lambda | CoreC | C4',
'Indice | Session | Default Storage',
'Indice | Session | Default Security']
);