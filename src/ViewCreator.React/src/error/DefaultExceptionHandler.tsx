import ExceptionHandler from "./ExceptionHandler";

/**
 * Default hata yakalama nesnesi
 */
export default class DefaultExceptionHandler extends ExceptionHandler {

    /**
     * Gelen hatayı handle eder ve default olarak ekrana hatayı gösterir.
     * @param ex Hata nesnesi
     * @param next Bir sonraki handlera geçer
     * @param optionalParameter Hata yakalamak için opsiyonel elemanlar
     */
    public handle(ex : Error, next : () => boolean, ...optionalParameter : any[]) : boolean {
        console.error(ex.message, ...optionalParameter);
        return next();
    }
}