import { ModuleWithProviders }  from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AtributosComponent }     from './atributos.component';
import { AtributoDetailComponent } from './atributo-detail.component';
import { AtributoCreateComponent } from './atributo-create.component';

import { CategoriasComponent }     from './categorias.component';
import { CategoriaDetailComponent } from './categoria-detail.component';
import { CategoriaCreateComponent } from './categoria-create.component';


const appRoutes: Routes = [
  {
    path: '',
    redirectTo: '/atributos',
    pathMatch: 'full'
  },
  {
    path: 'detail',
    component: AtributoCreateComponent
  },
  {
    path: 'detail/:tipo/:id',
    component: AtributoDetailComponent
  },
  {
    path: 'atributos',
    component: AtributosComponent
  },
  {
      path: 'detailCategoria/:tipo/:id',
      component: CategoriaDetailComponent
  },
  {
      path: 'detailCategoria',
      component: CategoriaCreateComponent
  },
  {
      path: 'categorias',
      component: CategoriasComponent
  }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);
