import FeatureBase from "./base/FeatureBase";
import Features from "./model/Features";
import { Type } from "./model/Type";
import ElementBase from "./base/ElementBase";
import { ElementBaseProps } from "./model/ElementBaseProps";
import { ElementBaseState } from "./model/ElementBaseState";
import ContainerBase from "./base/ContainerBase";
import { RefObject } from "react";

/**
 * Yardımcı methodların tanımlandığı sınıf
 */
export default class Helper {

    /**
     * Özel bir anahtar üretir.
     */
    public static generateUnique() : any {
        const uuidv1 = require('uuid/v1');
        return uuidv1();
    }
    
    /**
     * Çift boyutlu diziyi parse eder
     * @param value Text
     */
    public static parseStringArraysArray(value :string) : string[][] {
        const result : string[][] = [];
        if(value) {
            const array = this.parseStringArray(value);
            for(let i = 0; i < array.length; i++) {
                const subArray = this.parseStringArray(value[i]);
                if(subArray.length > 0) {
                    result.push(subArray);
                }
            }
        }
        return result;
    }

    /**
     * Texti diziye çevirir
     * @param value Text
     */
    public static parseStringArray(value :string) : string[] {
        const i = value.indexOf("[");
        const j = value.lastIndexOf("]");
        if(i > -1 && j <= i) { return []; }
        value = value.substring(i + 1, j - i).trim();
        return value.split(",");
    }

    /**
     * Tüm ağacı gezerek istenen tipdeki elemanları getirir
     * @param root En üsteki eleman
     * @param typeName Aranan type adı
     */
    public static findByType(root : ContainerBase<any> | null, type : Type) : ElementBase<any>[] {
        const result : ElementBase<any>[] = [];
        if(root && root.children && root.children.length > 0) {
            for(let i= 0; i < root.children.length; i++) {
                const child =  root.children[i];
                if(child.constructor == type) {
                    result.push(child);
                }
                if(child instanceof ContainerBase) {
                    const subResult = this.findByType(child, type);
                    result.push(...subResult);
                }
            }
        }
        return result;
    }

    /**
     * Tüm ağacı gezerek istenen property adına sahip elemanları getirir
     * @param root En üsteki eleman
     * @param propretyName Aranan property adı
     */
    public static findByProp(root : ContainerBase<any> | null, propretyName : string) : ElementBase<any>[] {
        const result : ElementBase<any>[] = [];
        if(root && root.children && root.children.length > 0) {
            for(let i= 0; i < root.children.length; i++) {
                const child =  root.children[i];
                if(child.propertyName === propretyName) {
                    result.push(child);
                }
                if(child instanceof ContainerBase) {
                    const subResult = this.findByProp(child, propretyName);
                    result.push(...subResult);
                }
            }
        }
        return result;
    }

    /**
     * Tüm ağacı gezerek istenen key değerine sahip elemanı getirir
     * @param root En üsteki eleman
     * @param key Aranan key
     */
    public static findByKey(root : ContainerBase<any> | null, key : string) : ElementBase<any> | null {
        if(root && root.children && root.children.length > 0) {
            for(let i= 0; i < root.children.length; i++) {
                /*const child =  root.children[i];
                if(child instanceof FeatureBase && child.getFeature(Features.KEY) === key) {
                    return child;
                } else if(child instanceof ContainerBase) {
                    return this.findByKey(child, key);
                }*/
            }
        }
        return null;
    }

    /**
     * Tüm componentleri gezer, uygun pathe sahip elemanları bularak dizi olarak döndürür
     * Başlangıç olarak root dan başlar
     * 
     * Template içerisinde uygun property yoluna uygun FeatureBase nesneleri döndürür.
     * { UserList : [ { UserName : "Zübeyir "}, { UserName : "Umut" } } ] } örneği için path 
     * "UserList.UserName" gönderilir ise UserName property üzerinde de Input olduğunu düşünür isek
     * Tüm username inputlar gelir
     * 
     * @param root En üsteki eleman
     * @param path Property yolu
     */
    public static findByPath(root : ContainerBase<any> | null, path : string) : ElementBase<any>[] {
        let result : ElementBase<any>[] = [];
        const pathArray = path.split(".");
        if(root && pathArray.length > 0) {
            let property = pathArray[0];
            // Eğer property name 1 tane ise ve kendisinin property name'i ile aynı ise
            // Alt çocuklarına inmez, kendini ekler
            if(root.propertyName && root.propertyName == property && pathArray.length == 1) {
                result.push(root);
            } 
            else if(pathArray.length > 1) {
                // Eğer component property adına sahip ise, istenen propertye eşitse 
                if(root.propertyName && root.propertyName == property) {
                    path = pathArray.slice(1, pathArray.length - 1).join(".");
                } else if(root.propertyName && root.propertyName != property) {
                    return result;
                }              
                root.children.forEach(child => {
                    if(child instanceof ContainerBase) {
                        const subResult = this.findByPath(child, path);
                        result.push(...subResult);
                    }
                });
            }
        }
        return result;
    }
}