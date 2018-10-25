
import {  LoggingConfig} from "eDukaanFramework"; 

export const loggingConfig: LoggingConfig = {
    file: {
        level: "info",
        filename: "catalogueService.log",
        handleExceptions: true,
        json: true,
        maxsize: 5242880,
        maxFiles: 100,
        colorize: false
    },
    console: {
        level: "info",
        handleExceptions: true,
        json: false,
        colorize: true
    },
    directory: __dirname
};