import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Processos } from '../modelos/processos.model';
import { URL_API } from '../app.api';
import { catchError, map, tap } from 'rxjs/operators';
import { ErrorHandler } from '../app.error-handler';

@Injectable({
  providedIn: 'root'
})
export class MeusProcessosService {

  constructor(private http:HttpClient) { }


  selecionarTodosProcessos(): Observable<Processos[]>{
    return this.http.get<Processos[]>(`${URL_API}/Processos/ObterTodosProcessos`).pipe(catchError(ErrorHandler.handleError))
  }

}
