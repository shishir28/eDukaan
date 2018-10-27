import { Saga, IStartWithMessage, ICommandBus } from "eDukaanFramework";

import { CreateCategoryCommand, EditCategoryCommand, DeleteCategoryCommand } from "../commands/categoryCommands";
import { CategoryRepository } from "../persistence/category.repository";
import { Category } from "../domain/Category";

export class CategorySaga extends Saga {

    private categoryRepository: CategoryRepository;

    constructor(commandBus: ICommandBus) {
        super(commandBus);
        this.categoryRepository = new CategoryRepository();
    }

    public Handle(message: CreateCategoryCommand | EditCategoryCommand | DeleteCategoryCommand): void {
        if (message instanceof CreateCategoryCommand) {
            this.HandleCreateCommand(message);
        } else if (message instanceof EditCategoryCommand) {
            this.HandleEditCommand(message);
        } else if (message instanceof DeleteCategoryCommand) {
            this.HandleDeleteCommand(message);
        } else {
            throw 'Invalid Command';
        }
    }

    private HandleCreateCommand(message: CreateCategoryCommand): void {
        // let categoryData: Category = new Category();
        let categoryData = message.Data;
        
        console.log(categoryData);
        this.categoryRepository.Insert(categoryData).then((categoryInstance: Category) => {
            console.log('Raise event for Category created!')
            // raise event for created 
        }).catch((error: Error) => {
            console.log(error);
            //  logger.error(error.message);
            // reject(error);
        })
    }

    private HandleEditCommand(message: EditCategoryCommand): void {
        console.log(message);
    }

    private HandleDeleteCommand(message: DeleteCategoryCommand): void {
        console.log(message);
    }
}