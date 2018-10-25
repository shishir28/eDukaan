import { DataTypeAbstract, DefineAttributeColumnOptions } from "sequelize";

export type SequelizeAttributes<T extends { [key: string]: any }> = {
    [P in keyof T]: number|tring | DataTypeAbstract | DefineAttributeColumnOptions
};