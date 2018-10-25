
import {  DBContext} from "eDukaanFramework"; 

import { dbConfig } from "../config/dbConfig";

export const serviceDBContext = new DBContext(dbConfig);