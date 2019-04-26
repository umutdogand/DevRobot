import { RefObject, ReactNode } from "react";
import ReactDOM from "react-dom";
import { Type } from "../model/Type"

/**
 * Palette, dom oluştutan sonra, tasarımsal işlemleri uygular.
 */
export default abstract class Palette {

    private _name : string;
    private _type : Type;

    private _ref: RefObject<any> | null;

    public get name() : string {
        return this._name;
    }

    public get type() : Type {
        return this._type;
    }

    public constructor(name : string, type : Type) {
        this._ref = null;
        this._name = name;
        this._type = type;
    }

    public prepare(element: ReactNode): ReactNode {
        const obj = element as any;
        if (obj && obj.ref) {
            this._ref = obj.ref as RefObject<any>;
        }
        return element;
    }

    public apply(): void {
        if (this._ref && this._ref.current) {
            const dom = ReactDOM.findDOMNode(this._ref.current);
            if (dom instanceof Element) {
                this.onApply(dom);
            }
        }
    }

    public abstract onApply(dom: Element): void;
}
