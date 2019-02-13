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

class LinerLayout {

}

class ModelComponentLayot extends React.Component {
    constructor(props) {
        super(props);
    }
    render() {
        return (
            <Button props="{this.prop.ButtonObj}"></Button>
            <Label props="{this.prop.ButtonObj}"></Label>
            <Input><Input>
        );
    }
}




const rootElement = document.getElementById('root');

ReactDOM.render(

    <ModelComponentLayot>
                    <Button props="{this.prop.ButtonObj}"></Button>
                    <Label props="{this.prop.ButtonObj}"></Label>
                    <Input><Input>
        </ModelComponentLayot > 
    rootElement);
