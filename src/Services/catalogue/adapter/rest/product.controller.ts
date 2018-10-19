import * as express from "express";
import * as expressServeStaticCore from "express-serve-static-core"
import { ProductService } from '../../businessService/product.service';
import { Product } from '../../domain/Product';
import { ProductViewModel } from "../viewModel/productViewModel";
import { logger } from "../../infrastructure/logger";
export class ProductController {

  private productService: ProductService;
  public addRoutes(api: express.Router) {
     api.post('/api/product', (request: express.Request, response: express.Response) => this.createProduct(request, response));
    // api.put('/api/product/:id', (request: express.Request, response: express.Response) => this.updateProduct(request, response));
    api.get('/api/product/:id', (request: express.Request, response: express.Response) => this.getProduct(request, response));
    api.get('/api/product', (request: express.Request, response: express.Response) => this.getAllProducts(request, response));
    // api.delete('/api/product/:id', (request: express.Request, response: express.Response) => this.deleteProduct(request, response));
  }

  constructor() {
    this.productService = new ProductService();
  }

  createProduct(request: express.Request, response: express.Response) {
    
    let productData = new Product();
    productData.Name = request.body.Name;    
    this.productService.createProduct(productData).then((productInstance: Product) => {
      let result = (automapper.map('Product', 'ProductViewModel', productInstance) as ProductViewModel);
      return response.status(201).send(result);
    }).catch((error: Error) => {
      return response.status(409).send(error);
    });
  }


  getProduct(request: express.Request, response: express.Response) {
    const productId = request.params["id"];
    this.productService.getProduct(productId).then((productInstance: Product) => {
      let result = (automapper.map('Product', 'ProductViewModel', productInstance) as ProductViewModel);
      return response.status(200).send(result);
    }).catch((error: Error) => {
      return response.status(500).send(error);
    });
  }

  getAllProducts(request: express.Request, response: express.Response) {
    this.productService.getAllProducts().then((products: Product[]) => {
      let result = (automapper.map('Product', 'ProductViewModel', products) as ProductViewModel[]);
      return response.status(200).send(result);
    }).catch((error: Error) => {
      return response.status(500).send(error);
    });
  }


}