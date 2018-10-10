import 'automapper-ts/dist/automapper';

export class AutoMapperBootStrapper {

    constructor() {
    }

    public bootstrap() {
        automapper.initialize((config: AutoMapperJs.IConfiguration) => {
            config.createMap('Product', 'ProductViewModel');
        });
    }
}