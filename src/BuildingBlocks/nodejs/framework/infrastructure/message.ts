import { Guid } from "guid-typescript";

export class Message {
    public Name: string;
    constructor() {
        this.Name = '';
    }
}

export class Command extends Message {
    constructor() {
        super();
    }
}

export class IntegrationEvent extends Message {
    public id: Guid;
    public TimeStamp: Date;
    constructor() {
        super();
        this.TimeStamp = new Date();
        this.id = Guid.create()
    }
}

export interface IStartWithMessage <T extends Message> {
     Handle(message:T):void
}

export interface IHandleMessage <T > {
    Handle(message:T):void;
}