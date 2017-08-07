import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";

import { Pedido } from "app/pedidos/models/pedido";
import { PedidoService } from "app/pedidos/service/pedido.service";

import { Subscription } from "rxjs/Subscription";

@Component({
    selector: 'app-detalhes-pedido',
    templateUrl: './detalhes-pedido.component.html'
})
export class DetalhesPedidoComponent {
    public pedido: Pedido;
    public errorMessage: string = "";
    private sub: Subscription;

    constructor(private pedidoService: PedidoService,
                private route: ActivatedRoute) {
        this.pedido = new Pedido();
    }

    ngOnInit(): void {
        this.sub = this.route.params.subscribe(
            params => {
                this.obterPedido(params['id']);
            }
        )
    }

    obterPedido(id: string) {
        this.pedidoService.obterPedido(id).subscribe(
            pedido => this.pedido = pedido,
            error => this.errorMessage
        );
    }
}