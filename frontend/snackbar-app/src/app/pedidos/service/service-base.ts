import { Response, RequestOptions, Headers } from '@angular/http';

import { Observable } from "rxjs/Observable";
import 'rxjs/add/observable/throw';

export abstract class ServiceBase {
    protected UrlServiceV1: string = 'http://localhost:49875/api/v1/';

    protected serviceError(error: Response | any) {
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);

            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }

        return Observable.throw(error);
    }

    protected obterAuthHeader(): RequestOptions {
        let headers = new Headers({ 'Content-type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return options;
    }
}