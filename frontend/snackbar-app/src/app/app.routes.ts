import { Routes } from '@angular/router';

import { ListaPedidosComponent } from "./pedidos/lista-pedidos/lista-pedidos.component";
import { CardapioComponent } from "./pedidos/cardapio/cardapio.component";

export const rootRouterConfig: Routes = [
    { path: '', redirectTo: 'lista-pedidos', pathMatch: 'full' },
    { path: 'lista-pedidos', component: ListaPedidosComponent },
    { path: 'cardapio', component: CardapioComponent }
]