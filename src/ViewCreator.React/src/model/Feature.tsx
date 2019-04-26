import { FeatureType } from "./FeatureType"

export default class Feature {
    
    private _key: string;
    private _value: string;
    private _type: FeatureType;

    /**
     * Özelliğin anahtar değeri
     */
    public get key() : string {
        return this._key;
    }

    /**
     * Özelliğin değeri
     */
    public get value() : string {
        return this._value;
    }

    /**
     * Özelliğin tipi
     */
    public get type() : FeatureType {
        return this._type;
    }

    /**
     * Component render işlemleri için kullanılan her bir özelliği simgeler
     * @param name Anahtar değeri
     * @param value Değeri
     * @param type Tipi
     */
    public constructor(key : string , value : string, type : FeatureType = FeatureType.Custom) {
        this._key = key;
        this._value = value;
        this._type = type;
    }
}