import app from './app'
import dbCreator from './infrastructure/dbCreator';
import { createServer } from "http";
const port = process.env.CATALOGUE_SERVICE_PORT || 9002;

(async () => {
  dbCreator();
  createServer(app).listen(port, (err: any) => {
    console.info(`Server is listening on port ${port}`);
  });
})();
