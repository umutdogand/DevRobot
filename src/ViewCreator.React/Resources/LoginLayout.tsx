import FeatureBase from "./FeatureBase";
import FeatureBaseProps from "./FeatureBaseProps";
import Button from "./Button";
import Input from "./Input";
import React from "react";
import ReactDom from "react-dom";

export default class LoginLayout extends FeatureBase {
    constructor(props : FeatureBaseProps) {
        super(props);
    }
    render() {
        return (
        <div>
            <div className="row col-md-3">
                <label></label>
                <Input ></Input>
            </div>
            <div className="row col-md-3">
                <label></label>
                <Input></Input>
            </div>
            <div className="row col-md-3">
                <Button></Button>
            </div>
        </div>)
    }
}