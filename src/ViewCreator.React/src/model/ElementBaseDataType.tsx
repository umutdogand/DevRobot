import ElementBase from "../base/ElementBase";

/**
 * Model verisinden gelen datanın türü
 * Eğer fonksiyon ise, veri bu fonksiyon ile sağlanır
 */
export type ElementBaseDataType = null | { [x: string]: any; } | Function;