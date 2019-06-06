import React, { Component } from 'react';
import ReactTable from 'react-table';
import 'react-table/react-table.css';
import './Exoplanets.css';

export class FetchData extends Component {

    displayName = FetchData.name

    constructor(props) {
        super(props);
        this.state = { planets: [], loading: true, activePage: 0, pageSize: 10, totalNumberOfRecords: 10 };
        this.fetchPlanets(this.state.pageSize, this.state.activePage);
    }

    fetchPlanets(pageSize, index) {
        fetch(`api/ExoPlanet/GetAll?pageNumber=${0}&numberOfRecords=${50000}`)
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
                className: "center"
            },
            {
                Header: 'Letter',
                accessor: 'pl_letter',
                className: "center"
            },
            {
                Header: 'Discovery Method',
                accessor: 'pl_discmethod',
                className: "center"
            },
            {
                Header: 'Discovery Facility',
                accessor: 'pl_facility',
                className: "center"
            }];

        return <ReactTable
            className={'center'}
            data={this.state.planets}
            columns={columns}
            loading={this.state.loading}
        />
    }
}
