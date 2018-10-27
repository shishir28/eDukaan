
import {  Command, IntegrationEvent} from "eDukaanFramework"; 
import { Category } from "../domain/Category";

export class CreateCategoryCommand extends Command{
    constructor(){
        super();
        this.Name = 'CreateCategoryCommand';
    }
    public Data:Category;
} 

export class EditCategoryCommand extends Command{
    constructor(){
        super();
        this.Name = 'EditCategoryCommand';
    }
} 

export class DeleteCategoryCommand extends Command{
    constructor(){
        super();
        this.Name = 'DeleteCategoryCommand';
    }
} 

export class CategoryCreatedEvent extends IntegrationEvent {
    constructor(){
        super();
        this.Name = 'CategoryCreated';
    }
}

export class CategoryUpdatedEvent extends IntegrationEvent {
    constructor(){
        super();
        this.Name = 'CategoryUpdated';
    }
}

export class CategoryDeletedEvent extends IntegrationEvent {
    constructor(){
        super();
        this.Name = 'CategoryDeleted';
    }
}