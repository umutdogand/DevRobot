import { LogLevel } from "./LogLevel";
import EventId from "./EventId";

export default abstract class Logger 
{
    abstract isEnabled(logLevel : LogLevel) : boolean;
    
    abstract log<TState>(logLevel : LogLevel, eventId : EventId | null, state : TState | null, exception : Error | null, formatter : (state: TState, error : Error) => string) : void;  

    public error(message : string,  exception : Error | null = null, eventId : EventId | null = null, ...args : object[]) : void{
        this.log(LogLevel.Error, eventId, null, exception, (state, error) => { return message; } );
    }

    public critical(message : string,  exception : Error | null = null, eventId : EventId | null = null, ...args : object[]) : void {
        this.log(LogLevel.Critical, eventId, null, exception, (state, error) => { return message; } );
    }

    public debug(message : string,  exception : Error | null = null, eventId : EventId | null = null, ...args : object[]) : void {
        this.log(LogLevel.Debug, eventId, null, exception, (state, error) => { return message; } );
    }

    public info(message : string,  exception : Error | null = null, eventId : EventId | null = null, ...args : object[]) : void {
        this.log(LogLevel.Information, eventId, null, exception, (state, error) => { return message; } );
    }

    public trace(message : string,  exception : Error | null = null, eventId : EventId | null = null, ...args : object[]) : void{
        this.log(LogLevel.Trace, eventId, null, exception, (state, error) => { return message; } );
    }

    public warn(message : string,  exception : Error | null = null, eventId : EventId | null = null, ...args : object[]) : void {
        this.log(LogLevel.Warning, eventId, null, exception, (state, error) => { return message; } );
    }
}