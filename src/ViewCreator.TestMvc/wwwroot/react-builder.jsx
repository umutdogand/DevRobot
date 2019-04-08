//import React from 'react';
//import ReactDOM from 'react-dom';

class HTTPRequestProvider {
    constructor(requestInfo) {
        this.requestInfo = requestInfo;
    }
    sendRequest() {
        var xhr = null;
        if (window.XMLHttpRequest) {
            xhr = new XMLHttpRequest();
        } else {
            xhr = new ActiveXObject("Microsoft.XMLHTTP");
        }

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
            xhr.onLoad = () => { onLoad(xhr); };
            xhr.onError = () => { onLoadError(xhr); }
            if (method == "POST" || method == "post") {
                xhr.send();
            } else {
                xhr.setRequestHeader('Content-type', contentType);
                xhr.send(data);
            }
        }
    }
}
class XhrResponseResolver {
    resolve(xhr) { return {}; }
}
class JsonResponseResolver extends XhrResponseResolver {
    resolve(xhr) {
        if (xhr.readyState == 4) {
            if (xhr.status === 200) {
                try {
                    return JSON.parse(xhr.responseText || "{}");
                } catch(ex) {
                    console.exception(ex, xhr);
                }
            } else {
                console.error(xhr.responseText || ("Request failed " + xhr.responseURL), xhr);
            }
        }
        return super.resolve(xhr);
    }
}
class FeatureBase extends React.Component {
    constructor(props) {
        super(props);
        this.loadResolver = new JsonResponseResolver();
        this.props.requestInfo = this.props.requestInfo || {};
        this.props.initialData = this.props.initialData || {};
        this.props.attributes = this.props.attributes || {};
        this.state = { data: this.props.initialData };
        this.load = this.load.bind(this);
        this.onLoad = this.onLoad.bind(this);
        this.onLoadError = this.onLoadError.bind(this);
    }
    load() {
        this.props.requestInfo.onLoad = this.onLoad;
        this.props.requestInfo.onLoadError = this.onLoadError;
        var httpRequestProvider = new HTTPRequestProvider(this.props.requestInfo);
        httpRequestProvider.sendRequest();
    }
    onLoad(xhr) {
        const data = loadResolver.resolve(xhr);
        if (data) {
            this.setState({ data: data });
        }
    }
    onLoadError(xhr) {
        console.error(xhr.responseText || ("Request failed " + xhr.responseURL), xhr);
    }
    componentDidMount() {
        if (this.props.requestInfo.url) {
            window.setInterval(() => this.load(), this.props.requestInfo.interval || 1000);
        }
    }
    componentWillUnmount() { }
}
class Component extends FeatureBase {
    constructor(props) {
        super(props);
    }
}
class Layout extends FeatureBase {
    constructor(props) {
        super(props);
        this.submitResolver = new JsonResponseResolver();
        this.props.formInfo = this.props.formInfo || {};
        this.submit = this.submit.bind(this);
        this.onSubmit = this.onSubmit.bind(this);
        this.onSubmitError = this.onSubmitError.bind(this);
    }
    submit() {
        this.props.formInfo.onSubmit = this.onSubmit;
        this.props.formInfo.onSubmitError = this.onSubmitError;
        var httpRequestProvider = new HTTPRequestProvider(this.props.formInfo);
        httpRequestProvider.sendRequest();
    }
    onSubmit(xhr) {
        const data = submitResolver.resolve(xhr);
        if (data) {
            this.setState({ data: data });
        }
    }
    onSubmitError(xhr) {
        console.error(xhr.responseText || ("Request failed " + xhr.responseURL), xhr);
    }
}

// InputAttribute
//import './css/Input.css';

class Input extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return (
            <input></input>
        );
    }
}
// LabelAttribute
//import './css/Label.css';

class Label extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        console.log(this.props.attributes);
        return (
            <label props={this.props.attributes}></label>
        );
    }
}
// ButtonAttribute
//import './css/Button.css';

class Button extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return (
            <button></button>
        );
    }
}
// LinearLayoutAttribute
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

