import ElementBase from "./ElementBase";
import ReactDOM from "react-dom";
import React, { ReactElement, ComponentClass } from "react";
import FeatureBase from "./FeatureBase";
import { FeatureBaseProps } from "../model/FeatureBaseProps";
import RenderHelper from "../RenderHelper";
import { ParentalBaseProps } from "../model/ParentalBaseProps";
import StyledBase from "./StyledBase";

export default abstract class ContainerBase<P extends FeatureBaseProps> extends StyledBase<P> {

    /**
     * FeatureBase sınıfları içerisinde basşka featureBase nesneleri içerebilir.
     * Böylece bir hierarşi kurulmuş olur.
     */
    private _children : Array<ElementBase<P>>;

    /**
     * Elemanın çocuklarını verir
     */
    public get children() : Array<ElementBase<P>> {
        return this._children;
    }

    /**
     * FeatureBase tüm componentlerin temel yapısıdır.
     * Gerekli alt yapı elemanlarını barındırır.
     * @param props Properties
     */
    public constructor(props: P) {
        super(props);
        // Boş bir array oluşturur.
        this._children = new Array<ElementBase<P>>();
    }

    /**
     * Render edildikten sonra componentin altındaki diğer componentleri 
     * place değerine göre görekli yerlere yerleştirir
     */
    public componentDidMount() {
        this.renderChildren(null);
    }

    public forceUpdate() {
        for(let i = 0; i < this.children.length; i++) {
            this.children[i].forceUpdate();
        }
        super.forceUpdate();
    }

    protected renderChildren(domNode : Element | null) {
        let counter = 0;
        const isArray = Array.isArray(this.data);
        React.Children.forEach(this.props.children as any, c => {
            if(isArray && counter == 0) {
                const lenght = (this.data as any[]).length;
                for(let i = 0; i < lenght; i ++) {
                    this.addChild(c, domNode);
                }
            } else {
                this.addChild(c, domNode);
            }
            counter++;
        });
    }

    protected renderChild(child : ReactElement<P, ComponentClass<P>>, domNode : Element | null) : React.Component<any, any, any> | null  {
        const element = this.createElement(child);
        const dom = this.findParentDomElement(child, domNode);
        if(element && dom) {
            return ReactDOM.render(element, dom);
        }
        return null;
    }

    protected createElement(child : ReactElement<P, ComponentClass<any>>) : React.ComponentElement<any, React.Component<any, any, any>> | null {
        const parent = this;
        const template = this.template;
        const parentalProps : ParentalBaseProps = { addToParent : (e : ElementBase<P>)=> { this.children.push(e); }}
        const extraParams = { parent, template, ...parentalProps }
        return RenderHelper.createElement(child, extraParams);
    }

    protected findParentDomElement(child : ReactElement<P, ComponentClass<P>>, defaultDomNode : Element | null) : Element | null {
        return RenderHelper.findParentDomElement(child, (featureValue) => {
            if(featureValue && this.refs[featureValue]) {
                const domNode = ReactDOM.findDOMNode(this.refs[featureValue]);
                if(domNode instanceof Element) {
                    return domNode;
                }
            }
            return defaultDomNode;
        });
    }
    
    public addChild(child : ReactElement<P, ComponentClass<P>>, defaultDomNode : Element | null) : React.Component<any, any, any> | null {
        return this.renderChild(child, defaultDomNode);
    }

    public removeChild(element : ElementBase<P>) {
        const index = this._children.indexOf(element);
        if(index >= 0) {
            const dom = ReactDOM.findDOMNode(element);
            this._children.splice(index, 1);
            if(dom instanceof Element && dom.parentElement instanceof Element) {
                ReactDOM.unmountComponentAtNode(dom.parentElement);
                //dom.parentElement.removeChild(dom);
            }
        }
    }

    public replaceChild(element : ElementBase<P>, child : ReactElement<P, ComponentClass<P>>) {
        const index = this._children.indexOf(element);
        if(index >= 0) {
            const dom = ReactDOM.findDOMNode(element);
            this._children.splice(index, 1);
            if(dom instanceof Element && dom.parentElement instanceof Element) {
                ReactDOM.unmountComponentAtNode(dom.parentElement);
                //dom.parentElement.removeChild(dom);
                this.addChild(child, dom.parentElement);
            }
        }
    }
    
    public clearChildren() {
        const array = new Array<ElementBase<P>>();
        array.push(...this._children);
        for(let i = 0; i < array.length; i ++) {
            this.removeChild(array[i]);
        }
    }
}