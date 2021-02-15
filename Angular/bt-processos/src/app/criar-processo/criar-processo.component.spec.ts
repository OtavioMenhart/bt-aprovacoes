import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CriarProcessoComponent } from './criar-processo.component';

describe('CriarProcessoComponent', () => {
  let component: CriarProcessoComponent;
  let fixture: ComponentFixture<CriarProcessoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CriarProcessoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CriarProcessoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
