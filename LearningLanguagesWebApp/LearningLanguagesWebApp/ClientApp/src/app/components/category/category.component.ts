import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Category } from '../../models/Category';
import { CategoryService } from '../../services/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  constructor(private categoryService: CategoryService) { }
  ngOnInit() {
    this.getCategories();
  }

  public getCategories() {
    this.categoryService.getCategoriesByFilter().subscribe((data: Array<object>) => {
      console.log(data);
    });
  }

  public addNewCategory() {
    this.categoryService.addNewCategory(this.model).subscribe((response) => {
      console.log(response);
    });
  }

  model = new Category();
  onSubmit(f: NgForm) {
    this.addNewCategory();
  }

  get diagnostic() { return JSON.stringify(this.model); }

}
