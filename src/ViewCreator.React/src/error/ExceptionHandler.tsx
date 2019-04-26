/**
 * Exception handler, oluşan bir hatanın yakalanması ve gerekli işlemlerin yapılmasını sağlar.
 * Middleware mantığıyla çalışır. Sırasıyla tüm handlerlar hata yakalanana kadar ve gerekli işlemler yapılana kadar devam eder.
 */
export default class ExceptionHandler {
    
    /**
     * Gelen hatayı handle eder
     * @param ex Hata nesnesi
     * @param next Bir sonraki handlera geçer
     * @param optionalParameter Hata yakalamak için opsiyonel elemanlar
     */
    public handle(ex : Error, next : () => boolean, ...optionalParameter : any[]) : boolean {
        return next();
    }
}