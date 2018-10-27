import * as express from "express";
import { CategoryRepository } from '../persistence/category.repository';
import { Category } from "../domain/Category";
import { logger } from '../infrastructure/logger';
import { InMemoryBusConfig } from "../adapter/rest/inMemoryBusConfig";
import { CreateCategoryCommand } from "../commands/categoryCommands";

export class CategoryService {

    private categoryRepository: CategoryRepository;
    constructor() {
        this.categoryRepository = new CategoryRepository();
    }

    async createCategory(categoryData: Category): Promise<Category> {
        let promise = new Promise<Category>((resolve: Function, reject: Function) => {
            try {
                var newProudctCommand = new CreateCategoryCommand();
                newProudctCommand.Data = categoryData;
                InMemoryBusConfig.getCommandBus().Send(newProudctCommand);
                resolve(categoryData);
            } catch (error) {
                logger.error(error.message);
                reject(error);
            }
        });
        return promise;
    }

    // async updateCategory(categoryData: Category): Promise<Boolean> {
    //     let promise = new Promise<Boolean>((resolve: Function, reject: Function) => {
    //         return this.categoryRepository.Update(categoryData.id, categoryData).then((updated: Boolean) => {
    //             resolve(updated);
    //         }).catch((error: Error) => {
    //             logger.error(error.message);
    //             reject(error);
    //         });
    //     });
    //     return promise;
    // }

    async getCategory(categoryId: number): Promise<Category> {
        let promise = new Promise<Category>((resolve: Function, reject: Function) => {
            return this.categoryRepository.GetById(categoryId)
                .then((bookInstance: Category) => {
                    resolve(bookInstance);
                }).catch((error: Error) => {
                    logger.error(error.message);
                    reject(error);
                });
        });
        return promise;
    }

    async getAllCategories(): Promise<Category[]> {
        let promise = new Promise<Category[]>((resolve: Function, reject: Function) => {
            return this.categoryRepository.ListAllCategories()
                .then((categories: Category[]) => {
                    resolve(categories);
                }).catch((error: Error) => {
                    logger.error(error.message);
                    reject(error);
                });
        });
        return promise;
    }

    async deleteCategory(categoryId: number): Promise<Boolean> {
        let promise = new Promise<Boolean>((resolve: Function, reject: Function) => {
            return this.categoryRepository.Delete(categoryId).then((updated: Boolean) => {
                resolve(updated);
            }).catch((error: Error) => {
                logger.error(error.message);
                reject(error);
            });
        });
        return promise;
    }
}