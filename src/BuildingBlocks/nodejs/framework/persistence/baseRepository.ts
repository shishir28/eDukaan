
import { DBContext } from './dbContext';
import { IBaseRepository } from './iBaseRepository';
import { Logger } from "winston";

export abstract class BaseRepository<T> implements IBaseRepository<T>{
    private _model: any;
    private connection: any;
    private _dbContext: DBContext;
    private _logger: Logger;

    constructor(model: any, dbContext: DBContext, logger: Logger) {
        this._dbContext = dbContext;
        this._model = model;
        this._logger = logger;
    }

    async GetById(identifier: number): Promise<T> {
        return this._model.findOne({ where: { id: identifier } })
            .then((entity: any) => {
                if (entity) {
                    this._logger.info(`Retrieved entity with Id ${identifier}.`);
                    return entity.dataValues;
                } else {
                    this._logger.info(`Retrieved entity with Id ${identifier} does not exist.`);
                    return entity;
                }
            });
    }

    async ListAll(): Promise<T[]> {
        return this._model.findAll()
            .then((entities: Array<any>) => {
                this._logger.info("Retrieved all Entitites.");
                return entities.map(y => y.dataValues);
            });
    }

    async Insert(model: T): Promise<T> {
        return this._model.create(model.dataValues).then((entity: any) => {
            this._logger.info(`Created entity with id ${entity.dataValues.id}.`);
            return entity.dataValues;
        });
    }

    async Delete(identifier: number): Promise<Boolean> {
        return this._model.destroy({ where: { id: identifier } }).then((afffectedRows: number) => {
            if (afffectedRows > 0) {
                this._logger.info(`Deleted Model with Id ${identifier}`);
                return true;
            } else {
                this._logger.info(`Model with Id ${name} does not exist.`);
            }
            return false;
        });
    }

    async Update(identifier: number, model: T): Promise<Boolean> {
        return this._model.update(model.dataValues, { where: { id: identifier } })
            .then((results: [number, Array[T]]) => {
                if (results.length > 0) {
                    this._logger.info(`Updated model with id ${identifier}.`);
                } else {
                    this._logger.info(`Updated model with id ${identifier} does not exist.`);
                }
                return (results.length > 0);
            });
    }
}