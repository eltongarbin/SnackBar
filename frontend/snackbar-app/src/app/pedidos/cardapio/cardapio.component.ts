import { Component } from "@angular/core";

import { Lanche } from "app/pedidos/models/pedido";
import { PedidoService } from "app/pedidos/service/pedido.service";

 @Component({
    selector: 'app-cardapio',
    templateUrl: './cardapio.component.html',
    styleUrls: ['./cardapio.component.css']
})
export class CardapioComponent {
    public lanches: Lanche[];
    public errorMessage: string = "";

    constructor(private pedidoService: PedidoService) { }

    ngOnInit(): void {
        this.pedidoService.ObterLanchesCardapio().subscribe(
            lanches => this.lanches = lanches,
            error => this.errorMessage
        );
    }
}