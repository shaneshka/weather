import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
            <p>Author - <a href='https://github.com/shaneshka'>Durnev Alexandr</a></p>
            <p>Source - <a href='https://github.com/shaneshka/weather'>https://github.com/shaneshka/weather</a></p>
            <p>Api - <a href='/api/SampleData/WeatherForecasts?name=London' target='_blank'>/api/SampleData/WeatherForecasts?name=London</a></p>
            <p>UI - <a href='/fetch-data' target='_blank'>/fetch-data</a></p>
       </div>
    );
  }
}
