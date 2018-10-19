
import {  ICommandBus, InMemoryCommandBus} from "eDukaanFramework"; 
import { ProductSaga } from "../../sagas/productSaga";

export class InMemoryBusConfig {

    private static commandBus: ICommandBus ;

    public static initialize() {
        let cmdBus = new InMemoryCommandBus();
        let productSaga = new ProductSaga(cmdBus);        
        cmdBus.RegisterSaga("CreateProductCommand",productSaga);
        InMemoryBusConfig.commandBus = cmdBus;
    }
    
    public static getCommandBus():ICommandBus {
        return InMemoryBusConfig.commandBus;
    }
}