class Button extends React.Component {
    constructor(props) {
        super(props);
    }
    render() {
        return (
            <button name={this.props.Name}
                className={this.props.Class}
                style={this.props.Style}></button>
        );
    }
}