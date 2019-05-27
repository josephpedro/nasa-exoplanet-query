import React, { Component } from 'react';

export class FetchData extends Component {
  displayName = FetchData.name

  constructor(props) {
    super(props);
    this.state = { planets: [], loading: true };

      fetch('api/ExoPlanet/GetAll')
      .then(response => response.json())
      .then(data => {
        this.setState({ planets: data, loading: false });
      });
  }

  static renderPlanetsTable(planets) {
    return (
      <table className='table table-striped'>
        <thead>
          <tr>
            <th>Name</th>
            <th>Letter</th>
          </tr>
        </thead>
        <tbody>
                {planets.map(planet =>
                    <tr key={planet.pl_hostname + planet.pl_letter}>
                        <td>{planet.pl_hostname}</td>
                        <td>{planet.pl_letter}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : FetchData.renderPlanetsTable(this.state.planets);

    return (
      <div>
        <h1>Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }
}
