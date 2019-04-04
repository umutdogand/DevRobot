///*
// * Generated File
// */

///*
// * Header
// */

////import React from 'react';
////import ReactDOM from 'react-dom';

//export class BaseReactComponent extends React.Component {
//    constructor(props) {
//        super(props);
//    }
//}

///*
// * Body
// */
// InputAttribute
//import './css/Input.css';

//export class Input extends BaseReactComponent {
//    constructor(props) {
//        super(props);
//    }
//    render() {
//        return (
//            <input></input>
//        );
//    }
//}
// LabelAttribute
//import './css/Label.css';

export class Label extends React.Component {
    constructor(props) {
        super(props);
    }
    render() {
        return (
            <label></label>
        );
    }
}
// ButtonAttribute
//import './css/Button.css';

//export class Button extends BaseReactComponent {
//    constructor(props) {
//        super(props);
//    }
//    render() {
//        return (
//            <button></button>
//        );
//    }
//}
// LinearLayoutAttribute
//import './css/LinearLayout.css';

//export class LinearLayout extends BaseReactComponent {

//    divStyle = {
//        float: 'left'
//    };

//    constructor(props) {
//        super(props);
//    }
//    render() {
//        return (
//            <div>
//                props.children.map((item, key) =>
//                    <div style="{divStyle}">
//                        {item}
//                    </div>
//                );
//            </div>
//        );
//    }
//}
/*
 * Footer
 */

