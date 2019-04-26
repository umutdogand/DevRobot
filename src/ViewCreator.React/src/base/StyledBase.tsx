import EmptyPalette from "../styled/EmptyPalette";
import Palette from "../styled/Palette";
import FeatureBase from "./FeatureBase";
import Features from "../model/Features";
import ViewCreatorApp from "../ViewCreatorApp";
import Helper from "../Helper";
import { FeatureBaseProps } from "../model/FeatureBaseProps";

export default abstract class StyledBase<P extends FeatureBaseProps = FeatureBaseProps> extends FeatureBase<P> {
    
    private static _defaultPalette : Palette = new EmptyPalette();
    
    public findPalettes() : Palette[] {
        const paletteFeature = this.getFeature(Features.PALETTENAME);
        if(paletteFeature) {
            const palette = ViewCreatorApp.instance.paletteSet.findByName(...Helper.parseStringArray(paletteFeature));
            if(palette) { return palette; }
        } else {
            return ViewCreatorApp.instance.paletteSet.findByType(this.constructor);
        }
        return [StyledBase._defaultPalette];
    }

    /**
     * Component nesnesini oluşturur
     * @param props Properties
     */
    public constructor(props: P) {
        super(props);
    }

    public componentDidMount() {
        super.componentDidMount();
        const palettes = this.findPalettes();
        for(let i = 0; i < palettes.length; i++) {
            palettes[i].apply();
        }
    }

    public componentDidUpdate() {
        super.componentDidUpdate();
        const palettes = this.findPalettes();
        for(let i = 0; i < palettes.length; i++) {
            palettes[i].apply();
        }
    }

    public render() {
        const _render = super.render();
        const palettes = this.findPalettes();
        for(let i = 0; i < palettes.length; i++) {
            palettes[i].prepare(_render);
        }
        return _render;
    }
}