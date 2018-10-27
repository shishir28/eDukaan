
import {  ICommandBus, InMemoryCommandBus} from "eDukaanFramework"; 
import { CategorySaga } from "../../sagas/categorySaga";

export class InMemoryBusConfig {

    private static commandBus: ICommandBus ;

    public static initialize() {
        let cmdBus = new InMemoryCommandBus();
        let categorySaga = new CategorySaga(cmdBus);        
        cmdBus.RegisterSaga("CreateCategoryCommand",categorySaga);
        InMemoryBusConfig.commandBus = cmdBus;
    }
    
    public static getCommandBus():ICommandBus {
        return InMemoryBusConfig.commandBus;
    }
}