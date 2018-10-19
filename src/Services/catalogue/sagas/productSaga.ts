import { Saga, IStartWithMessage, ICommandBus } from "eDukaanFramework";

import { CreateProductCommand, EditProductCommand, DeleteProductCommand } from "../commands/productCommands";
import { ProductRepository } from "../persistence/product.repository";
import { Product } from "../domain/Product";

export class ProductSaga extends Saga {

    private productRepository: ProductRepository;

    constructor(commandBus: ICommandBus) {
        super(commandBus);
        this.productRepository = new ProductRepository();
    }

    public Handle(message: CreateProductCommand | EditProductCommand | DeleteProductCommand): void {
        if (message instanceof CreateProductCommand) {
            this.HandleCreateCommand(message);
        } else if (message instanceof EditProductCommand) {
            this.HandleEditCommand(message);
        } else if (message instanceof DeleteProductCommand) {
            this.HandleDeleteCommand(message);
        } else {
            throw 'Invalid Command';
        }
    }

    private HandleCreateCommand(message: CreateProductCommand): void {
        let productData: Product = new Product();
        productData.Name = message.Name;
        this.productRepository.Insert(productData).then((productInstance: Product) => {
            // raise event for created 
        }).catch((error: Error) => {
            // logger.error(error.message);
            // reject(error);
        })
    }

    private HandleEditCommand(message: EditProductCommand): void {
        console.log(message);
    }

    private HandleDeleteCommand(message: DeleteProductCommand): void {
        console.log(message);
    }
}