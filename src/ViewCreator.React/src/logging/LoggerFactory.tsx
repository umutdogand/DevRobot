import Logger from "./Logger"
import LoggerProvider from "./LoggerProvider"

export default class LoggerFactory
{
    private _provider : LoggerProvider | null = null;

    public setProvider(provider : LoggerProvider) : void {
        this._provider = provider;
    }

    public createLogger(categoryName : string) : Logger{
        if(this._provider) {
            return this._provider.createLogger(categoryName);
        } else {
            throw new Error("Logger provider not exist");
        }
    }
}