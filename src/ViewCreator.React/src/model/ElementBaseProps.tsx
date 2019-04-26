import TemplateBase from "../base/TemplateBase";
import { ElementBaseDataType } from "./ElementBaseDataType";
import ContainerBase from "../base/ContainerBase";
import { ReactNode } from "react";
import { ParentalBaseProps } from "./ParentalBaseProps";

export type ElementBaseProps = ParentalBaseProps & {

    /**
     * Property içindeki değişkeni değeri
     */
    data? : ElementBaseDataType | null | undefined;

    /**
     * Model property ismi
     */
    propertyName? : string | null | undefined;

    /**
     * Elemanın sahip olduğu anahtar
     */
    key? : string | null | undefined;

    /**
     * Componentin alt elemanları
     */
    children? : ReactNode,
    
    /**
     * Elemanın sahip olduğu parent saklar
     */
    parent? : ContainerBase<any> | null | undefined;

    /**
     * Template nesnesini saklar
     */
    template? : TemplateBase<any> | null | undefined;
};