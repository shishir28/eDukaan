

module.exports = {
  development: {
    username: process.env.CATALOGUE_SERVICE__DBUSER ||"sa",
    password: process.env.CATALOGUE_SERVICE__DBPASSWORD ||"test123#",
    database: process.env.CATALOGUE_SERVICE__DBNAME ||"Monad_EDukan_Service_Catalogue",
    host: process.env.CATALOGUE_SERVICE__DBNAME ||"LT-5CG6414XQD",
    dialect: "mssql"
  },
  test: {
    username: process.env.CATALOGUE_SERVICE__DBUSER ,
    password: process.env.CATALOGUE_SERVICE__DBPASSWORD ,
    database: process.env.CATALOGUE_SERVICE__DBNAME ,
    host: process.env.CATALOGUE_SERVICE__DBNAME ,
    dialect: 'mysql'
  },
  production: {
    username: process.env.CATALOGUE_SERVICE__DBUSER ,
    password: process.env.CATALOGUE_SERVICE__DBPASSWORD ,
    database: process.env.CATALOGUE_SERVICE__DBNAME ,
    host: process.env.CATALOGUE_SERVICE__DBNAME ,
    dialect: 'mysql'
  }
}
