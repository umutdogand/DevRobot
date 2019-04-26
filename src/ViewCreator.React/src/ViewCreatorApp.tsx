import ExceptionHandler from "./error/ExceptionHandler";
import DefaultExceptionHandler from "./error/DefaultExceptionHandler";
import viewCreatorReducer from "./model/ViewCreatorReducer";
import { createStore, applyMiddleware, Store } from "redux";
import thunk from 'redux-thunk';
import PaletteSet from "./styled/PaletteSet";
import LoggerProvider from "./logging/LoggerProvider";
import DefaultLoggerProvider from "./logging/DefaultLoggerProvider";
import { LogLevel } from "./logging/LogLevel";
import LoggerFactory from "./logging/LoggerFactory";
import Logger from "./logging/Logger";
import TemplateBase from "./base/TemplateBase";

export default class ViewCreatorApp {

    private static _instance : ViewCreatorApp | null = null;

    private _templates : Array<TemplateBase<any>>;
    private _paletteSet : PaletteSet;
    private _store : Store<{}, any>;
    private _exceptionHandlerList : Array<ExceptionHandler>;
    private _loggerFactory : LoggerFactory;
    private _logger : Logger;

    /**
     * Singleton patterni, instance objesi
     */
    public static get instance() : ViewCreatorApp {
        if(ViewCreatorApp._instance) {
            return ViewCreatorApp._instance;
        } else {
            ViewCreatorApp._instance = new ViewCreatorApp();
        }
        return ViewCreatorApp._instance;
    }

    /**
     * Geçerli olan paleti verir
     */
    public get paletteSet() : PaletteSet {
        return this._paletteSet;
    }

    private constructor() {
        this._exceptionHandlerList = new Array<ExceptionHandler>();
        this._exceptionHandlerList.push(new DefaultExceptionHandler());
        this._store = this.initStore();
        this._paletteSet = new PaletteSet();
        this._templates = new Array<TemplateBase<any>>();
        this._loggerFactory = new LoggerFactory();
        this._loggerFactory.setProvider(new DefaultLoggerProvider(LogLevel.Warning));
        this._logger = this._loggerFactory.createLogger(this.constructor.name);
    }

    public addExceptionHandler(handler : ExceptionHandler) : ViewCreatorApp {
        this._exceptionHandlerList.push(handler);
        return this;
    }

    public handleError(ex : Error, ...optionalParameter : any[]) : void {
        this.handlingError(ex, this._exceptionHandlerList.length - 1, this._exceptionHandlerList, ...optionalParameter);
    }

    public setActivePaletteSet(paletteSet : PaletteSet) {
        if(paletteSet instanceof PaletteSet) {
            if(paletteSet != this._paletteSet) {
                this._paletteSet = paletteSet;
                this._templates.forEach(template => {
                    template.forceUpdate();
                });
            } else {
                this._logger.info("New palette set is not diffrent than old one");
            }
        }
    }

    public storeGetState() : any {
        return this._store.getState();
    }

    public storeSubscribe(action : any) {
        return this._store.subscribe(action);
    }

    public storeDispatch(action : any) {
        return this._store.dispatch(action);
    }

    private initStore() : Store<{}, any> {
        const logger = () => (next: (arg0: any) => void) => (action: any) => {
            this._logger.trace("redux action : " + action.type);
            next(action);
        };
        const error = () => (next: (arg0: any) => void) => (action: any) => {
            try {
                next(action);
            }
            catch (e) {
                this.handleError(e);
            }
        };
        return createStore(viewCreatorReducer, applyMiddleware(thunk, logger, error));
    }

    private handlingError(ex : Error, i : number, array : Array<ExceptionHandler>, ...optionalParameter : any[]) : boolean {
        return array[i].handle(ex, () => {
            if(i - 1 >= 0) {
                return this.handlingError(ex, i - 1, array, optionalParameter);
            } else {
                return false;
            }
        }, ...optionalParameter);
    }

    public register(template : TemplateBase<any>) {
        if(this._templates.indexOf(template) < 0) {
            this._templates.push(template);
            return;
        }
        this._logger.warn("Template already registered");
    }

    public unregister(template : TemplateBase<any>) {
        const index = this._templates.indexOf(template);
        if(index >= 0) {
            this._templates.splice(index, 1);
        }
        this._logger.warn("Template not registered");
    }

    public setLoggerProvider(loggerProvider : LoggerProvider) {
        this._loggerFactory.setProvider(loggerProvider);
        this._logger = this._loggerFactory.createLogger(this.constructor.name)
    }

    public createLogger(categoryName : string) : Logger {
        try {
            const result = this._loggerFactory.createLogger(categoryName);
            if(result) {
                return result;
            }
        } catch { }
        throw new Error("Logger provider is not defined. Please call setLoggerProvider and set LoggerProvider before you create");
    }
}