import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// bootstrap
import { CollapseModule } from 'ng2-bootstrap/collapse';

// imports
import { ToastModule, ToastOptions } from 'ng2-toastr';

// shared components
import { MenuSuperiorComponent } from './shared/menu-superior/menu-superior.component';
import { FooterComponent } from './shared/footer/footer.component';
import { MainPrincipalComponent } from './shared/main-principal/main-principal.component';

// components
import { AppComponent } from './app.component';
import { ListaPedidosComponent } from "./pedidos/lista-pedidos/lista-pedidos.component";

// others
import { rootRouterConfig } from './app.routes';

@NgModule({
  declarations: [
    AppComponent,
    MenuSuperiorComponent,
    FooterComponent,
    MainPrincipalComponent,
    ListaPedidosComponent
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
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
