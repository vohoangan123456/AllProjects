import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { WordComponent } from './components/word/word.component';
import { LearnComponent } from './components/learn/learn.component';
import { CategoryComponent } from './components/category/category.component';

const routes: Routes = [
  { path: '', component: HomeComponent, data: { title: 'Home' } },
  { path: 'addword', component: WordComponent, data: { title: 'Words' } },
  { path: 'learn', component: LearnComponent, data: { title: 'Learn' } },
  { path: 'addcategory', component: CategoryComponent, data: { title: 'Categories' } }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
