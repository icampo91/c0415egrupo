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
