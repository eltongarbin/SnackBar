import { Routes } from '@angular/router';

import { ListaPedidosComponent } from "./pedidos/lista-pedidos/lista-pedidos.component";

export const rootRouterConfig: Routes = [
    { path: '', redirectTo: 'lista-pedidos', pathMatch: 'full' },
    { path: 'lista-pedidos', component: ListaPedidosComponent }
]