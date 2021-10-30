import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
            <div>
                <p>Для обновления продукта нажмите на кнопку "Обновить продукт"</p>
                <p>Для создания продукта нажмите на кнопку "Создать продукт"</p>
                </div>
        );
    }
}
