import { Component, OnInit } from '@angular/core';
import { AlterarStatusProcesso } from '../modelos/alterarStatus.model';
import { AprovarCompra } from '../modelos/aprovarCompra.model';
import { ProcessoResultado } from '../modelos/processoResultado.model';
import { Processos } from '../modelos/processos.model';
import { MeusProcessosService } from './meus-processos.service';
import {FormGroup, FormBuilder} from '@angular/forms'
import { ResultadoValidacao } from '../validacoes/processo.resultadoValidacao';
import { ValidacaoService } from '../validacoes/processo.validacao.service';
import { ProcessoInsertEdit } from '../modelos/processoInsertEdit.model';
import { PesquisaProcesso } from '../modelos/pesquisaProcesso.model';
import swal from 'sweetalert';
import { Subject } from 'rxjs';

declare var $: any

@Component({
  selector: 'bt-meus-processos',
  templateUrl: './meus-processos.component.html'
})
export class MeusProcessosComponent implements OnInit {

  processos: Processos[]
  compra: AprovarCompra
  alteracaoStatus:AlterarStatusProcesso
  processoResultado: ProcessoResultado

  processoForm: FormGroup
  processoEdicao: ProcessoInsertEdit

  pesquisarProcessoForm: FormGroup
  pesquisaProcesso: PesquisaProcesso

  resultadoValidacao: ResultadoValidacao

  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject();
  show: boolean

  constructor(private meusProcessosService: MeusProcessosService, private formBuilder: FormBuilder, private validacaoService: ValidacaoService) { }

  ngOnInit(): void {
    
    this.opcoesDatatable()
    this.processoForm = this.formBuilder.group({
      NumeroProcesso: '',
      ValorCausa: '',
      Escritorio: '',
      NomeReclamante: ''
    });
    this.pesquisarProcessoForm = this.formBuilder.group({
      NumeroProcessoPesquisa: ''
    });
    this.carregarProcessos()    
  }

  ngOnDestroy(): void {
    // Do not forget to unsubscribe the event
    this.dtTrigger.unsubscribe();
  }

  opcoesDatatable(){
    this.dtOptions = {
      // destroy: true,
      processing: true,
      pageLength: 5,
      lengthMenu: [5, 10, 20, 50, 100, 200, 500],
    }
  }

  carregarProcessos() {
    this.show = false
    this.processos = []
    this.opcoesDatatable()

      this.meusProcessosService.selecionarTodosProcessos().toPromise().then(processos => 
        {
          this.processos = processos;  
          this.show = true
        })

    
  }

  aprovarProcesso(numeroProcesso: string, status: boolean){
    this.compra = {
      NumeroProcesso: numeroProcesso,
      StatusCompra: status
    }
    
    this.meusProcessosService.aprovarCompraProcesso(this.compra).toPromise().then(resultado => {
      this.processoResultado = resultado

      if(this.processoResultado.processo != null){
        this.carregarProcessos()
      }
    })
  }

  alterarStatusProcesso(numeroProcesso: string, status: boolean){
    this.alteracaoStatus = {
      NumeroProcesso: numeroProcesso,
      Status: status
    }

    this.meusProcessosService.alterarStatusProcesso(this.alteracaoStatus).toPromise().then(resultado =>{
      
      this.processoResultado = resultado
      if(this.processoResultado.processo != null){
        this.carregarProcessos()
      }
    })    
  }

  abrirModal(processo: Processos){
    $('#modalDetalheProcesso').modal('show');
    
    this.processoForm = this.formBuilder.group({
      NumeroProcesso: processo.numeroProcesso,
      ValorCausa: processo.valorCausa.toString().replace(".", ","),
      Escritorio: processo.escritorio,
      NomeReclamante: processo.nomeReclamante
    });
    
  }

  editarProcesso(){
    
    this.processoEdicao = Object.assign(new ProcessoInsertEdit(), this.processoForm.value)
    this.processoEdicao.ValorCausa = Number(this.processoEdicao.ValorCausa.toString().replace(",", "."))
    
    this.resultadoValidacao = this.validacaoService.validar(this.processoEdicao)

    if(this.resultadoValidacao.status){
      this.meusProcessosService.editarProcesso(this.processoEdicao).toPromise().then(resultado => {
        this.processoResultado = resultado
        this.processoForm.reset()
        $('#modalDetalheProcesso').modal('toggle');
        this.carregarProcessos()
      });
    }
  }

  pesquisarProcesso(){
    this.pesquisaProcesso = Object.assign(new PesquisaProcesso(), this.pesquisarProcessoForm.value)

    this.meusProcessosService.pesquisarPorNumeroProcesso(this.pesquisaProcesso.NumeroProcessoPesquisa).toPromise().then(
      resultado =>{
        if(resultado != null){
          this.processos = []
          this.processos.push(resultado)
          this.pesquisarProcessoForm.reset()
        }else{
          swal("Ops!", "Processo não encontrado", "info");
        }
        
    })
    
  }

}
