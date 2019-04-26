import ElementBase from "./ElementBase"
import { ElementBaseProps } from "../model/ElementBaseProps";
import { Type } from "../model/Type";
import Helper from "../Helper";
import ViewCreatorApp from "../ViewCreatorApp";
import { dataUpdateAsyncAction, dataUpdateAction } from "../model/ViewCreatorReducer";
import Reloader from "./Reloader";
import ContainerBase from "./ContainerBase";

export default abstract class TemplateBase<P extends ElementBaseProps = ElementBaseProps> extends ElementBase<P> {

    /**
     * En baştaki FeatureBase nesnesi
     */
    private _root : ContainerBase<P> | null;

    /**
     * Root setter
     */
    public set root(root : ContainerBase<P> | null) {
        this._root = root;
    }

    /**
     * Root getter
     */
    public get root() : ContainerBase<P> | null {
        return this._root;
    }

    /**
     * Layout için kullanılacak olan referans nesnesini hazırlar.
     */
    public constructor (props : P) {
        super(props);
        this._root = null;
        if(this.props.data instanceof Function) {
            ViewCreatorApp.instance.storeDispatch(dataUpdateAsyncAction(this.key, this.props.data));
        } else {
            ViewCreatorApp.instance.storeDispatch(dataUpdateAction(this.key, (this.props.data || null)));
        }
    }

    /**
     * Tüm ağacı gezerek istenen tipdeki elemanları getirir
     * @param root En üsteki eleman
     * @param type Aranan type adı
     */
    public findByType(type : Type) : ElementBase<P>[]  {
        return Helper.findByType(this._root, type);
    }

    /**
     * Tüm ağacı gezerek istenen property adına sahip elemanları getirir
     * @param root En üsteki eleman
     * @param propretyName Aranan property adı
     */
    public findByProp(propretyName : string) : ElementBase<P>[] {
        return Helper.findByProp(this._root, propretyName);
    }

    /**
     * Tüm ağacı gezerek istenen key değerine sahip elemanı getirir
     * @param propretyName Aranan key
     */
    public findByKey(key : string) : ElementBase<P> | null {
        return Helper.findByKey(this._root, key);
    }

    /**
     * Tüm componentleri gezer, uygun pathe sahip elemanları bularak dizi olarak döndürür
     * Başlangıç olarak root dan başlar
     * @param path Property yolu
     */
    public findByPath(path : string) : ElementBase<P>[] {
        return Helper.findByPath(this._root, path);
    }
    
    public componentDidMount() {
        super.componentDidMount();
        ViewCreatorApp.instance.register(this);
    }

    /**
     * Component unmout edildikten sonra state verisi silinir
     */
    public componentDidUpdate() {
        super.componentDidUpdate();
        ViewCreatorApp.instance.storeDispatch(dataUpdateAction(this.key, undefined));
        ViewCreatorApp.instance.unregister(this);
    }

    /**
     * Modeli reloader kullanarak yeniler.
     * Birden fazla reloader olabilir. Bunun için hangisinin seçileceği belirtilmelidir.
     * @param reloaderKey Reloader anahtarı
     */
    public reload(reloaderKey : string | null) {
        let reloader : ElementBase<any> | null = null;
        if(reloaderKey) {
            reloader = this.findByKey(reloaderKey);
        } else {
            const reloaders = this.findByType(Reloader);
            if(reloaders.length > 0) {
                reloader = reloaders[0];
            }
        }
        if(reloader instanceof Reloader) {
            reloader.reload();
        } else {
            this.logger.warn("Reloader not found");
        }
    }

    public forceUpdate() {
        if(this._root != null) {
            this._root.forceUpdate();
        }
        super.forceUpdate();
    }
}