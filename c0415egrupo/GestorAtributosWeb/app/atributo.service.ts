import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Atributo } from './atributo';

@Injectable()
export class AtributoService {

    private headers = new Headers({ 'Content-Type': 'application/json', 'Accept': 'application/json'});
  private atributosUrl = 'api/atributos';  // URL to web api

  constructor(private http: Http) { }

  getAtributos(): Promise<Atributo[]> {
      return this.http.get(this.atributosUrl, { headers: this.headers })
               .toPromise()
               .then(response => response.json() as Atributo[])
               .catch(this.handleError);
  }

  getAtributo(id: number): Promise<Atributo> {
      return this.getAtributos()
          .then(atributos => atributos.find(atributo => atributo.id === id));
  }

  delete(id: number): Promise<void> {
      let url = `${this.atributosUrl}/${id}`;
    return this.http.delete(url, {headers: this.headers})
      .toPromise()
      .then(() => null)
      .catch(this.handleError);
  }

  create(atributo: Atributo): Promise<Atributo> {
    return this.http
        .post(this.atributosUrl, JSON.stringify(atributo), {headers: this.headers})
      .toPromise()
      .then(res => res.json().data)
      .catch(this.handleError);
  }

  update(atributo: Atributo): Promise<Atributo> {
      const url = `${this.atributosUrl}/${atributo.id}`;
      return this.http
        .put(url, JSON.stringify(atributo), {headers: this.headers})
        .toPromise()
        .then(() => atributo)
        .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}