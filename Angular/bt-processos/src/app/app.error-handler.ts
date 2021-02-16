import { Observable, throwError } from 'rxjs';
import { of } from 'rxjs/internal/observable/of';
import { ProcessoResultado } from './modelos/processoResultado.model';
import swal from 'sweetalert';

export class ErrorHandler{
    static handleError(error) {
      let errorMessage = '';
      if (error.error instanceof ErrorEvent) {
        // client-side error
        errorMessage = `Error: ${error.error.message}`;
      } else {
        // server-side error
        errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
      }
      console.log(errorMessage);
      console.log(error.error);

      let resultadoErro = Object.assign(new ProcessoResultado(), error.error)

      if(resultadoErro instanceof ProcessoResultado){
        swal("Erro!", resultadoErro.msg, "error");
      }

      return throwError(errorMessage);
    }
   }
