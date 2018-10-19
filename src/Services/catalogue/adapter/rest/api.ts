import * as bodyParser from "body-parser";
import * as express from "express";
import * as path from "path";
import * as serveStatic from "serve-static";
import { ProductController } from './product.controller';
import { AutoMapperBootStrapper } from "../../autoMapperBootStrapper";
import {  ICommandBus, InMemoryCommandBus} from "eDukaanFramework"; 

import { InMemoryBusConfig } from "./inMemoryBusConfig";

class API {
    public api: express.Express;


    constructor() {
        this.api = express();     
        InMemoryBusConfig.initialize();
        this.configureMiddlwares();
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

    private configureMiddlwares(): void {

        // this.api.use(cors());
        this.api.use(bodyParser.urlencoded({
            extended: true
        }));

        this.api.use(bodyParser.json());

        this.api.use(function (err:any, req:any, res:any, next:any) {
            console.error(err.stack)
        });
    }
}

export default new API().api