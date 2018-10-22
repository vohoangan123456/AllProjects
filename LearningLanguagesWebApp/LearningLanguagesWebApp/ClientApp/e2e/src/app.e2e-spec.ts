// ====================================================
// More Templates: https://www.ebenmonney.com/templates
// Email: support@ebenmonney.com
// ====================================================

import { AppPage } from './app.po';

describe('Angular6Template App', () => {
  let page: AppPage;

  beforeEach(() => {
    page = new AppPage();
  });

  it('should display application title: Angular6Template', () => {
    page.navigateTo();
    expect(page.getAppTitle()).toEqual('Angular6Template');
  });
});
