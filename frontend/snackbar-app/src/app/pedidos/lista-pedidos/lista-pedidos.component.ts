import { Component, OnInit } from '@angular/core';

import { Pedido } from "app/pedidos/models/pedido";
import { PedidoService } from "app/pedidos/service/pedido.service";

@Component({
    selector: 'app-lista-pedidos',
    templateUrl: './lista-pedidos.component.html'
})
export class ListaPedidosComponent implements OnInit {
    public pedidos: Pedido[];
    public errorMessage: string = "";

    constructor(private pedidoService: PedidoService) { }

    ngOnInit(): void {
        this.pedidoService.obterTodos().subscribe(
            pedidos => this.pedidos = pedidos,
            error => this.errorMessage
        );
    }
}