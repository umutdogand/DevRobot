import Logger from "./Logger";
import LoggerProvider from "./LoggerProvider";
import DefaultLogger from "./DefaultLogger";
import { LogLevel } from "./LogLevel";

export default class DefaultLoggerProvider implements LoggerProvider
{
    private _logLevel : LogLevel;

    constructor(logLevel : LogLevel) {
        this._logLevel = logLevel;
    }

    public createLogger(categoryName : string) : Logger {
        return new DefaultLogger(this._logLevel, categoryName);
    }
}