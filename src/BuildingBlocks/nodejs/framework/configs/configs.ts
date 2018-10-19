import { LoggingConfig } from "./loggingConfig";

export class Configs {

    private _loggingConfig: LoggingConfig;

    constructor(loggingConfig:LoggingConfig) {
        this._loggingConfig = loggingConfig;
    }

    getLoggingConfig(): LoggingConfig {
        return this._loggingConfig;
    }
}