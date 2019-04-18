import RequestInfo from "./RequestInfo";

export default class HTTPRequestProvider {
    requestInfo: RequestInfo;
    constructor(requestInfo: RequestInfo) {
        this.requestInfo = requestInfo;
    }
    sendRequest() {
        var xhr = new XMLHttpRequest();
        var method = this.requestInfo.method || "get";
        var contentType = this.requestInfo.contentType || "application/json; charset=utf-8";
        var async = this.requestInfo.async || true;
        var user = this.requestInfo.user || null;
        var pass = this.requestInfo.pass || null;
        var data = this.requestInfo.data || null;
        var onLoad = this.requestInfo.onLoad || ((x) => { });
        var onLoadError = this.requestInfo.onLoadError || ((x) => { });
        if (this.requestInfo.url) {
            xhr.open(method, this.requestInfo.url, async, user, pass);
            xhr.onload = () => { onLoad(xhr); };
            xhr.onerror = () => { onLoadError(xhr); };
            if (method === "POST" || method === "post") {
                xhr.send();
            } else {
                xhr.setRequestHeader('Content-type', contentType);
                xhr.send(data);
            }
        }
    }
}