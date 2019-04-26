import Palette from "./Palette";

/**
 * Deafult olarak saklanan palettir.
 * Eğer bir palet yoksa geçerli olan palatte nesnesi
 * EmptyPalette dir.
 */
export default class EmptyPalette extends Palette {
    
    constructor() {
        super("empty", Object);
    }

    /**
     * Herhangi bir işlem yapmaz
     * @param dom DOM nesnesi
     */
    public onApply(dom : Element) { }
}