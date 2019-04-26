import Logger from "./Logger";

export default interface LoggerProvider
{
    createLogger(categoryName : string) : Logger;
}