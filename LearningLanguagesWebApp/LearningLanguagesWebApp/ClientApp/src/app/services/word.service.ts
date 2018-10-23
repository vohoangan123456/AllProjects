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

  getWordsByFilter() {
    return this.httpClient.get(`${this.API_URL}/api/words`);
  }
}
