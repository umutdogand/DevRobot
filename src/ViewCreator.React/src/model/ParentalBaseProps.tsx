import { Attributes } from "react";
import ElementBase from "../base/ElementBase";

export type ParentalBaseProps = Attributes & {

    addToParent? : undefined | ((element : ElementBase<any>) => void);
};