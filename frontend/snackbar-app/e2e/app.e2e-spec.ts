import { SnackbarAppPage } from './app.po';

describe('snackbar-app App', () => {
  let page: SnackbarAppPage;

  beforeEach(() => {
    page = new SnackbarAppPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
