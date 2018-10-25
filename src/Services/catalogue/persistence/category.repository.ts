import { BaseRepository } from 'eDukaanFramework';

import { dbConfig } from '../config/dbConfig';
import { Category } from '../domain/Category';
import { CatalogueDBContext, logger } from '../infrastructure';

export class CategoryRepository extends BaseRepository<Category>{
    constructor() {
        super(Category, new CatalogueDBContext(dbConfig), logger);
    }

    async ListAllCategories(): Promise<Category[]> {
        return await Category.all()
            .then((data: any) => {
                return data.map((y: any) => y.dataValues)
            });
    }
}