import React, { Component } from 'react';
import ReactTable from 'react-table';
import 'react-table/react-table.css';

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
                    loading: false,
                    pageSize: pageSize,
                    activePage: index,
                    totalNumberOfRecords: data.totalNumberOfRecords
                });
            });
    }

    render() {
        
        const columns = [{
            Header: 'Name',
            accessor: 'pl_hostname' // String-based value accessors!
        }, {
            Header: 'Letter',
                accessor: 'pl_letter'
        }];

        return <ReactTable
            data={this.state.planets}
            columns={columns}
            defaultPageSize={this.state.pageSize}
            pageSize={this.state.pageSize}
            loading={this.state.loading}
            page={this.state.activePage}
            onPageChange={(pageIndex) => { this.fetchPlanets(this.state.pageSize, pageIndex) }}
            onPageSizeChange={(pageSize, pageIndex) => { this.fetchPlanets(pageSize, pageIndex) }}
        />
    }
}
