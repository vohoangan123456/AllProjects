import { Component, OnInit } from '@angular/core';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import Cropper from 'cropperjs';

import { Word } from '../../models/word';
import { WordService } from '../../services/word.service';
import { CategoryService } from '../../services/category.service';
import { Utilities } from '../../services/utilities';

@Component({
  selector: 'app-word',
  templateUrl: './word.component.html',
  styleUrls: ['./word.component.css']
})
export class WordComponent implements OnInit {
  API_URL = Utilities.baseUrl();
  disableSubmitBtn = false;
  selectedRow = [];
  columnDefs = [];
  wordList = [];
  categories = [];
  model = new Word();
  cropper: any;
  labelsLocale = {
    popupTitle: 'Label.Word.createNewWord',
    word: 'Label.Word.newWord',
    category: 'Label.Common.category',
    type: 'Label.Word.type',
    pronunciation: 'Label.Word.pronunciation',
    meaning: 'Label.Word.meaning',
    example: 'Label.Word.example',
    translation: 'Label.Word.translation',
    note: 'Label.Word.note',
    uploadFile: 'Label.Word.uploadFile',
    submit: 'Action.submit',
    saveChange: 'Action.saveChange',
    create: 'Action.create',
    edit: 'Action.edit',
    delete: 'Action.delete',
    ok: 'Action.ok',
    confirmTitle: 'Label.Common.confirmTitle',
    confirmDelete: 'Message.Common.confirmDelete',
    cancel: 'Action.cancel'
  };

  constructor(private wordService: WordService, private categoryService: CategoryService, private modalService: NgbModal) { }
  ngOnInit() {
    this.getWords();
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
      { headerName: 'Word', field: 'word', width: 10 },
      { headerName: 'Type', field: 'type', width: 10 },
      { headerName: 'Pronunciation', field: 'pronunciation', width: 10 },
      { headerName: 'Meaning', field: 'meaning', width: 10 },
      { headerName: 'Example', field: 'example', width: 10 },
      { headerName: 'Translation', field: 'translation', width: 10 },
      { headerName: 'Note', field: 'note', width: 10 },
      { headerName: 'Category', field: 'CategoryName', width: 10 }
    ];
  }

  public onSelectFile(event) { // called each time file input changes
    if (event.target.files && event.target.files[0]) {
      var reader = new FileReader();
      reader.readAsDataURL(event.target.files[0]); // read file as data url

      reader.onload = (evt) => { // called once readAsDataURL is completed
        this.model.image = evt.target.result;
        this.createCropperJs();
      }
    }
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

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }

  public getCategories() {
    this.categoryService.getCategoriesByFilter().subscribe((data: Array<object>) => {
      this.categories = data;
    });
  }

  public getWords() {
    var self = this;
    this.wordService.getWordsByFilter().subscribe((data: Array<object>) => {
      this.wordList = data;
    });
  }

  public addNewWord(content) {
    var self = this;
    this.labelsLocale.popupTitle = 'Label.Word.createNewWord';
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title', size: 'lg' }).result.then((result) => {
      if (self.cropper != null)
        self.model.image = self.cropper.getCroppedCanvas().toDataURL('image/png');
      this.wordService.addNewWords(this.model).subscribe((response) => {
        this.modalService.dismissAll();
        this.getWords();
        this.model = new Word();
      });
    }, (reason) => {
      this.model = new Word();
    });
  }

  public editWord(content) {
    var self = this;
    this.labelsLocale.popupTitle = 'Label.Word.editNewWord';
    this.wordService.getWordById(this.selectedRow[0].id).subscribe((response) => {
      Object.assign(this.model, response);
      this.model.image = this.API_URL + this.model.image;
      this.createCropperJs();
    });
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title', size: 'lg' }).result.then((result) => {
      if (self.cropper != null)
        self.model.image = self.cropper.getCroppedCanvas().toDataURL('image/png');
      this.wordService.updateNewWord(this.model).subscribe((response) => {
        this.modalService.dismissAll();
        this.getWords();
        this.model = new Word();
      });
    }, (reason) => {
      this.model = new Word();
    });
  }

  public removeWords() {
    var deleteIds = [];
    this.selectedRow.forEach(function (value) {
      deleteIds.push(value.id);
    });
    this.wordService.deleteMultipleWord(deleteIds).subscribe((response) => {
      this.modalService.dismissAll();
      this.getWords();
      this.model = new Word();
      this.selectedRow = [];
    });
  }

  public askForRemoveWord(confirmDelete) {
    this.modalService.open(confirmDelete, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.removeWords();
    }, (reason) => {
      //dismiss action
    });
  }

  get diagnostic() { return JSON.stringify(this.model); }

  private createCropperJs() {
    var self = this;
    setTimeout(() => {
      var image: HTMLImageElement = document.querySelector('#image');
      if (self.cropper != null) {
        self.cropper.destroy();
      }
      self.cropper = new Cropper(image, {
        viewMode: 1,
        aspectRatio: image.width / image.height,
        dragMode: 'move',
        cropBoxMovable: false,
        cropBoxResizable: false,
        toggleDragModeOnDblclick: false,
      });
    }, 10);
  }
}


