import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchWithOptionsComponent } from './search-with-options.component';

describe('SearchWithOptionsComponent', () => {
  let component: SearchWithOptionsComponent;
  let fixture: ComponentFixture<SearchWithOptionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchWithOptionsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SearchWithOptionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
