import Palette from "./Palette";
import { Type } from "../model/Type";

export default class PaletteSet {

    private paletteList : Array<Palette>

    public constructor(palatteSet : PaletteSet | null = null)  {
        this.paletteList = palatteSet != null ? new Array<Palette>(...palatteSet.paletteList) : new Array<Palette>();
    }

    public add(palette : Palette) {
        this.paletteList.push(palette);
        return this;
    }

    public remove(palette : Palette) {
        const index = this.paletteList.indexOf(palette);
        if(index >= 0) {
            this.paletteList.splice(index, 1);
        }
        return this;
    }

    public findByName(...names : string[]) : Palette[] {
        const result = this.paletteList.filter(i => names.indexOf(i.name) > 0);
        return result;
    }

    public findByType(type : Type) : Palette[] {
        return this.paletteList.filter(i => i.type === type);
    }

    public find(filter : (palette : Palette) => Palette[]) {
        return this.paletteList.filter(filter);
    }

    public static create(action : (palatteSet :PaletteSet) => void, palatteSet : PaletteSet | null = null) {
        const paletteSet = new PaletteSet(palatteSet);
        if(action != null) {
            action(paletteSet);
        }
        return paletteSet;
    }
}