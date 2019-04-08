//import './css/LinearLayout.css';

class LinearLayout extends Layout {
    divStyle = {
        float: 'left'
    };
    constructor(props) {
        super(props);
    }
    render() {
        return (
            <div>
                props.children.map((item, key) =>
                    <div style="{divStyle}">
                        {item}
                    </div>
                );
            </div>
        );
    }
}