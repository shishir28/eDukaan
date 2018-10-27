import * as express from "express";
import * as expressServeStaticCore from "express-serve-static-core"
import { CategoryService } from '../../businessService/category.service';
import { Category } from '../../domain/Category';
import { CategoryViewModel } from "../viewModel/categoryViewModel";
import { logger } from "../../infrastructure/logger";
export class CategoryController {

  private categoryService: CategoryService;
  public addRoutes(api: express.Router) {
      api.post('/api/category', (request: express.Request, response: express.Response) => this.createCategory(request, response));
    // api.put('/api/category/:id', (request: express.Request, response: express.Response) => this.updateCategory(request, response));
    api.get('/api/category/:id', (request: express.Request, response: express.Response) => this.getCategory(request, response));
    api.get('/api/category', (request: express.Request, response: express.Response) => this.getAllCategories(request, response));
    // api.delete('/api/category/:id', (request: express.Request, response: express.Response) => this.deleteCategory(request, response));
  }

  constructor() {
    this.categoryService = new CategoryService();
  }

  createCategory(request: express.Request, response: express.Response) {
    let categoryData = request.body;    
    this.categoryService.createCategory(categoryData).then((categoryInstance: Category) => {
      let result = (automapper.map('Category', 'CategoryViewModel', categoryInstance) as CategoryViewModel);
      return response.status(201).send(result);
    }).catch((error: Error) => {
      return response.status(409).send(error);
    });
  }


  getCategory(request: express.Request, response: express.Response) {
    const categoryId = request.params["id"];
    this.categoryService.getCategory(categoryId).then((categoryInstance: Category) => {
      let result = (automapper.map('Category', 'CategoryViewModel', categoryInstance) as CategoryViewModel);
      return response.status(200).send(result);
    }).catch((error: Error) => {
      return response.status(500).send(error);
    });
  }

  getAllCategories(request: express.Request, response: express.Response) {
    this.categoryService.getAllCategories().then((categories: Category[]) => {
      let result = (automapper.map('Category', 'CategoryViewModel', categories) as CategoryViewModel[]);
      return response.status(200).send(result);
    }).catch((error: Error) => {
      return response.status(500).send(error);
    });
  }

}