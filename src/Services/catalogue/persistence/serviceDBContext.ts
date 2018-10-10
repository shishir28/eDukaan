import { DBContext } from "../../../BuildingBlocks/nodejs/persistence/dbContext";
import { dbConfig } from "../configs/dbConfig";

export const serviceDBContext = new DBContext(dbConfig);