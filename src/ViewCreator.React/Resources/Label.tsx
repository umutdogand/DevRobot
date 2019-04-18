import FeatureBase from "./FeatureBase";
import FeatureBaseProps from "./FeatureBaseProps";

export default class Label extends FeatureBase {
    constructor(props : FeatureBaseProps) {
        super(props);
    }
    render() {
        return (<label></label>);
    }
}
