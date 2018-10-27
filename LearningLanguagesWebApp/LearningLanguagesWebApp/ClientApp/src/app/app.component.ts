import { Component } from '@angular/core';
import { TranslateService, USE_DEFAULT_LANG } from '@ngx-translate/core';
import { Constants } from './constants';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  hiddenSetting = true;
  hiddenLanguageSetting = true;
  labelsLocale = {
    home: 'Label.Common.home',
    word: 'Label.Common.word',
    category: 'Label.Common.category',
    aboutUs: 'Label.Common.aboutUs',
    learn: 'Label.Common.learn',
    setting: 'Label.ToolTip.setting',
    language: 'Label.ToolTip.language',
    vietnamese: 'Label.Common.vietnamese',
    english: 'Label.Common.english'
  };
  selectedEnglish = false;
  selectedVietNamese = false;
  constructor(private translate: TranslateService) {
    translate.setDefaultLang('en');
    this.selectedEnglish = true;
  }

  switchLanguage(language: string) {
    this.translate.use(language);
    this.selectedEnglish = false;
    this.selectedVietNamese = false;
    switch (language) {
      case Constants.LANGUAGES.EN:
        this.selectedEnglish = true;
        break;
      case Constants.LANGUAGES.VI:
        this.selectedVietNamese = true;
        break;
      default:
        this.selectedEnglish = true;
        break;
    }
    this.hiddenSetting = true;
    this.hiddenLanguageSetting = true;
  }
  title = 'Robert Vo Learning page';
  getYear() {
    return new Date().getUTCFullYear();
  }

  get webTitle(): string {
    return "Learning Page";
  }

  public toggleSettingPanel() {
    this.hiddenSetting = !this.hiddenSetting;
  }

  public toggleLanguageSetting() {
    this.hiddenLanguageSetting = !this.hiddenLanguageSetting;
  }
}
