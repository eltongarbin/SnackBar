export class Ingrediente {
    id: string;
    nome: string;
    valor: number;
}

export class Lanche {
    id: string;
    nome: string;
    valorTotal: string;
    promocao: string;
    desconto: string;

    Ingredientes: Ingrediente[];
}

export class Pedido {
    id: string;
    cliente: string;
    valorTotal: number;
    qtLanches: number;
    status: string;
    dataStatus: Date;
}