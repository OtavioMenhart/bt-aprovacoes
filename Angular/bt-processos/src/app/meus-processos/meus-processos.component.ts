import { Component, OnInit } from '@angular/core';
import { Processos } from '../modelos/processos.model';
import { MeusProcessosService } from './meus-processos.service';

@Component({
  selector: 'bt-meus-processos',
  templateUrl: './meus-processos.component.html'
})
export class MeusProcessosComponent implements OnInit {

  constructor(private meusProcessosService: MeusProcessosService) { }

  ngOnInit(): void {
    this.meusProcessosService.selecionarTodosProcessos().toPromise().then(processos => {console.log(processos)})
  }

}
