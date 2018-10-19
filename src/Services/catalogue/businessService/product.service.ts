import * as express from "express";
import { ProductRepository } from '../persistence/product.repository';
import { Product } from "../domain/Product";
import { logger } from '../infrastructure/logger';
import { InMemoryBusConfig } from "../adapter/rest/inMemoryBusConfig";
import { CreateProductCommand } from "../commands/productCommands";

export class ProductService {

    private productRepository: ProductRepository;
    constructor() {
        this.productRepository = new ProductRepository();
    }

    async createProduct(productData: Product): Promise<Product> {
        let promise = new Promise<Product>((resolve: Function, reject: Function) => {
            try {
                var newProudctCommand = new CreateProductCommand();
                newProudctCommand.Name = productData.Name;
                InMemoryBusConfig.getCommandBus().Send(newProudctCommand);
                resolve(productData);
            } catch (error) {
                logger.error(error.message);
                reject(error);
            }
        });
        return promise;
    }

    // async updateProduct(productData: Product): Promise<Boolean> {
    //     let promise = new Promise<Boolean>((resolve: Function, reject: Function) => {
    //         return this.productRepository.Update(productData.id, productData).then((updated: Boolean) => {
    //             resolve(updated);
    //         }).catch((error: Error) => {
    //             logger.error(error.message);
    //             reject(error);
    //         });
    //     });
    //     return promise;
    // }

    async getProduct(productId: number): Promise<Product> {
        let promise = new Promise<Product>((resolve: Function, reject: Function) => {
            return this.productRepository.GetById(productId)
                .then((bookInstance: Product) => {
                    resolve(bookInstance);
                }).catch((error: Error) => {
                    logger.error(error.message);
                    reject(error);
                });
        });
        return promise;
    }

    async getAllProducts(): Promise<Product[]> {
        let promise = new Promise<Product[]>((resolve: Function, reject: Function) => {
            return this.productRepository.ListAllProducts()
                .then((books: Product[]) => {
                    resolve(books);
                }).catch((error: Error) => {
                    logger.error(error.message);
                    reject(error);
                });
        });
        return promise;
    }

    async deleteProduct(productId: number): Promise<Boolean> {
        let promise = new Promise<Boolean>((resolve: Function, reject: Function) => {
            return this.productRepository.Delete(productId).then((updated: Boolean) => {
                resolve(updated);
            }).catch((error: Error) => {
                logger.error(error.message);
                reject(error);
            });
        });
        return promise;
    }
}