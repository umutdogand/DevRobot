import Feature from "./Feature";
import { ElementBaseProps } from "./ElementBaseProps";

/**
 * FeatureBase için property tipi
 */
export type FeatureBaseProps = ElementBaseProps & {

    /**
     * Sahip olduğu özellikler
     */
    features? : Feature[] | null | undefined;
}