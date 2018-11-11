import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Utilities } from './utilities';
import { Word } from '../models/word';


@Injectable({
  providedIn: 'root'
})
export class WordService {

  constructor(private httpClient: HttpClient) { }
  API_URL = Utilities.baseUrl();

  addNewWords(word: Word) {
    return this.httpClient.post(`${this.API_URL}/api/words`, word );
  }

  updateNewWord(word: Word) {
    return this.httpClient.put(`${this.API_URL}/api/words/${word.id}`, word);
  }

  deleteMultipleWord(ids: any) {
    return this.httpClient.post(`${this.API_URL}/api/words/bulkdelete`, ids);
  }

  getWordById(id: number) {
    return this.httpClient.get(`${this.API_URL}/api/words/${id}`);
  }

  getWordsByFilter() {
    return this.httpClient.get(`${this.API_URL}/api/words/getdata`);
  }
}
