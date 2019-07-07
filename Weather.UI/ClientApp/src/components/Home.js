import React, { useState, useEffect } from 'react';
import { url, port } from '../settings';

export function Home() {

    const [weather, setWeather] = useState({
        Name: "",
        Temp:""
    });

    useEffect(() => {
        async function fetchData() {
            //this.setState({ isLoading: true });
            const response = await fetch(url);

            const forecast = await response.json();
            
            setWeather({
                Name: "sddd",//forecast.Name,
                Temp: "d"//forecast.Temp
            });
        }


        fetchData();
    }, []);


    return (
      <div>
            <h1>Weather forecast</h1>
            <h3>
                {weather.Name} -  {weather.Temp} </h3>
    </div>
    );
}

