import XhrResponseResolver from "./XhrResponseResolver";
import ReactAppStartup from "./ReactApp";

export default class JsonResponseResolver extends XhrResponseResolver {
    resolve(xhr: XMLHttpRequest) {
        if (xhr.readyState === 4) {
            if (xhr.status === 200) {
                try {
                    return JSON.parse(xhr.responseText || "{}");
                } catch(ex) {
                    ReactAppStartup.handleError(ex, xhr);
                }
            } else {
                var error = new Error(xhr.responseText || ("Request failed : " + xhr.responseURL));
                ReactAppStartup.handleError(error, xhr);
            }
        }
        return super.resolve(xhr);
    }
}