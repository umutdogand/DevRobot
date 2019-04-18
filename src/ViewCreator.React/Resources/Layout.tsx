import RequestInfo from "./RequestInfo";
import FeatureBaseProps from "./FeatureBaseProps";
import FeatureBase from "./FeatureBase";
import ReactAppStartup from "./ReactAppStartup";
import HTTPRequestProvider from "./HTTPRequestProvider";

export default class Layout extends FeatureBase {
    constructor(props : FeatureBaseProps) {
        super(props);
        this.load = this.load.bind(this);
        this.onLoad = this.onLoad.bind(this);
        this.onLoadError = this.onLoadError.bind(this);
    }
    load() {
        const requestInfo = new RequestInfo();
        requestInfo.onLoad = this.onLoad;
        requestInfo.onLoadError = this.onLoadError;
        var httpRequestProvider = new HTTPRequestProvider(requestInfo);
        httpRequestProvider.sendRequest();
    }
    onLoad(xhr: XMLHttpRequest) {
        const data = ReactAppStartup.getResponseResolver().resolve(xhr);
        if (data) { this.setState({ data: data }); }
    }
    onLoadError(xhr : XMLHttpRequest) {
        ReactAppStartup.handleError(new Error(xhr.responseText || ("Request failed " + xhr.responseURL)), xhr)
    }
}