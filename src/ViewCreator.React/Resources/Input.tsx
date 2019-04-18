import FeatureBase from "./FeatureBase";
import FeatureBaseProps from "./FeatureBaseProps";

export default class Input extends FeatureBase {
    constructor(props : FeatureBaseProps) {
        super(props);
    }
    render() {
        return (<input></input>);
    }
}
