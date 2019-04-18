/*
    Exception handler, oluşan bir hatanın yakalanması ve gerekli işlemlerin yapılmasını sağlar.
*/

export default class ExceptionHandler {
    handle(ex : Error, next : () => boolean, ...optionalParameter : any[]) : boolean {
        return next();
    }
}