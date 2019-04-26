import EventBase from "./EventBase";
import ContainerBase from "./ContainerBase";
import { ReactNode } from "react";
import { Type } from "../model/Type";
import ViewCreatorApp from "../ViewCreatorApp";
import { ElementBaseProps } from "../model/ElementBaseProps";
import { ParentalBaseProps } from "../model/ParentalBaseProps";
import TemplateBase from "./TemplateBase";
import Helper from "../Helper";

export default abstract class ElementBase<P extends ElementBaseProps = ElementBaseProps> extends EventBase<P>
{
    private _isMounted : boolean;

    /**
     * Elementin anahtar kelimesidir.
     * Her ElementBase nesnesi için, ulaşılabilir olabilmesi için anahtar kelimesi vardır
     * Bu sayede componentler erişilebilir olur
     */
    private _key : string = "";

    /**
     * Elementin gösterilme durumunu tutar
     */
    private _isShowed : boolean = true;

    /**
     * ViewModel verisinin tüm halini saklar.
     * Component üzerinden diğer verilere erişimini kolaylaştırmak için eklenmiştir.
     */
    private _model : any;

    /**
     * Model getter
     */
    public get model() : any {
        return Object.assign({}, this._model);
    }

    /**
     * Key getter
     */
    public get key() : string {
        return this._key;
    }

    /**
     * Is showed getter
     */
    public get isShowed() : boolean {
        return this._isShowed;
    }   

    /**
     * Elementin sahip olduğu, property datası getter fonksiyonu
     */
    public get data() : any {
        return (this.state == null ? null : (this.state.data || null));
    }

    /**
     * Elementin sahip olduğu, property datası setter fonksiyonu
     */
    public set data(data : any) {
        this.setState( { data : (data || null) });
    }
    
    /**
     * Elemanın hangi property'i temsil ettiğini tutar
     */
    public get propertyName() : string | undefined | null {
        return this.props.propertyName;
    }

    /**
     * Bir üst elemanı verir
     */
    public get parent() : ContainerBase<P> | null | undefined {
        return this.props.parent;
    }

    /**
     * İçinde bulunduğu template elemanı
     */
    public get template() : TemplateBase<P> | null | undefined {
        return this.props.template; 
    }
    
    /**
     * FeatureBase tüm componentlerin temel yapısıdır.
     * Gerekli alt yapı elemanlarını barındırır.
     * @param props Properties
     */
    public constructor(props: P) {
        super(props);
        this._isMounted = false;
        // Eğer props içerisinde key belirtilmemiş ise uniq bir değer üretilir.
        this._key = this.props.key || Helper.generateUnique();
        // Elementin store verileri init edilir. Redux store a kayıt olur.
        this.state = { data : (this.props.data || null) };
        ViewCreatorApp.instance.storeSubscribe(() => { this.initState(false); });
        this.initState(true);
        if(props.addToParent) { props.addToParent(this); }
    }

    /**
     * Render işlemini kontrol edebilmek için ovveride edilmiştir.
     * Alt sınıflar rendering fonksiyonunu ovveride etmelidir.
     */
    public render(): ReactNode {
        if(this._isShowed) {
            return this.onRender();
        } else {
            return null;
        }
    }

    /**
     * Render işlemini alt sınıflar bu fonksiyonu ovveride ederek belirtmelidir.
     */
    public abstract onRender() : ReactNode;

    /**
     * Tüm ağacı gezerek istenen tipdeki elemanları getirir
     * @param root En üsteki eleman
     * @param type Aranan type adı
     */
    
    public findByType(type : Type): ElementBase<P>[] {
        if(this.template) {
            return this.template.findByType(type);
        }
        return [];
    }

    /**
     * Tüm ağacı gezerek istenen property adına sahip elemanları getirir
     * @param root En üsteki eleman
     * @param propretyName Aranan property adı
     */
    public findByProp(propretyName : string) : ElementBase<P>[] {
        if(this.template) {
            return this.template.findByProp(propretyName);
        }
        return [];
    }

    /**
     * Tüm ağacı gezerek istenen key değerine sahip elemanı getirir
     * @param propretyName Aranan key
     */
    public findByKey(key : string) : ElementBase<P> | null {
        if(this.template) {
            return this.template.findByKey(key);
        }
        return null;
    }

    /**
     * Tüm componentleri gezer, uygun pathe sahip elemanları bularak dizi olarak döndürür
     * Başlangıç olarak root dan başlar
     * 
     * Template içerisinde uygun property yoluna uygun ElementBase nesneleri döndürür.
     * { UserList : [ { UserName : "Zübeyir "}, { UserName : "Umut" } } ] } örneği için path 
     * "UserList.UserName" gönderilir ise UserName property üzerinde de Input olduğunu düşünür isek
     * Tüm username inputlar gelir
     * 
     * @param path Property yolu
     */
    public findByPath(path : string) : ElementBase<P>[] {
        if(this.template) {
            return this.template.findByPath(path);
        }
        return [];
    }

    /**
     * Her template objesinin farklı state değeri vardır.
     */
    private initState(isInitial : boolean = false) {
        const state = ViewCreatorApp.instance.storeGetState();
        const template = this.template;
        if(template != null) {
            let data = state[template.key];
            if(data && (isInitial || template.data != data)) {
                // Eğer data değişmiş ise günceller
                data = this.dataParse(data, null);
                if(data != undefined && data != null && this.data != data) {
                    if(this._isMounted) {
                        this.data = data;
                    } else {
                        this.state = { data : data };
                    }
                }
            }
        }
    }

    /**
     * State datasını, parentlarda gezip parse ederek elde eder
     * @param data State datası
     */
    protected dataParse(data : any, child : ElementBase<P> | null) : any {
        if(this.parent != null) {
            data = this.parent.dataParse(data, this);
        }
        if(this.propertyName && data) {
            const resultData = data[this.propertyName];
            if(Array.isArray(resultData) && this instanceof ContainerBase && child) {
                const index = this.children.indexOf(child);
                if(index >= 0 && data instanceof Array) {
                    return data[index];
                }
            }
            return resultData;
        }
        return data;
    }

    public componentDidMount() {
        this._isMounted = true;
    }

    public componentDidUpdate() {
    }

    /**
     * Elementin render edilmesini sağlar
     */
    public show() {
        if(this._isShowed == false) {
            this._isShowed = true;
            this.forceUpdate();
        }
    }

    /**
     * Elemanın render edilmesini engeller
     */
    public hide() {
        if(this._isShowed == true) {
            this._isShowed = false;
            this.forceUpdate();
        }
    }
}