import * as Sequelize from 'sequelize';
import { dbConfig } from '../config/dbConfig';

//Shishir need to find better way to create database 
export default () => {
  const sequelize = new Sequelize({
    dialect: dbConfig.Dialect,
    host: dbConfig.Host,
    username: dbConfig.Username,
    password: dbConfig.Password
  });

  const createDBQuery = "IF  NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'" + dbConfig.DBName + "')     BEGIN      CREATE DATABASE [" + dbConfig.DBName + "]    END; "

  return sequelize.query(createDBQuery).then(data => {
    console.log(dbConfig.DBName + ' Created successfully!');
  
  }).error(reason => {
    console.log(reason);
  })
};