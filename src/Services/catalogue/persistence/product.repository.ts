import * as express from "express";
import * as expressServeStaticCore from "express-serve-static-core"
import { Product } from '../domain/Product';
import { BaseRepository } from '../../../BuildingBlocks/nodejs/persistence/BaseRepository';
// import { serviceDBContext } from './serviceDBContext';
import { logger } from "../infrastructure/logger"; 
import { DBContext } from "../../../BuildingBlocks/nodejs/persistence/dbContext";
import { dbConfig } from "../configs/dbConfig";

export class ProductRepository extends BaseRepository<Product>{
    constructor() {
        super(Product,new DBContext(dbConfig),logger);
    }

    async ListAllProducts(): Promise<Product[]> {
        return await Product.findAll({
            attributes: ['id'],
            
        })
            .then((data: any) => {
                return data.map(y => y.dataValues)
            });
    }
    
}