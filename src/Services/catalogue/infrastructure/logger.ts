import * as cluster from 'cluster';
// import * as mkdirp from 'mkdirp';
import * as path from 'path';
import { loggingConfig } from '../config/loggingConfig';
import * as winston from "winston";

loggingConfig.file.filename = `${path.join(loggingConfig.directory, "../logs")}/${loggingConfig.file.filename}`;

if (cluster.isMaster) {
    // mkdirp.sync(path.join(loggingConfig.directory, "../logs"));
}

export const logger = winston.createLogger({
    transports: [
        new winston.transports.File(loggingConfig.file),
        new winston.transports.Console(loggingConfig.console)
    ],
    exitOnError: false
});