
import { IEventBus } from '../abstratctions/iBus';

import { Saga } from '../abstratctions/saga';
import { IntegrationEvent, Message, IStartWithMessage, Command } from '../../infrastructure';

// export class InMemoryEventBus implements IEventBus {
//     private static currentSagaIndex = 0;
//     private static _registeredSagas: Map<string, Saga>[] = [];

//     constructor() {
//     }

//     public Publish<T extends IntegrationEvent>(evt: T): void {
//         // to do 

//     }
// }