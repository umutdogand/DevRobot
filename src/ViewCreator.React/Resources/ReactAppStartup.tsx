import ExceptionHandler from "./ExceptionHandler";
import XhrResponseResolver from "./XhrResponseResolver";
import DefaultExceptionHandler from "./DefaultExceptionHandler";
import JsonResponseResolver from "./JsonResponseResolver";
import { createStore, applyMiddleware } from "redux";

export default class ReactAppStartup {

    private static ExceptionHandlerList : Array<ExceptionHandler> = null;
    private static ResponseResolver : XhrResponseResolver = null; 

    static ReactAppStartup() {
        this.ExceptionHandlerList = new Array<ExceptionHandler>();
        this.ExceptionHandlerList.push(new DefaultExceptionHandler());
        this.ResponseResolver = new JsonResponseResolver();
    }

    static getResponseResolver() : XhrResponseResolver {
        return this.ResponseResolver;
    }

    static addExceptionHandler(handler : ExceptionHandler) {
        this.ExceptionHandlerList.push(handler);
    }

    static handleError(ex : Error, ...optionalParameter : any[]) : void {
        this.handlingError(ex, length, this.ExceptionHandlerList, optionalParameter);
    }
    
    private static handlingError(ex : Error, i : number, array : Array<ExceptionHandler>, ...optionalParameter : any[]) : boolean {
        return array[i].handle(ex, () => {
            if(i - 1 >= 0) {
                return this.handlingError(ex, i - 1, array, optionalParameter);
            } else {
                return false;
            }
        }, optionalParameter);
    }
}