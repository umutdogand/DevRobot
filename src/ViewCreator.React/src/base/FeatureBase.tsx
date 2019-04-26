import { FeatureBaseProps } from "../model/FeatureBaseProps";
import Feature from "../model/Feature";
import { FeatureType } from "../model/FeatureType";
import ReactDOM from "react-dom";
import { RefObject } from "react";
import ElementBase from "./ElementBase";

export default abstract class FeatureBase<P extends FeatureBaseProps = FeatureBaseProps> extends ElementBase<P>
{
    /**
     * React element attribute için özellik filtresi
     */
    protected readonly ReactPropsTypeFilter : (f:Feature) => boolean = (f) => f.type == FeatureType.ReactProps;
    
    /**
     * Html element attribute için özellik filtresi
     */
    protected readonly HtmlAttributeTypeFilter : (f:Feature) => boolean = (f) => f.type == FeatureType.HTMLAttribute;
    
    /**
     * Özel tanımlılar için özellik filtresi
     */
    protected readonly CustomTypeFilter : (f:Feature) => boolean = (f) => f.type == FeatureType.Custom;

    /**
     * Sahip olduğu özelliği anahtar kelimesine göre bulur
     * @param key Anahtar
     */
    public getFeature(key : string) : string {
        if(this.props.features != undefined && this.props.features.length > 0) {
            const feature = this.props.features.find((element) => { return element.key == key;}) || new Feature(key, "", FeatureType.Custom);
            return feature.value;
        }
        return "";
    }

    /**
     * Elementin içerisindeki feature değerlerini birleştirerek tek bir obje haline getirir.
     * @param filter Feature filtesi
     */
    public getFeaturesAsObject(filter : (element : Feature) => boolean) : {} {
        const result : {[x: string]: any} = {};
        const props = this.props as FeatureBaseProps;
        const features = props.features;
        for(let i = 0; features && i < features.length; i++) {
            if(filter(features[i]) && features[i].value) {
                result[features[i].key] = features[i].value;   
            }
        }
        return result;
    }
    
    /**
     * Render içerisinde belirlenmiş componentlerin ref değerlerini alarak içerisine feature değerlerin atar.
     * @param ref Ref objesi
     * @param filter Atanmak istenen feature verileri için filtre fonksiyonu
     */
    public updateByRefWithFeatures<T>(ref : RefObject<T>, filter : (f:Feature) => boolean) : RefObject<T> {
        var featureProps = this.props as FeatureBaseProps;
        if(featureProps && featureProps.features) {
            var features = featureProps.features.filter(filter);
            if(ref && ref.current) {
                this.addAttributeToElement(ref.current, ...features);
            }
        }
        return ref;
    }

    /**
     * Render içerisinde belirlenmiş componentlerin referans ismine göre değerlerini alarak içerisine feature değerlerin atar.
     * @param refName Referans Adı
     * @param filter Atanmak istenen feature verileri için filtre fonksiyonu
     */
    public updateByRefNameWithFeatures<T>(refName : string, filter : (f:Feature) => boolean) : void {
        var featureProps = this.props as FeatureBaseProps;
        if(featureProps && featureProps.features) {
            var features = featureProps.features.filter(filter);
            this.addAttributeToElement(this.refs[refName], ...features);
        }
        return;
    }

    /**
     * Render içerisinde belirlenmiş componentlerin ref değerlerini alarak içerisine feature değerlerin atar.
     * @param refName İsim olarak kullanılmış ref değişkeni
     * @param filter Atanmak istenen feature verileri için filtre fonksiyonu
     */
    public addAttributeToElementByName(refName : string, ...features : Feature[]) {
        return this.addAttributeToElement(this.refs[refName], ...features);
    }

    /**
     * Render içerisinde belirlenmiş componentlerin ref değerlerini alarak içerisine feature değerlerin atar.
     * @param ref Ref objesi
     * @param features Atanacak olan özellikler dizisi
     */
    public addAttributeToElement(ref : any, ...features : Feature[]) {
        var domNode = ReactDOM.findDOMNode(ref);
        features.forEach((feature)=>{
            if(domNode instanceof Element) {
                domNode.setAttribute(feature.key, feature.value);
            }
        });
    }
}