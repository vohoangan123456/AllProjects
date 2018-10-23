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

  getCategoriesByFilter() {
    return this.httpClient.get(`${this.API_URL}/api/categories`);
  }
}
