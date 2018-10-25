import { BaseRepository } from 'eDukaanFramework';

import { dbConfig } from '../config/dbConfig';
import { Product } from '../domain/Product';
import { CatalogueDBContext, logger } from '../infrastructure';

export class ProductRepository extends BaseRepository<Product>{
    constructor() {
        super(Product, new CatalogueDBContext(dbConfig), logger);
    }

    async ListAllProducts(): Promise<Product[]> {
        return await Product.findAll({
            attributes: ['id'],
        })
            .then((data: any) => {
                return data.map((y: any) => y.dataValues)
            });
    }
}