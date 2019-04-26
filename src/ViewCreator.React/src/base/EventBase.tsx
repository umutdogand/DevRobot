import EventHandler from "../model/Handler";
import LoggerBase from "./LoggerBase";

export default abstract class EventBase<P = {}> extends LoggerBase<P> {

    private _eventHandler : EventHandler;

    public constructor(props : P) {
        super(props);
        this._eventHandler = new EventHandler(this);
    }

    /**
     * Eventi dinleyenlerine yayar
     * @param event Event adı
     * @param args Dinleyici fonksiyonlara gönderilecek argumanlar
     */
    public emit(event : string, ...args : any[]) : void {
        this._eventHandler.emit(event, ...args);
    }

    /**
     * Belirtilen eventi DOM nesnesine dispatch eder
     * @param event Event adı
     * @param eventInit EventInit nesnesi
     */
    public dispatch(event : string, eventInit? : EventInit) : boolean {
        return this._eventHandler.dispatch(event, eventInit);
    }

    /**
     * Eventi dinler
     * @param event Event adı
     * @param action Tetiklenecek fonsksiyon
     */
    public on(event : string , action : Function) : void {
        return this._eventHandler.on(event, action);
    }
}