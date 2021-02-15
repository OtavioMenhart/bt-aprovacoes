import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { CriarProcessoComponent } from './criar-processo/criar-processo.component';
import { MeusProcessosComponent } from './meus-processos/meus-processos.component';

import {ROUTES} from './app.routes'
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MeusProcessosService } from './meus-processos/meus-processos.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    CriarProcessoComponent,
    MeusProcessosComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(ROUTES),
    HttpClientModule
  ],
  providers: [MeusProcessosService],
  bootstrap: [AppComponent]
})
export class AppModule { }
