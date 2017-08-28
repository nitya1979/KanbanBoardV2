import { KanbanUIPage } from './app.po';

describe('kanban-ui App', () => {
  let page: KanbanUIPage;

  beforeEach(() => {
    page = new KanbanUIPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
