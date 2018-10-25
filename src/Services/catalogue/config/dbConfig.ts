import {  DBConfiguration} from "eDukaanFramework"; 

import * as path from "path";

const modalDir = path.join(path.resolve(__dirname, '../domain'));

const env = process.env.NODE_ENV || "development";
const config = require(__dirname + "/config.js")[env];
export const dbConfig: DBConfiguration = {
    Host: config.host,
    DBName: config.database,
    Username: config.username,
    Password: config.password,
    Dialect: config.dialect,
    ModalPath: modalDir,
};