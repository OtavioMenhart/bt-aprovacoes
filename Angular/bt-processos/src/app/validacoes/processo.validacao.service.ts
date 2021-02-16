import { Injectable } from '@angular/core';
import { ResultadoValidacao } from './processo.resultadoValidacao';
import swal from 'sweetalert';
import { ProcessoInsertEdit } from '../modelos/processoInsertEdit.model';

@Injectable({
  providedIn: 'root'
})
export class ValidacaoService {

  resultado: ResultadoValidacao = new ResultadoValidacao()

  constructor() { }

  validar(processoValidar: ProcessoInsertEdit): ResultadoValidacao{
    if(this.validaVazio(processoValidar.NumeroProcesso)){
        this.resultado.status = false;
        this.resultado.msg = "Número do processo é obrigatório"
        swal("Ops!", this.resultado.msg, "info");
        return this.resultado
    }
    if(processoValidar.NumeroProcesso.length != 12){
        this.resultado.status = false;
        this.resultado.msg = "Número do processo deve ser um campo de 12 caracteres"
        swal("Ops!", this.resultado.msg, "info");
        return this.resultado
    }

    if(this.validaVazio(processoValidar.Escritorio)){
        this.resultado.status = false;
        this.resultado.msg = "Escritório é obrigatório"
        swal("Ops!", this.resultado.msg, "info");
        return this.resultado
    }
    if(processoValidar.Escritorio.length > 50){
        this.resultado.status = false;
        this.resultado.msg = "Escritório tem limite de 50 caracteres"
        swal("Ops!", this.resultado.msg, "info");
        return this.resultado
    }

    if(this.validaVazio(processoValidar.NomeReclamante)){
        this.resultado.status = false;
        this.resultado.msg = "Nome do reclamante é obrigatório"
        swal("Ops!", this.resultado.msg, "info");
        return this.resultado
    }
    if(processoValidar.NomeReclamante.length > 100){
        this.resultado.status = false;
        this.resultado.msg = "Nome do reclamante tem limite de 100"
        swal("Ops!", this.resultado.msg, "info");
        return this.resultado
    }


    if(this.validaVazio(processoValidar.ValorCausa.toString())){
        this.resultado.status = false;
        this.resultado.msg = "Valor da causa é obrigatório"
        swal("Ops!", this.resultado.msg, "info");
        return this.resultado
    }
    if(processoValidar.ValorCausa <= 30000){
        this.resultado.status = false;
        this.resultado.msg = "Valor da causa deve ser maior que R$ 30.000,00"
        swal("Ops!", this.resultado.msg, "info");
        return this.resultado
    }
    
    this.resultado.status = true
    this.resultado.msg = "Informações validadas"
    return this.resultado
}

validaVazio(campo: string): boolean{
    return (campo.length === 0 || !campo.trim());
}

}
