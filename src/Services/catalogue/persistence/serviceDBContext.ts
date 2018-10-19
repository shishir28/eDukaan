
import {  DBContext} from "eDukaanFramework"; 

import { dbConfig } from "../configs/dbConfig";

export const serviceDBContext = new DBContext(dbConfig);