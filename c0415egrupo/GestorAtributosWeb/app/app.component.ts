import { Component }          from '@angular/core';

@Component({
  selector: 'my-app',

  template: `
    <div class="container">
        <h1>{{title}}</h1>
        <nav>
          <a routerLink="/atributos" routerLinkActive="active">Atributos</a>
          <a routerLink="/categorias" routerLinkActive="active">Categorias</a>
        </nav>
        <router-outlet></router-outlet>
    </div>
  `,
  styleUrls: ['app/app.component.css']
})
export class AppComponent {
  title = 'Gestor de Atributos';
}


/*
Copyright 2016 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/