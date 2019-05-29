import React, { Component } from 'react';
import { TablePagination } from 'react-pagination-table';

const Header = ["Name", "Letter"];

export class FetchData extends Component {
    displayName = FetchData.name

    constructor(props) {
        super(props);
        this.state = { planets: [], loading: true, activePage: 1, totalNumberOfRecords: 10 };

        fetch(`api/ExoPlanet/GetAll?pageNumber=${this.state.activePage}&numberOfRecords=10`)
            .then(response => response.json())
            .then(data => {
                this.setState({
                    planets: data.data,
                    loading: false,
                    totalNumberOfRecords: data.totalNumberOfRecords
                });

                console.log(data);
            });
    }

    static renderPlanetsTable(planets, totalNumberOfRecords) {
        return (
            <div>
                <TablePagination
                    title="Nasa exo planets"
                    headers={Header}
                    data={planets}
                    columns="pl_hostname.pl_letter"
                    perPageItemCount={10}
                    totalCount={totalNumberOfRecords}
                    arrayOption={[["size", 'all', ' ']]}
                />
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderPlanetsTable(this.state.planets, this.state.totalNumberOfRecords);

        return (
            <div>
                <h1>Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }
}
