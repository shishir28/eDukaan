import { DBConfiguration, DBContext } from 'eDukaanFramework';

export class CatalogueDBContext extends DBContext {
  constructor(configuration: DBConfiguration) {
    super(configuration);
  }
}
