function solve(name, age, weight, height) {

    let BMI = weight / Math.pow(height, 2);
    BMI = Math.round(BMI * 10000);
    let status = "";
    let hasRecomendation = false;
    if (BMI >= 30) {
        status = "obese";
        hasRecomendation = true;
    } else if (BMI >= 25 && BMI < 30) {
        status = "overweight";
    } else if (BMI < 25 && BMI >= 18.5) {
        status = "normal";
    } else {
        status = "underweight";
    }

    let result = {
        name: name,
        personalInfo: {
            age: age,
            weight: weight,
            height: height
        },
        BMI: BMI,
        status: status
    };

    if (hasRecomendation) {
        result.recommendation = 'admission required';
    }

    console.log(result);
}

// function solve(name, age, weight, height) {
//     let bmi = Math.round(weight / (height / 100) / (height / 100));

//     let result = {
//         name: name,
//         personalInfo: {
//             age: age,
//             weight: weight,
//             height: height
//         },
//         BMI: bmi
//     }

//     let status = (result.BMI < 18.5) ? 'underweight' :
//         (result.BMI < 25) ? 'normal' :
//         (result.BMI < 30) ? 'overweight' :
//         'obese';

//     result.status = status;
//     if (result.BMI >= 30) {
//         result.recommendation = 'admission required';
//     }

//     return result;
// }

solve('Peter', 29, 75, 182);