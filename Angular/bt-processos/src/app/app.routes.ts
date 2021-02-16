import {Routes} from '@angular/router'
import { ChatComponent } from './chat/chat.component'
import { CriarProcessoComponent } from './criar-processo/criar-processo.component'
import { HomeComponent } from './home/home.component'
import { MeusProcessosComponent } from './meus-processos/meus-processos.component'

export const ROUTES: Routes = [
    {path:'criar-processo', component:CriarProcessoComponent},
    {path:'meus-processos', component:MeusProcessosComponent},
    {path:'', component: HomeComponent},
    {path: 'chat', component: ChatComponent}
]