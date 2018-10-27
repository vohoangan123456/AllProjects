import { NgForm } from '@angular/forms';
import { Category } from '../../models/Category';
import { CategoryService } from '../../services/category.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { AgGridNg2 } from 'ag-grid-angular';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  @ViewChild('agGrid') agGrid: AgGridNg2;
  selectedRow = [];
  closeResult: string;
  columnDefs = [];
  categoryList = [];
  model = new Category();
  labelsLocale = {
    popupTitle: 'Label.Category.editCategory',
    name: 'Label.Category.name',
    saveChange: 'Action.saveChange',
    create: 'Action.create',
    edit: 'Action.edit',
    delete: 'Action.delete',
    ok: 'Action.ok',
    confirmTitle: 'Label.Common.confirmTitle',
    confirmDelete: 'Message.Common.confirmDelete',
    cancel: 'Action.cancel'
  };
  constructor(private categoryService: CategoryService, private modalService: NgbModal) { }
  ngOnInit() {
    this.getCategories();
    this.buildGridSetting();
  }

  public buildGridSetting() {
    this.columnDefs = [
      {
        headerName: '',
        field: '',
        headerCheckboxSelection: true,
        headerCheckboxSelectionFilteredOnly: true,
        checkboxSelection: true,
        width: 5
      },
      { headerName: 'Name', field: 'name', width: 80 }
    ];
  }

  public onGridReady(params) {
    params.api.sizeColumnsToFit();
  }

  public dbClickOnRow(event) {
    alert('heelo');
  }

  public onSelectionChanged(event) {
    this.selectedRow = event.api.getSelectedRows();
  }

  public getCategories() {
    this.categoryService.getCategoriesByFilter().subscribe((data: Array<object>) => {
      this.categoryList = data;
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }

  get diagnostic() { return JSON.stringify(this.model); }

  public categorySaveChange() {

  }

  public addNewCategory(content) {
    this.labelsLocale.popupTitle = 'Label.Category.createCategory';
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.categoryService.addNewCategory(this.model).subscribe((response) => {
        this.modalService.dismissAll();
        this.getCategories();
        this.model = new Category();
      });
    }, (reason) => {
      //dismiss action
    });
  }

  public editCategory(content) {
    this.labelsLocale.popupTitle = 'Label.Category.editCategory';
    this.categoryService.getCategoryById(this.selectedRow[0].id).subscribe((response) => {
      Object.assign(this.model, response);
    });
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.categoryService.updateCategory(this.model).subscribe((response) => {
        this.modalService.dismissAll();
        this.getCategories();
        this.model = new Category();
      });
    }, (reason) => {
      //dismiss action
    });
  }

  public removeCategory() {
    var deleteIds = [];
    this.selectedRow.forEach(function (value) {
      deleteIds.push(value.id);
    });
    this.categoryService.deleteMultipleCategories(deleteIds).subscribe((response) => {
      this.modalService.dismissAll();
      this.getCategories();
      this.model = new Category();
      this.selectedRow = [];
    });
  }

  public askForRemoveCategory(confirmDelete) {
    this.modalService.open(confirmDelete, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.removeCategory();
    }, (reason) => {
      //dismiss action
    });
  }
}
