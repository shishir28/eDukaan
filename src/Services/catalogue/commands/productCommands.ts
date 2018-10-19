
import {  Command, IntegrationEvent} from "eDukaanFramework"; 

export class CreateProductCommand extends Command{
    constructor(){
        super();
        this.Name = 'CreateProductCommand';
    }
} 

export class EditProductCommand extends Command{
    constructor(){
        super();
        this.Name = 'EditProductCommand';
    }
} 

export class DeleteProductCommand extends Command{
    constructor(){
        super();
        this.Name = 'DeleteProductCommand';
    }
} 


export class ProductCreatedEvent extends IntegrationEvent {
    constructor(){
        super();
        this.Name = 'ProductCreated';
    }
}

export class ProductUpdatedEvent extends IntegrationEvent {
    constructor(){
        super();
        this.Name = 'ProductUpdated';
    }
}

export class ProductDeletedEvent extends IntegrationEvent {
    constructor(){
        super();
        this.Name = 'ProductDeleted';
    }
}