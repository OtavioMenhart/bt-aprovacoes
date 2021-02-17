# Api.Processos

Aplique a migration no projeto Api.Processos.Data: dotnet ef database update

A conexão do banco de dados está na classe ConfiguracaoBD e apontando para local: (localdb)\\MSSQLLocalDB

É preciso alterar o arquivo do sweetalert no node_modules/sweetalert/typings/sweetalert.d.ts:

import swal, { SweetAlert } from "./core";

export default swal;

export as namespace swal;

[Referência](https://github.com/t4t5/sweetalert/issues/890)

Outras bibliotecas utilizadas:
- [angular-datatables](http://l-lin.github.io/angular-datatables/#/welcome)
- O próprio [sweetalert](https://sweetalert.js.org/guides/)
- [ngx-mask](https://www.npmjs.com/package/ngx-mask)

Para executar o front:

- ng build --prod
- docker build -t bt-processos-front .
- docker run -it --rm -p 4200:80 bt-processos-front
