import FeatureBase from "./FeatureBase";
import FeatureBaseProps from "./FeatureBaseProps";

export default class Button extends FeatureBase {
    constructor(props : FeatureBaseProps) {
        super(props);
    }
    render() {
        return (<button></button>);
    }
}