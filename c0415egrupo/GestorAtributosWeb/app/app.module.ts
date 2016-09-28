import './rxjs-extensions';

import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { HttpModule }    from '@angular/http';

// Imports for loading & configuring the in-memory web api
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { InMemoryDataService }  from './in-memory-data.service';

import { AppComponent }         from './app.component';
import { AtributosComponent }      from './atributos.component';
import { AtributoDetailComponent }  from './atributo-detail.component';
import { AtributoCreateComponent }  from './atributo-create.component';
import { AtributoService }          from './atributo.service';

import { TipoService }          from './tipo.service';

import { CategoriasComponent }      from './categorias.component';
import { CategoriaDetailComponent }  from './categoria-detail.component';
import { CategoriaService }          from './categoria.service';

import { AtributoSearchComponent }  from './atributo-search.component';
import { AtributoSearchService }  from './atributo-search.service';


import { routing }              from './app.routing';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    routing
  ],
  declarations: [
    AppComponent,
    AtributoDetailComponent,
    AtributoCreateComponent,
    AtributosComponent,
    CategoriaDetailComponent,
    CategoriasComponent,
    AtributoSearchComponent,
  ],
  providers: [
      AtributoService,
      TipoService,
      CategoriaService,
      AtributoSearchService,
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule {
}