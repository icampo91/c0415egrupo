import { ModuleWithProviders }  from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AtributosComponent }     from './atributos.component';
import { AtributoDetailComponent } from './atributo-detail.component';

import { CategoriasComponent }     from './categorias.component';
import { CategoriaDetailComponent } from './categoria-detail.component';

const appRoutes: Routes = [
  {
    path: '',
    redirectTo: '/atributos',
    pathMatch: 'full'
  },
  {
    path: 'detail/:tipo/:id',
    component: AtributoDetailComponent
  },
  {
      path: 'detail',
      component: AtributoDetailComponent
  },
  {
    path: 'atributos',
    component: AtributosComponent
  },
  {
      path: 'detailCategoria/:id',
      component: CategoriaDetailComponent
  },
  {
      path: 'categorias',
      component: CategoriasComponent
  }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);


/*
Copyright 2016 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/