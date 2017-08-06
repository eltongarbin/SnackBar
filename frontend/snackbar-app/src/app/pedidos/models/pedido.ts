export class Ingrediente {
    id: string;
    nome: string;
    valor: number;
}

export class Lanche {
    id: string;
    nome: string;
    valorTotal: number;
    promocao: string;
    desconto: number;

    ingredientes: Ingrediente[];
}

export class Pedido {
    id: string;
    cliente: string;
    valorTotal: number;
    qtLanches: number;
    status: string;
    dataStatus: Date;
}