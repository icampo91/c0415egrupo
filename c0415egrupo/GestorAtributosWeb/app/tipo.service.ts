import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Tipo } from './tipo';

@Injectable()
export class TipoService {

    private headers = new Headers({ 'Content-Type': 'application/json', 'Accept': 'application/json'});
  private tiposUrl = 'api/tipos';  // URL to web api

  constructor(private http: Http) { }

  getTipos(): Promise<Tipo[]> {
      return this.http.get(this.tiposUrl, { headers: this.headers })
               .toPromise()
               .then(response => response.json() as Tipo[])
               .catch(this.handleError);
  }

  getTipo(id: number): Promise<Tipo> {
      return this.getTipos()
          .then(tipos => tipos.find(tipo => tipo.id === id));
  }

  delete(id: number): Promise<void> {
      let url = `${this.tiposUrl}/${id}`;
    return this.http.delete(url, {headers: this.headers})
      .toPromise()
      .then(() => null)
      .catch(this.handleError);
  }

  create(tipo: Tipo): Promise<Tipo> {
    return this.http
        .post(this.tiposUrl, JSON.stringify(tipo), {headers: this.headers})
      .toPromise()
      .then(res => res.json().data)
      .catch(this.handleError);
  }

  update(tipo: Tipo): Promise<Tipo> {
      const url = `${this.tiposUrl}/${tipo.id}`;
      return this.http
          .put(url, JSON.stringify(tipo), {headers: this.headers})
        .toPromise()
          .then(() => tipo)
        .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}