import { Sequelize } from 'sequelize-typescript';
import * as Tedious from "tedious";
import * as path from "path";
import { DBConfiguration } from "../configs/dbConfiguration";

export class DBContext {

    public dbConfig: Sequelize;

    constructor(configuration: DBConfiguration) {
        const modalDir = configuration.ModalPath ;
        
        this.dbConfig = new Sequelize({
            dialect: configuration.Dialect,
            host: configuration.Host,
            database: configuration.DBName,
            username: configuration.Username,
            password: configuration.Password,
            modelPaths: [modalDir]
        });
        
        this.dbConfig.authenticate().then((err) => {
            console.log('Connection successful', err);
        }).catch((err) => {
            console.log('Unable to connect to database', err);
        });
    }
}