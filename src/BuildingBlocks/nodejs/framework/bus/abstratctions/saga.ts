import { Command } from '../../infrastructure';
import { ICommandBus } from './iBus';


export  class Saga {
    public CommandBus: ICommandBus;
    constructor(commandBus: ICommandBus) {
        //check for null
        if(!commandBus){
            throw 'Command bus is null';
        }
        this.CommandBus = commandBus;
    }

    public Handle(message:Command): void {

    }
}
