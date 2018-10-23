import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddnewwordComponent } from './addnewword.component';

describe('AddnewwordComponent', () => {
  let component: AddnewwordComponent;
  let fixture: ComponentFixture<AddnewwordComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddnewwordComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddnewwordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
