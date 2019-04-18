import ExceptionHandler from "./ExceptionHandler";

/*
    Hatayı console ekranına basar
*/

export default class DefaultExceptionHandler extends ExceptionHandler {
    handle(ex : Error, next : () => boolean, ...optionalParameter : any[]) : boolean {
        console.error(ex.message, optionalParameter);
        return next();
    }
}