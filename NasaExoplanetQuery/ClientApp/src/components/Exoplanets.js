import React, { Component } from 'react';
import ReactTable from 'react-table';
import 'react-table/react-table.css';
import './Exoplanets.css';
import matchSorter from 'match-sorter';

export class FetchData extends Component {

    displayName = FetchData.name

    constructor(props) {
        super(props);
        this.state = { planets: [], loading: true};
        this.fetchPlanets();
    }

    fetchPlanets() {
        fetch(`api/ExoPlanet/GetAll?pageNumber=${0}&numberOfRecords=${4000}`)
            .then(response => response.json())
            .then(data => {
                this.setState({
                    planets: data.data,
                    loading: false
                });
            });
    }

    render() {
        
        const columns = [
            {
                Header: 'Name',
                accessor: 'pl_hostname',
                className: "center",
                filterMethod: (filter, rows) =>
                    matchSorter(rows, filter.value, { keys: ["pl_hostname"] }),
                filterAll: true
            },
            {
                Header: 'Letter',
                accessor: 'pl_letter',
                className: "center",
                filterMethod: (filter, rows) =>
                    matchSorter(rows, filter.value, { keys: ["pl_letter"] }),
                filterAll: true
            },
            {
                Header: 'Discovery Method',
                accessor: 'pl_discmethod',
                className: "center",
                filterMethod: (filter, rows) =>
                    matchSorter(rows, filter.value, { keys: ["pl_discmethod"] }),
                filterAll: true
            },
            {
                Header: 'Discovery Facility',
                accessor: 'pl_facility',
                className: "center",
                filterMethod: (filter, rows) =>
                    matchSorter(rows, filter.value, { keys: ["pl_facility"] }),
                filterAll: true
            }];

        return <ReactTable
            className={'center'}
            data={this.state.planets}
            columns={columns}
            loading={this.state.loading}
            filterable
            defaultFilterMethod={(filter, row) => String(row[filter.id]) === filter.value}
        />
    }
}
