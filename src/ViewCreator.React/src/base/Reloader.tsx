import React, { RefObject } from "react";
import ContainerBase from "./ContainerBase";
import Features from "../model/Features";
import ViewCreatorApp from "../ViewCreatorApp";
import { dataUpdateAction } from "../model/ViewCreatorReducer";
import Helper from "../Helper";
import { FeatureBaseProps } from "../model/FeatureBaseProps";
import RenderHelper from "../RenderHelper";

export default class Reloader extends ContainerBase<FeatureBaseProps> {
    
    /**
     * Buton tagının referans objesi
     */
    private divRef : RefObject<HTMLDivElement>;
    
    /**
     * Reloader nesnesini oluşturur
     * @param props Properties
     */
    public constructor(props: any) {
        super(props);
        this.divRef = React.createRef();
    }
    
    /**
     * Component mount olduktan sonra çalışır.
     * Div elementine props içerisinde belirtilmiş olan html attribute'larını atar
     */
    public componentDidMount() {
        super.componentDidMount();
        this.updateByRefWithFeatures(this.divRef, this.HtmlAttributeTypeFilter);
    }
    
    /**
     * Reloaderı render eder
     */
    public onRender() {
        var divProps = this.getFeaturesAsObject(this.ReactPropsTypeFilter);
        return (
            <div ref={this.divRef} {...divProps}>
                {RenderHelper.renderChildren(this)}
            </div>
        );
    }

    /**
     * Veri güncellemesini ajax sorgusu yaparak elde eder
     */
    public reload() {
        const self = this;
        const url = this.getFeature(Features.FETCHURL);
        if(url) {
            fetch(url, {
                method : this.getFeature(Features.FETCHMETHOD),
                credentials : this.getFeature(Features.FETCHREQUESTCREDENTIALS) as RequestCredentials | undefined,
                body : this.getFeature(Features.FETCHBODY) as BodyInit | null,
                headers : Helper.parseStringArraysArray(this.getFeature(Features.FETCHHEADERS)) as HeadersInit
            }).then(function (response) {
                // Eğer başarılı olmuş ise
                // Sonucu json olarak alır
                if(response.status == 200) {
                    return response.json();
                } else {
                }
                // TODO: Logger ve exception handle
            }).then(function (result) {
                if(result && self.template) {
                    // store daki veriyi günceller
                    ViewCreatorApp.instance.storeDispatch(dataUpdateAction(self.template.key, result));
                }
            });
        }
    }

    public onReload() {
        
    }
}