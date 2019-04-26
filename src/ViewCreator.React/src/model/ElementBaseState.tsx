import { ElementBaseDataType } from "./ElementBaseDataType";

export type ElementBaseState = {

    /**
     * Element içerisinde saklanan veri, modeldeki property değeri
     */
    data? : ElementBaseDataType | null | undefined;
}