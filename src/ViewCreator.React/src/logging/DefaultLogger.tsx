import Logger from "./Logger"
import { LogLevel } from "./LogLevel"
import EventId from "./EventId"

export default class DefaultLogger extends Logger {

    private _logLevel: LogLevel;
    private _categoryName : string;

    public constructor(logLevel: LogLevel, categoryName : string) {
        super();
        this._logLevel = logLevel;
        this._categoryName = categoryName;
    }
    
    public isEnabled(logLevel: LogLevel): boolean {
        return this._logLevel >= logLevel;
    }

    public log<TState>(logLevel: LogLevel, eventId: EventId, state: TState, exception: Error, formatter: (state: TState, error: Error) => string) : void {
        if(this.isEnabled(logLevel)) {
            const message = formatter(state, exception);
            switch (logLevel) {
                case LogLevel.Trace: console.trace(message, state); break;
                case LogLevel.Debug:console.debug(message, state); break;
                case LogLevel.Information: console.info(message, state); break;
                case LogLevel.Warning: console.warn(message, state); break;
                case LogLevel.Error: console.error(message, state, exception); break;
                case LogLevel.Critical: console.exception(message, state, exception); break;
                default: break;
            }
        }
    }
}