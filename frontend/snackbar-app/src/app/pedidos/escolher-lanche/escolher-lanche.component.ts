import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core'
import { AbstractControl, FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms'

import { PedidoService } from "app/pedidos/service/pedido.service";
import { Lanche, Ingrediente } from "app/pedidos/models/pedido";

@Component({
    selector: 'app-escolher-lanche',
    templateUrl: './escolher-lanche.component.html'
})
export class EscolherLancheComponent implements OnInit {
    @Output() onLancheEscolhido: EventEmitter<Lanche> = new EventEmitter<Lanche>();

    lanches: Lanche[];
    ingredientes: Ingrediente[];

    errorMessage: string = "";
    lancheForm: FormGroup;

    constructor(private fb: FormBuilder,
                private pedidoService: PedidoService) {
    }

    ngOnInit() {
        let CampoLancheId = new FormControl('', Validators.required);
         CampoLancheId.valueChanges
            .subscribe(newId => {
                if (newId) {
                    this.obterIngredientesLanche(newId);
                }
            });

        this.lancheForm = this.fb.group({
            id: CampoLancheId,
            ingredientes: this.fb.array([], Validators.required),
        });

        this.pedidoService.obterLanchesCardapio().subscribe(
            lanches => this.lanches = lanches,
            error => this.errorMessage
        );

        this.pedidoService.obterIngredientes().subscribe(
            ingredientes => this.ingredientes = ingredientes,
            error => this.errorMessage
        );
    }

    adicionarIngrediente(ingredienteId: string) {
        const control = <FormArray>this.lancheForm.controls['ingredientes'];
        const addrCtrl = this.fb.group({
            id: [ingredienteId, Validators.required]
        });
        
        control.push(addrCtrl);        
    }

    removerIngrediente(i: number) {
        const control = <FormArray>this.lancheForm.controls['ingredientes'];
        control.removeAt(i);
    }

    obterIngredientesLanche(lancheId: string) {
        const control = <FormArray>this.lancheForm.controls['ingredientes'];
        while (control.length) {
            control.removeAt(0);
        }

        this.lanches.find(l => l.id == lancheId).ingredientes.forEach(i => {
            this.adicionarIngrediente(i.id);
        });
    }

    submit() {
        if (this.lancheForm.dirty && this.lancheForm.valid) {
            let lancheEscolhido = this.lanches.find(l => l.id == this.lancheForm.controls['id'].value);
            let ingredientesEscolhidos = this.lancheForm.controls['ingredientes'].value.map(i => {
                return this.ingredientes.find(x => x.id == i.id);
            });
            
            lancheEscolhido.ingredientes = ingredientesEscolhidos;

            this.onLancheEscolhido.emit(lancheEscolhido);
            this.lancheForm.reset();
        }        
    }
}