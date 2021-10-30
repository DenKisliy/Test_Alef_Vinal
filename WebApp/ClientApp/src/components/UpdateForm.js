import React, { Component } from 'react';
import Select from 'react-select';
import axios from 'axios';
import './UpdateForm.css';

export class UpdateForm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            id: '',
            name: '',
            value: '',
        };

        this.names = [];
        this.getListOfProducts(this.names);
    }

    handleChange(evt) {
        const financialGoal = (evt.target.validity.valid) ? evt.target.value : this.state.value;
        this.setState({ value: financialGoal });
    }

    handleChangeName(event) {
        this.setState({ name: event.target.value });
    }

    getListOfProducts(mass) {
        axios({
            method: 'get',
            url: 'api/Update/list',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        }).then(response => {
            response.data.map(function (item, i) {
                mass.push({
                    value: item.id,
                    label: item.valueAndName
                })
            })
        });
    }

    handleChangeSelect = (selectedOption) => {
        let nameAndValue = selectedOption.label.split(' ');
        this.setState({ id: selectedOption.value });
        this.setState({ name: nameAndValue[1] });
        this.setState({ value: nameAndValue[0] });
    };

    SubmitHandler = e => {

        const data = new FormData();
        data.append("id", this.state.id);
        data.append("Name", this.state.name);
        data.append("Value", this.state.value);


        axios({
            method: 'post',
            url: 'api/Update/update',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        });
    }

    render() {
        return (
            <form className="update-form" onSubmit={this.SubmitHandler}>
                <Select options={this.names} onChange={this.handleChangeSelect}/>
                <label> <a>ИД</a> <input readOnly type="text" className="select-form-id" value={this.state.id}/> </label>
                <label> <a>Значение</a> <input type="text" value={this.state.value} pattern="[0-9]*" onInput={this.handleChange.bind(this)}  /> </label>
                <label> <a>Имя</a> <input type="text" value={this.state.name} onChange={this.handleChangeName.bind(this)}/> </label>
                <label> <input className="update-form-button" type="submit" value="Изменить" /> </label>
            </form>
        );
    }
}
