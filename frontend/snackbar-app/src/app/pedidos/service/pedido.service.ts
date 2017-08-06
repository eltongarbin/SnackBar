import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";

import { Observable } from "rxjs/Observable";
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { Ingrediente, Lanche, Pedido } from "./../models/pedido";
import { ServiceBase } from "./service-base";

@Injectable()
export class PedidoService extends ServiceBase {
    constructor(private http: Http) { super(); }

    private extractData(response: Response) {
        let body = response.json();
        return body.data || {};
    }

    obterTodos(): Observable<Pedido[]> {
        return this.http.get(this.UrlServiceV1 + 'pedidos')
            .map((res: Response) => <Pedido[]>res.json())
            .catch(super.serviceError);
    }
}