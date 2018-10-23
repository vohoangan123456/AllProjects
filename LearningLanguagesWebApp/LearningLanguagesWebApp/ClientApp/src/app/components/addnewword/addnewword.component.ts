import { Component, OnInit } from '@angular/core';

import { Word } from '../../models/word';
import { NgForm } from '@angular/forms';

import { WordService } from '../../services/word.service';

@Component({
  selector: 'app-addnewword',
  templateUrl: './addnewword.component.html',
  styleUrls: ['./addnewword.component.css']
})
export class AddnewwordComponent implements OnInit {
  constructor(private wordService: WordService) { }
  ngOnInit() {
    this.getWords();
  }

  public getWords() {
    this.wordService.getWordsByFilter().subscribe((data: Array<object>) => {
      console.log(data);
    });
  }

  public addNewWord() {
    this.wordService.addNewWords(this.model).subscribe((response) => {
      console.log(response);
    });
  }

  model = new Word();
  onSubmit(f: NgForm) {
    this.addNewWord();
  }

  get diagnostic() { return JSON.stringify(this.model); }
}
