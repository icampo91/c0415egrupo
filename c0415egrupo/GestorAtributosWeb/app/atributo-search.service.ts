import { Injectable }     from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import { Observable } from 'rxjs';

import { Atributo }           from './atributo';

@Injectable()
export class AtributoSearchService {

    private headers = new Headers({ 'Content-Type': 'application/json', 'Accept': 'application/json' });
    constructor(private http: Http) { }

    search(term: string): Observable<Atributo[]> {
        return this.http
            .get(`api/atributos/?codigo=${term}`, { headers: this.headers })
            .map((r: Response) => r.json() as Atributo[]);
    }

    filter(codigo: string): Promise<Atributo[]> {
        return this.http
            .get(`api/atributos/?codigo=${codigo}`, { headers: this.headers })
            .toPromise()
            .then(response => response.json() as Atributo[]);
    }
}
