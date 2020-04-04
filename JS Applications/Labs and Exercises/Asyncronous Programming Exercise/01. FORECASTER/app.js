function attachEvents() {
    let locationInputElement = document.querySelector("#location");
    let forecastDiv = document.querySelector("#forecast");
    let currentDiv = document.querySelector("#current");
    let upcomingDiv = document.querySelector("#upcoming");
    let getWeatherBtn = document.querySelector("#submit");

    let weatherSymbols = {
        sunny : "☀",
        partlysunny : "⛅",
        overcast : "☁",
        rain : "☂",
        degrees : "°"
    };

    getWeatherBtn.addEventListener("click", getCityData);

    function getCityData() {
        clearOldContent();
        let cityName = locationInputElement.value;

        fetch("https://judgetests.firebaseio.com/locations.json")
        .then(res => res.json())
        .then(data =>{
            let {code, name} = data.find(x=>x.name === cityName);

            locationInputElement.value = "";
            getNextDayData(code);
            getNextThreeDaysData(code);
        })
        .catch(err=>{
            displayError();
            locationInputElement.value = "";
        });
    }

    function getNextThreeDaysData(code) {
        fetch(`https://judgetests.firebaseio.com/forecast/upcoming/${code}.json`)
        .then(res=>res.json())
        .then(data => {
            let {forecast} = data;

            let forecastInfoDiv = document.createElement("div");
            forecastInfoDiv.classList.add("forecast-info");

            for (let i = 0; i < forecast.length; i++) {
                let currDayData = forecast[i];
                let {condition,high,low} = currDayData;

                let degreesSymbol = weatherSymbols.degrees;
                let degreesInfo = `${low}${degreesSymbol}/${high}${degreesSymbol}`;
                let symbol = getSymbolFromObject(condition);

                let upcomingSpan = createNextThreeDayElements(symbol,degreesInfo,condition);
                forecastInfoDiv.appendChild(upcomingSpan);
            }

            upcomingDiv.appendChild(forecastInfoDiv);
        })
        .catch(err=>{
            displayError();
            locationInputElement.value = "";
        });
    }

    function createNextThreeDayElements(symbol,degreesInfo,condition) {
        
        let upcomingSpan = document.createElement("span");
        upcomingSpan.classList.add("upcoming");

        let symbolSpan = document.createElement("span");
        symbolSpan.classList.add("symbol");
        symbolSpan.textContent = symbol;

        let degreesSpan = document.createElement("span");
        degreesSpan.classList.add("forecast-data");
        degreesSpan.textContent = degreesInfo;

        let conditionSpan = document.createElement("span");
        conditionSpan.classList.add("forecast-data");
        conditionSpan.textContent = condition;

        upcomingSpan.appendChild(symbolSpan);
        upcomingSpan.appendChild(degreesSpan);
        upcomingSpan.appendChild(conditionSpan);

        return upcomingSpan;
    }

    function getNextDayData(code) {
        fetch(`https://judgetests.firebaseio.com/forecast/today/${code}.json`)
        .then(res=>res.json())
        .then(data =>{
            let {forecast, name} = data;

            let cityNameAndCountry = name;
            let condition = forecast.condition;
            let high = forecast.high;
            let low = forecast.low;

            let degreesSymbol = weatherSymbols.degrees;
            let degreesInfo = `${low}${degreesSymbol}/${high}${degreesSymbol}`;
            let symbol = getSymbolFromObject(condition);

            createCurrentForecastElements(symbol,cityNameAndCountry,degreesInfo,condition);
        })
        .catch(err=>{
            displayError();
            locationInputElement.value = "";
        });
    }

    function createCurrentForecastElements(symbol,cityNameAndCountry,degreesInfo,condition) {
        forecastDiv.style.display = "block";
        let forecastsDiv = document.createElement("div");
        forecastsDiv.classList.add("forecasts");

        let conditionSymbolSpan = document.createElement("span");
        conditionSymbolSpan.classList.add("condition");
        conditionSymbolSpan.classList.add("symbol");
        conditionSymbolSpan.textContent = symbol;

        let conditionSpan = document.createElement("span");
        conditionSpan.classList.add("condition");

        let cityNameSpan = document.createElement("span");
        cityNameSpan.classList.add("forecast-data");
        cityNameSpan.textContent = cityNameAndCountry;

        let degreesInfoSpan = document.createElement("span");
        degreesInfoSpan.classList.add("forecast-data");
        degreesInfoSpan.textContent = degreesInfo;

        let conditionWithTextSpan = document.createElement("span");
        conditionWithTextSpan.classList.add("forecast-data");
        conditionWithTextSpan.textContent = condition;

        conditionSpan.appendChild(cityNameSpan);
        conditionSpan.appendChild(degreesInfoSpan);
        conditionSpan.appendChild(conditionWithTextSpan);

        forecastsDiv.appendChild(conditionSymbolSpan);
        forecastsDiv.appendChild(conditionSpan);

        currentDiv.appendChild(forecastsDiv);
    }

    function displayError() {
        let h1 = document.createElement("h1");
        h1.textContent = "Error";
        forecastDiv.style.display = "block";
        forecastDiv.appendChild(h1);
    }

    function getSymbolFromObject(condition) {
        let result = condition.split("").filter(c=>c!==" ").map(c=>c.toLowerCase()).join("");
        return weatherSymbols[result];
    }

    function clearOldContent() {
        currentDiv.innerHTML = "";
        let currLabel = document.createElement("div");
        currLabel.classList.add("label");
        currLabel.textContent = "Current conditions";
        currentDiv.appendChild(currLabel);

        upcomingDiv.innerHTML = "";
        let upcomingLabel = document.createElement("div");
        upcomingLabel.classList.add("label");
        upcomingLabel.textContent = "Three-day forecast";
        upcomingDiv.appendChild(upcomingLabel);
    }
}

attachEvents();