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
import {ReactiveFormsModule} from '@angular/forms'
import { ValidacaoService } from './validacoes/processo.validacao.service';
import { ChatComponent } from './chat/chat.component';
import { ChatService } from './chat/chat.service';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    CriarProcessoComponent,
    MeusProcessosComponent,
    HomeComponent,
    ChatComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(ROUTES),
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [MeusProcessosService, ValidacaoService, ChatService],
  bootstrap: [AppComponent]
})
export class AppModule { }
