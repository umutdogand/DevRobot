//import './css/Label.css';

class Label extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        console.log(this.props.attributes);
        return (
            <label props={this.props.attributes}></label>
        );
    }
}