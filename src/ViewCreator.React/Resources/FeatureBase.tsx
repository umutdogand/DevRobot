import React from "react"
import FeatureBaseProps from "./FeatureBaseProps";
import Feature from "./Feature";

export default class FeatureBase extends React.Component {
    constructor(props : FeatureBaseProps) {
        super(props);
        
        props.data = props.data || {};
        props.features = props.features || new Array<Feature>();
        
        this.state = { data: props.data };
    }
    getFeature(key : string) : string {
        var props = this.props as FeatureBaseProps;
        var feature = props.features.find((element) => { return element.key == key;}) || { value : null }
        return feature.value;
    }
}