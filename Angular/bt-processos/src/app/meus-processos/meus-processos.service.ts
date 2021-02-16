import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Processos } from '../modelos/processos.model';
import { URL_API } from '../app.api';
import { catchError, map, tap } from 'rxjs/operators';
import { ErrorHandler } from '../app.error-handler';
import { ProcessoResultado } from '../modelos/processoResultado.model';
import { AprovarCompra } from '../modelos/aprovarCompra.model';
import { AlterarStatusProcesso } from '../modelos/alterarStatus.model';
import { ProcessoInsertEdit } from '../modelos/processoInsertEdit.model';


@Injectable({
  providedIn: 'root'
})
export class MeusProcessosService {

  constructor(private http:HttpClient) { }
// Headers
httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
}

  selecionarTodosProcessos(): Observable<Processos[]>{
    return this.http.get<Processos[]>(`${URL_API}/Processos/ObterTodosProcessos`).pipe(catchError(ErrorHandler.handleError))
  }

  aprovarCompraProcesso(compra: AprovarCompra): Observable<ProcessoResultado>{
    return this.http.patch<ProcessoResultado>(`${URL_API}/Processos/AprovarCompra`, JSON.stringify(compra), this.httpOptions).pipe(catchError(ErrorHandler.handleError))
  }

  alterarStatusProcesso(alteracao: AlterarStatusProcesso): Observable<ProcessoResultado>{
    return this.http.patch<ProcessoResultado>(`${URL_API}/Processos/AlterarStatusProcesso`, JSON.stringify(alteracao), this.httpOptions).pipe(catchError(ErrorHandler.handleError))
  }

  editarProcesso(processoEditado: ProcessoInsertEdit): Observable<ProcessoResultado>{
    return this.http.patch<ProcessoResultado>(`${URL_API}/Processos/EditarProcesso`, JSON.stringify(processoEditado), this.httpOptions).pipe(catchError(ErrorHandler.handleError))
  }

  pesquisarPorNumeroProcesso(numeroProcesso: string): Observable<Processos>{
    return this.http.get<Processos>(`${URL_API}/Processos/ObterPorNumeroProcesso/${numeroProcesso}`).pipe(catchError(ErrorHandler.handleError))
  }

}
