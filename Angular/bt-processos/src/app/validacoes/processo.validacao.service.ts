import { Injectable } from '@angular/core';
import { ResultadoValidacao } from './processo.resultadoValidacao';
import swal from 'sweetalert';
import { ProcessoInsertEdit } from '../modelos/processoInsertEdit.model';
import { erroEscritorioVazio, erroNumeroProcessoVazio, erroReclamanteVazio, erroTamanhoCaracteresEscritorio, erroTamanhoCaracteresNumeroProcesso, erroTamanhoCaracteresReclamante, erroValorCausaMinimo, paramatroMinimoValor, parametroMaximoEscritorio, parametroMaximoReclamante, parametroTamanhoCaracteresNumeroProcesso } from './processo.constValidacao';

@Injectable({
  providedIn: 'root'
})
export class ValidacaoService {

  resultado: ResultadoValidacao = new ResultadoValidacao()

  constructor() { }

  validar(processoValidar: ProcessoInsertEdit): ResultadoValidacao{
    if(this.validaVazio(processoValidar.NumeroProcesso)){
        this.resultado.status = false;
        this.resultado.msg = erroNumeroProcessoVazio
        swal("Ops!", this.resultado.msg, "info");
        return this.resultado
    }
    if(processoValidar.NumeroProcesso.length != parametroTamanhoCaracteresNumeroProcesso){
        this.resultado.status = false;
        this.resultado.msg = erroTamanhoCaracteresNumeroProcesso
        swal("Ops!", this.resultado.msg, "info");
        return this.resultado
    }

    if(this.validaVazio(processoValidar.Escritorio)){
        this.resultado.status = false;
        this.resultado.msg = erroEscritorioVazio
        swal("Ops!", this.resultado.msg, "info");
        return this.resultado
    }
    if(processoValidar.Escritorio.length > parametroMaximoEscritorio){
        this.resultado.status = false;
        this.resultado.msg = erroTamanhoCaracteresEscritorio
        swal("Ops!", this.resultado.msg, "info");
        return this.resultado
    }

    if(this.validaVazio(processoValidar.NomeReclamante)){
        this.resultado.status = false;
        this.resultado.msg = erroReclamanteVazio
        swal("Ops!", this.resultado.msg, "info");
        return this.resultado
    }
    if(processoValidar.NomeReclamante.length > parametroMaximoReclamante){
        this.resultado.status = false;
        this.resultado.msg = erroTamanhoCaracteresReclamante
        swal("Ops!", this.resultado.msg, "info");
        return this.resultado
    }


    if(this.validaVazio(processoValidar.ValorCausa.toString())){
        this.resultado.status = false;
        this.resultado.msg = "Valor da causa é obrigatório"
        swal("Ops!", this.resultado.msg, "info");
        return this.resultado
    }
    if(processoValidar.ValorCausa <= paramatroMinimoValor){
        this.resultado.status = false;
        this.resultado.msg = erroValorCausaMinimo
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
