import { Component, OnInit, ViewContainerRef } from "@angular/core";
import { FormBuilder, FormGroup, Validators, FormArray } from "@angular/forms";
import { Router } from "@angular/router";

import { Lanche, Pedido } from "app/pedidos/models/pedido";
import { PedidoService } from "app/pedidos/service/pedido.service";

import { ToastsManager, Toast } from 'ng2-toastr/ng2-toastr';

@Component({
    selector: 'app-adicionar-pedido',
    templateUrl: './adicionar-pedido.component.html'
})
export class AdicionarPedidoComponent implements OnInit {
    private modalVisible: boolean;
    private pedido: Pedido;
    lanches: Lanche[] = [];

    errors: any[] = [];
    errorMessage: string = "";
    pedidoForm: FormGroup;

    constructor(private fb: FormBuilder,
        public toastr: ToastsManager,
        private router: Router,
        vcr: ViewContainerRef,
        private pedidoService: PedidoService) {
        this.toastr.setRootViewContainerRef(vcr);
        this.modalVisible = false;
    }

    ngOnInit() {
        this.pedidoForm = this.fb.group({
            cliente: ['', Validators.required],
            lanches: this.fb.array([], Validators.required),
        });
    }

    submit() {
        if (this.pedidoForm.dirty && this.pedidoForm.valid) {
            let pedidoMapped = Object.assign({}, this.pedido, this.pedidoForm.value);

            this.pedidoService.realizarPedido(pedidoMapped).subscribe(
                result => this.onSaveComplete(),
                error => this.onError(error)
            );
        }
    }

    onSaveComplete(): void {
        this.pedidoForm.reset();
        this.errors = [];

        this.toastr.success('Pedido efetuado com sucesso!', 'Oba :D', { dismiss: 'controlled' })
            .then((toast: Toast) => {
                setTimeout(() => {
                    this.toastr.dismissToast(toast);
                    this.router.navigate(['/lista-pedidos']);
                }, 1000);
            });
    }

    onError(error): void {
        this.toastr.error('Ocorreu um erro no processamento', 'Ops! :(');
        this.errors = JSON.parse(error._body).errors;
    }

    showModal() {
        this.modalVisible = true;
    }

    hideModal() {
        this.modalVisible = false;
    }

    salvarLancheEscolhido(lanche: Lanche) {
        this.lanches.push(lanche);

        const control = <FormArray>this.pedidoForm.controls['lanches'];
        const addrCtrl = this.fb.group({
            id: [lanche.id, Validators.required],
            ingredientes: this.fb.array([...lanche.ingredientes], Validators.required)
        });
        control.push(addrCtrl);

        this.hideModal();
    }

    excluirLancheEscolhido(index) {
        this.lanches.splice(index, 1);

        const control = <FormArray>this.pedidoForm.controls['lanches'];
        control.removeAt(index);
    }
}