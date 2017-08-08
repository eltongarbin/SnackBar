import { Routes } from '@angular/router';

import { ListaPedidosComponent } from "./pedidos/lista-pedidos/lista-pedidos.component";
import { CardapioComponent } from "./pedidos/cardapio/cardapio.component";
import { AdicionarPedidoComponent } from "./pedidos/adicionar-pedido/adicionar-pedido.component";
import { DetalhesPedidoComponent } from "./pedidos/detalhes-pedido/detalhes-pedido.component";

export const rootRouterConfig: Routes = [
    { path: '', redirectTo: 'lista-pedidos', pathMatch: 'full' },
    { path: 'lista-pedidos', component: ListaPedidosComponent },
    { path: 'cardapio', component: CardapioComponent },
    { path: 'detalhes-pedido/:id', component: DetalhesPedidoComponent },
    { path: 'novo-pedido', component: AdicionarPedidoComponent }
]