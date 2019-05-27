import React, { Component } from 'react';
import Pagination from "react-js-pagination";
import 'bootstrap/dist/css/bootstrap.css';

export class FetchData extends Component {
    displayName = FetchData.name

    constructor(props) {
        super(props);
        this.state = { planets: [], loading: true, activePage: 1, itemsCountPerPage: 10 };

        fetch(`api/ExoPlanet/GetAll?pageNumber=${this.state.activePage}&numberOfRecords=${this.state.itemsCountPerPage}`)
            .then(response => response.json())
            .then(data => {
                this.setState({
                    planets: data.data,
                    loading: false
                });
            });
    }

    static renderPlanetsTable(planets) {
        return (
            <div>
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
                <div>
                    <Pagination
                        activePage={this.state.activePage}
                        itemsCountPerPage={10}
                        totalItemsCount={450}
                        pageRangeDisplayed={5}
                        onChange={this.handlePageChange}
                    />
                </div>
            </div>
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
