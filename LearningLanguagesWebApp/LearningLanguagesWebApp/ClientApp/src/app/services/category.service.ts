import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Utilities } from './utilities';
import { Category } from '../models/Category';


@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private httpClient: HttpClient) { }
  API_URL = Utilities.baseUrl();

  addNewCategory(category: Category) {
    return this.httpClient.post(`${this.API_URL}/api/categories`, category );
  }
  updateCategory(category: Category) {
    return this.httpClient.put(`${this.API_URL}/api/categories/${category.id}`, category);
  }
  deleteCategory(id: number) {
    return this.httpClient.delete(`${this.API_URL}/api/categories/${id}`);
  }
  deleteMultipleCategories(ids: any) {
    return this.httpClient.post(`${this.API_URL}/api/categories/bulkdelete`, ids);
  }
  getCategoriesByFilter() {
    return this.httpClient.get(`${this.API_URL}/api/categories/getdata`);
  }
  getCategoryById(id: number) {
    return this.httpClient.get(`${this.API_URL}/api/categories/${id}`);
  }
}
