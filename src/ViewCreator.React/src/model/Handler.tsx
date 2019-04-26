import EventBase from "../base/EventBase";

/**
 * Bir component event için gerekli type
 * Yanlızca EventHandler sınıfı içerisnde kullanılıyor.
 */
type ComponentEventType = {
    dom : Element | null,
    domEventName : string | null,
    functions : Function[]
} 

/**
 * 
 */
export default class EventHandler {

    /**
     * Register edilmiş olan tüm eventlar
     */
    private _componentEvents : { [name : string] : ComponentEventType; }
    /**
     * EventHandler'ın sahip olduğu FeatureBase nesnesi
     */
    private _component : EventBase<any>;

    /**
     * Event handler oluşturur.
     * @param component EventHandler'ın sahip olduğu FeatureBase nesnesi
     */
    constructor(component : EventBase<any>) {
        this._component = component;
        this._componentEvents = { };
    }

    /**
     * Dom da meydana gelecek olan eventleri yakalar.
     * Bu componenti dinleyenlerin tetiklenmesi sağlanır. 
     * Event listner tanımlarken componentin sahip olacağı isim ile DOM objesindeki aynı olmayabilir
     * Bunun için bir action a ihtiyaç duyulur. 
     * Bu action component için verilecek olan event ismini döndürür.
     * Action boş dönerse DOM event adı ile aynı isim verilir.
     * @param dom DOM objesi
     * @param action Component event adını veren fonksiyon
     * @param eventnames DOM objesindeki event isimleri
     */
    public registerEvent(dom : Element, action? : (dom : Element, name : string) => string, ...eventnames : string[]) : void {
        action = action || ((d, n) => { return n });
        for(let i = 0; i < eventnames.length; i++) {
            const componentEventName = action(dom, eventnames[i]) || eventnames[i];
            // Eğer event kayıt edilmiş ise, uyarı verir kayıt etmez
            if(this._componentEvents[componentEventName]) {
                // Eventi kayıt eder
                this._componentEvents[componentEventName] = { dom : dom, domEventName : eventnames[i], functions : [] };
            } else {
                const componentEvent = this._componentEvents[componentEventName];
                componentEvent.dom = dom;
                componentEvent.domEventName = eventnames[i];
            }
            dom.addEventListener(eventnames[i], (...args : any[]) => {
                this.emit(componentEventName, ...args);
            });
        }
    }

    /**
     * Eventi dinleyenlerine yayar
     * @param event Event adı
     * @param args Dinleyici fonksiyonlara gönderilecek argumanlar
     */
    public emit(event : string, ...args : any[]) : void {
        const componentEvent = this._componentEvents[event];
        if(componentEvent != null) {
            for(let i = 0; i < componentEvent.functions.length; i++) {
                componentEvent.functions[i].call(this._component, ...args);
            }
        }
    }

    /**
     * Belirtilen eventi DOM nesnesine dispatch eder
     * @param event Event adı
     * @param eventInit EventInit nesnesi
     */
    public dispatch(event : string, eventInit : EventInit | undefined) : boolean {
        const componentEvent = this._componentEvents[event];
        if(componentEvent != null && componentEvent.dom != null && componentEvent.domEventName != null) {
            return componentEvent.dom.dispatchEvent(new Event(componentEvent.domEventName, eventInit));
        }
        return false;
    }

    /**
     * Eventi dinler
     * @param event Event adı
     * @param action Tetiklenecek fonsksiyon
     */
    public on(event : string , action : Function) : void {
        let componentEvent = this._componentEvents[event];
        if(componentEvent == null) {
            componentEvent = { dom : null, domEventName : null, functions : [] };
            this._componentEvents[event] = componentEvent;
        }
        if(action) {
            componentEvent.functions.push(action);
        }
    }
}