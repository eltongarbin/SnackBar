import { ToastOptions } from 'ng2-toastr';

export class ToastrCustomOption extends ToastOptions {
    animate: 'flyRight';
    newestOnTop: false;
    showCloseButton: true;

    positionClass: 'toast-bottom-right';
    toastLife: 5000;
    maxShown: 5;
    enableHTML: true;
    dismiss: 'auto';
    messageClass: "";
    titleClass: "";
}