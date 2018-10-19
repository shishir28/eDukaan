import { IntegrationEvent, Message,IStartWithMessage, Command } from '../../infrastructure';
import { IIntegrationEventHandler } from "./iIntegrationEventHandler";
import { Saga} from "./saga";

export interface ICommandBus {
     Send<T extends Command>(command: T): void;    
     RegisterSaga<T extends Saga>(startWithMessage:string,saga:T): void;
     RegisterHandler<T>():void;
}

export interface IEventBus {
    Publish(event: IntegrationEvent): void;
    Subscribe<T extends IntegrationEvent, TH extends IIntegrationEventHandler<T>>(): void;
    Unsubscribe<T extends IntegrationEvent, TH extends IIntegrationEventHandler<T>>(): void;
}