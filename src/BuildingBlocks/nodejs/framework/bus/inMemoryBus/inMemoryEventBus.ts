
import { ICommandBus } from '../abstratctions/iBus';
import { Factory } from '../abstratctions/factory';

import { Saga } from '../abstratctions/saga';
import { IntegrationEvent, Message, IStartWithMessage, Command } from '../../infrastructure';

export class InMemoryCommandBus implements ICommandBus {
    private static currentSagaIndex = 0;
    private static _registeredSagas: Map<string,Saga>[] = [];

    constructor() {
    }

    public Send<T extends Command>(command: T): void {        

        let startMessageName :string = command.constructor.name;        
        let currentSaga = InMemoryCommandBus._registeredSagas.filter(x=> x.has(startMessageName))[0].get(startMessageName);
        this.LaunchSagasThatStartWithMessage(currentSaga,command);        
    }


    private LaunchSagasThatStartWithMessage( currentSaga:Saga, message:Message):void {
        currentSaga.Handle(message);
    }


    public RaiseEvent<T extends Event>(theEvent: T): void {

    }

    public RegisterSaga<T extends Saga>(startWithMessage: string, saga: T): void {
       let currentSagaMap  = new Map<string, Saga>();
       currentSagaMap.set(startWithMessage,saga);
        InMemoryCommandBus._registeredSagas.push(currentSagaMap);
    }

    public RegisterHandler<T>(): void {

    }

}

