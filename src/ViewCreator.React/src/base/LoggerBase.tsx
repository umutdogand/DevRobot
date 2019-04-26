import Logger from "../logging/Logger"
import ViewCreatorApp from "../ViewCreatorApp"
import React from "react";
import { ElementBaseState } from "../model/ElementBaseState";

export default abstract class LoggerBase<P = {}> extends React.Component<P, ElementBaseState, any> {

    private _logger : Logger;

    public get logger() : Logger {
        return this._logger;
    }

    public constructor(props : P) {
        super(props);
        this._logger = ViewCreatorApp.instance.createLogger(this.constructor.name);
    }
}