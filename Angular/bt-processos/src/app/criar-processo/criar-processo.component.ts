import { Component, OnInit } from '@angular/core';
import {FormGroup, FormBuilder} from '@angular/forms'
import { ProcessoInsertEdit } from '../modelos/processoInsertEdit.model';
import { ResultadoValidacao } from '../validacoes/processo.resultadoValidacao';
import { ValidacaoService } from '../validacoes/processo.validacao.service';
import swal from 'sweetalert';
import { CriarProcessoService } from './criar-processo.service';

@Component({
  selector: 'bt-criar-processo',
  templateUrl: './criar-processo.component.html',
  styleUrls: ['./criar-processo.component.css']
})
export class CriarProcessoComponent implements OnInit {

  processoForm: FormGroup
  processoCriacao: ProcessoInsertEdit
  resultadoValidacao: ResultadoValidacao

  constructor(private formBuilder: FormBuilder, private validacaoService: ValidacaoService, private criarProcessoService: CriarProcessoService) { }

  ngOnInit(): void {
    this.processoForm = this.formBuilder.group({
      NumeroProcesso: '',
      ValorCausa: '',
      Escritorio: '',
      NomeReclamante: ''
    });
  }

  criarProcesso(){
    this.processoCriacao = Object.assign(new ProcessoInsertEdit(), this.processoForm.value)
    this.resultadoValidacao = this.validacaoService.validar(this.processoCriacao)

    if(this.resultadoValidacao.status){
      this.criarProcessoService.criarProcesso(this.processoCriacao).toPromise().then(resultado => {
        this.processoForm.reset()
        swal("Sucesso!", "Processo cadastrado!", "success");
      })
      
    }

  }

}
