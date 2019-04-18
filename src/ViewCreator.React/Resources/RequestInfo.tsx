
// HTTPRequestProvider tarafından kullanılan sınıftır 

export default class RequestInfo {

    method: string;
    async: boolean;
    user: string;
    pass: string;
    data: Document | BodyInit | null;
    contentType: string;
    url: string;
    onLoadError: ((x: XMLHttpRequest) => void);
    onLoad: ((x: XMLHttpRequest) => void);

    constructor() {
        this.method = "get";
        this.async = false;
        this.user = "";
        this.pass = "";
        this.data = null;
        this.contentType = "";
        this.url = "";
        this.onLoad = (xhr) => { };
        this.onLoadError = (xhr) => { };
    }
}