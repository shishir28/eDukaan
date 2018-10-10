import { DBConfiguration } from "../../../BuildingBlocks/nodejs/configs/dbConfiguration";
import * as path from "path";

const modalDir = path.join(path.resolve(__dirname, '../domain'));

export const dbConfig: DBConfiguration = {
    Host: process.env.CATALOGUE_SERVICE_DBSERVER || 'LT-5CG6414XQD',
    DBName: process.env.CATALOGUE_SERVICE__DBNAME || 'MyStore',
    Username: process.env.CATALOGUE_SERVICE__DBUSER || 'sa',
    Password: process.env.CATALOGUE_SERVICE__DBPASSWORD || 'test123#',
    ModalPath: modalDir,
};