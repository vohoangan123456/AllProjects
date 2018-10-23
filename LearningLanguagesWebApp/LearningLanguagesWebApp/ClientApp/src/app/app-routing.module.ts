import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { AddnewwordComponent } from './components/addnewword/addnewword.component';
import { LearnComponent } from './components/learn/learn.component';
import { CategoryComponent } from './components/category/category.component';

const routes: Routes = [
  { path: '', component: HomeComponent, data: { title: 'Home' } },
  { path: 'addword', component: AddnewwordComponent, data: { title: 'Add newwords' } },
  { path: 'learn', component: LearnComponent, data: { title: 'Learn' } },
  { path: 'addcategory', component: CategoryComponent, data: { title: 'Add Category' } }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
