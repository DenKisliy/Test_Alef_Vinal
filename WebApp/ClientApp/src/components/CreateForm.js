import React, { Component } from 'react';
import axios from 'axios';
import './CreateForm.css';

export class CreateForm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            name: '',
            value: '',
        };

    }

    handleChangeName(event) {
        this.setState({ name: event.target.value });
    }

    handleChange(evt) {
        const financialGoal = (evt.target.validity.valid) ? evt.target.value : this.state.value;
        this.setState({ value: financialGoal });
    }

    SubmitHandler = e => {
        const data = new FormData();
        data.append("Name", this.state.name);
        data.append("Value", this.state.value);


        axios({
            method: 'post',
            url: 'api/Create/add',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        }).then(response => {
            if (response.data) {
                alert('Продукт обновлен');
            } else {
                alert('Продукт не обновлен');
            }
        });
    }

    render() {
        return (

            <form className="create-form" onSubmit={this.SubmitHandler}>
                <label> <a>Значение</a> <input type="text" pattern="[0-9]*" onInput={this.handleChange.bind(this)} maxLength="3" value={this.state.value} /> </label>
                <label> <a>Имя</a> <input type="text" value={this.state.name} onChange={this.handleChangeName.bind(this)} /> </label>

                <label> <input className="create-form-button" type="submit" value="Создать" /> </label>
            </form>
        );
    }
}
