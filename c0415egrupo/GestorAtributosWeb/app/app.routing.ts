import { ModuleWithProviders }  from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AtributosComponent }     from './atributos.component';
import { AtributoDetailComponent } from './atributo-detail.component';

const appRoutes: Routes = [
  {
    path: '',
    redirectTo: '/atributos',
    pathMatch: 'full'
  },
  {
    path: 'detail/:id',
    component: AtributoDetailComponent
  },
  {
    path: 'atributos',
    component: AtributosComponent
  }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);


/*
Copyright 2016 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/