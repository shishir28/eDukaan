import { IntegrationEvent } from "../events/integrationEvent";
import { IIntegrationEventHandler } from "./iIntegrationEventHandler";

export interface IBus {
    Publish(event: IntegrationEvent): Promise<void>;
    Subscribe<T extends IntegrationEvent, TH extends IIntegrationEventHandler<T>>(): Promise<void>;
    Unsubscribe<T extends IntegrationEvent, TH extends IIntegrationEventHandler<T>>(): Promise<void>;
}