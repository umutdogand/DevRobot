import React from 'react';
import ReactDOM from 'react-dom';

class Button extends React.Component {
    constructor(props) {
        super(props);
    }
    render() {
        return (
            <button name={this.props.Name}
                className={this.props.Class}
                style={this.props.Style}>{this.props.Value}</button>
        );
    }
}

class Label extends React.Component {
    constructor(props) {
        super(props);
    }
    render() {
        return (
            <label id={this.props.Id}
                name={this.props.Name}
                className={this.props.Class}
                style={this.props.Style}
                for={this.props.For}>{this.props.Value}</label>
        );
    }
}