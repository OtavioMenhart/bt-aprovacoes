import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { URL_API } from '../app.api';
import { ErrorHandler } from '../app.error-handler';
import { ProcessoInsertEdit } from '../modelos/processoInsertEdit.model';
import { ProcessoResultado } from '../modelos/processoResultado.model';

@Injectable({
  providedIn: 'root'
})
export class CriarProcessoService {

  constructor(private http:HttpClient) { }
  // Headers
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  criarProcesso(processoCriado: ProcessoInsertEdit): Observable<ProcessoResultado>{
    return this.http.post<ProcessoResultado>(`${URL_API}/Processos/CriarProcesso`, JSON.stringify(processoCriado), this.httpOptions).pipe(catchError(ErrorHandler.handleError))
  }
}
