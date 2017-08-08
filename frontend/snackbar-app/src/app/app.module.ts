import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// bootstrap
import { CollapseModule } from 'ng2-bootstrap/collapse';

// imports
import { ToastModule, ToastOptions } from 'ng2-toastr/ng2-toastr';

// shared components
import { MenuSuperiorComponent } from './shared/menu-superior/menu-superior.component';
import { MainPrincipalComponent } from './shared/main-principal/main-principal.component';

// components
import { AppComponent } from './app.component';
import { ListaPedidosComponent } from "./pedidos/lista-pedidos/lista-pedidos.component";
import { CardapioComponent } from "./pedidos/cardapio/cardapio.component";
import { AdicionarPedidoComponent } from "./pedidos/adicionar-pedido/adicionar-pedido.component";
import { EscolherLancheComponent } from "./pedidos/escolher-lanche/escolher-lanche.component";
import { DetalhesPedidoComponent } from "./pedidos/detalhes-pedido/detalhes-pedido.component";

// services
import { PedidoService } from "./pedidos/service/pedido.service";
import { ToastrCustomOption } from "./utils/ToastrCustomOptions";

// others
import { rootRouterConfig } from './app.routes';

@NgModule({
  declarations: [
    AppComponent,
    MenuSuperiorComponent,
    MainPrincipalComponent,
    ListaPedidosComponent,
    CardapioComponent,
    AdicionarPedidoComponent,
    EscolherLancheComponent,
    DetalhesPedidoComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpModule,
    BrowserAnimationsModule,
    ToastModule.forRoot(),
    CollapseModule.forRoot(),
    RouterModule.forRoot(rootRouterConfig, { useHash: false })
  ],
  providers: [
    PedidoService,
    { provide: ToastOptions, useClass: ToastrCustomOption }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
