import * as bodyParser from "body-parser";
import * as express from "express";
import * as path from "path";
import * as serveStatic from "serve-static";
import { ProductController } from './product.controller';
import { AutoMapperBootStrapper } from "../../autoMapperBootStrapper";
import { ICommandBus, InMemoryCommandBus } from "eDukaanFramework";
import { dbConfig } from '../../config/dbConfig'

import { InMemoryBusConfig } from "./inMemoryBusConfig";
import { Sequelize } from "edukaanframework/node_modules/sequelize-typescript";

class API {
    public api: express.Express;


    constructor() {
        this.api = express();
        InMemoryBusConfig.initialize();
        this.configureMiddlwares();
        this.syncDatabase();
        this.mountRoutes();
        let tempMapper = new AutoMapperBootStrapper();
        tempMapper.bootstrap();
    }

    private mountRoutes(): void {
        const router = express.Router();
        let productController = new ProductController();
        productController.addRoutes(this.api);

        // need to check if request status is not 404 or oath does not start with api then 
        this.api.use('/', router);
    }

    private syncDatabase() {
        const modalDir = dbConfig.ModalPath;

        let sequelize = new Sequelize({
            dialect: dbConfig.Dialect,
            host: dbConfig.Host,
            database: dbConfig.DBName,
            username: dbConfig.Username,
            password: dbConfig.Password,
            modelPaths: [modalDir]
        });

        sequelize.authenticate().then((err) => {
            sequelize.sync();
            console.log('Connection successful', err);
        }).catch((err) => {
            console.log('Unable to connect to database', err);
        });

    }

    private configureMiddlwares(): void {

        // this.api.use(cors());
        this.api.use(bodyParser.urlencoded({
            extended: true
        }));

        this.api.use(bodyParser.json());

        this.api.use(function (err: any, req: any, res: any, next: any) {
            console.error(err.stack)
        });
    }
}

export default new API().api