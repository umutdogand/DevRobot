import ElementBase from "../core/base/ElementBase"
import { ComponentClass, ReactElement } from "react";
import { FeatureBaseProps } from "./model/FeatureBaseProps";
import { ElementBaseProps } from "./model/ElementBaseProps";
import React from "react";
import Feature from "./model/Feature";
import Features from "./model/Features";
import { FeatureType } from "./model/FeatureType";
import ViewCreatorApp from "./ViewCreatorApp";
import Logger from "./logging/Logger";
import ContainerBase from "./base/ContainerBase";
import { ParentalBaseProps } from "./model/ParentalBaseProps";

export default class RenderHelper {

    private static logger : Logger = ViewCreatorApp.instance.createLogger("RenderHelper");

    public static renderChildren<P extends ElementBaseProps>(element : ContainerBase<P>) {
        return React.Children.map(element.props.children as any, child => {
            const extraParams : ParentalBaseProps = { addToParent : (e : ElementBase<P>)=> {
                element.children.push(e);
            }}
            return RenderHelper.createElement(child, extraParams);
        });
    }

    public static render<P extends ElementBaseProps>(element : ReactElement<P, ComponentClass<P>>, propsLoader : () => {} | (Promise<{} | undefined | null>) | Function) : React.ComponentElement<any, React.Component<any, any, any>> | null {
        return RenderHelper.createElement(element, propsLoader());
    }

    public static renderWithDataQuery<P extends ElementBaseProps>(element : ReactElement<P, ComponentClass<P>>, request : RequestInfo, init? : RequestInit) {
        return RenderHelper.render(element, () => RenderHelper.dataQuery(request, init));
    }
    
    public static renderWithPropsQuery<P extends ElementBaseProps>(element : ReactElement<P, ComponentClass<P>>, request : RequestInfo, init? : RequestInit) {
        return RenderHelper.render(element, () => RenderHelper.propsQuery(request, init));
    }
    
    public static findParentDomElement<P extends FeatureBaseProps>(element : ReactElement<P, ComponentClass<P>>, findContainerDomNode : (place : string) => Element | null) : Element | null {
        const props = element.props;
        if(props && props.features) {
            const feature = props.features.find((e : Feature) => { return e.key == Features.PLACE;}) || new Feature(Features.PLACE, "", FeatureType.Custom);
            return findContainerDomNode(feature.value);
        }
        return null;
    }

    public static createElement<P extends FeatureBaseProps>(element : ReactElement<P, ComponentClass<any>>, externalParams : {} | (Promise<{} | undefined | null>) | Function) : React.ComponentElement<any, React.Component<any, any, any>> | null {
        const isComponent: boolean =  typeof element.type != "undefined" && typeof element.type !== 'string' && React.Component.prototype.isPrototypeOf((element.type as any).prototype);
        const result: boolean = isComponent ? (element.type as any).prototype instanceof ElementBase : false; 
        if(result === true) {
            const props =  element.props;
            let extra = {};
            if(externalParams instanceof Promise) {
                Promise.resolve(externalParams.then(ep => {
                    if(ep) { extra = ep; }
                }));
            } else if (externalParams instanceof Function) {
                extra = externalParams();
            } else {
                extra = externalParams;
            }
            if (extra) {
                return React.createElement(element.type, { ...extra, ...props });
            }
        }
        return null;
    }

    public static dataQuery(request : RequestInfo, init? : RequestInit) : {} {
        return {
            data : fetch(request, init).then(response => {
                if (response.ok) {
                    return { data: response.json() };
                }
                else {
                    RenderHelper.logger.warn("Request returned " + response.statusText + ";" + response.url);
                    return { data : { } };
                }
            })
        }
    }
    
    public static async propsQuery(request : RequestInfo, init? : RequestInit) : Promise< {}  | undefined | null> {
        const response = await fetch(request, init);
        if (response.ok) {
            return response.json();
        }
        else {
            RenderHelper.logger.warn("Request returned " + response.statusText + ";" + response.url);
            return { };
        }
    }
}