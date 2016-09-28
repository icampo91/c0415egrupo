import { Component, OnInit }      from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location }               from '@angular/common';

import { Atributo }        from './atributo';
import { Tipo }        from './tipo';
import { Categoria }        from './categoria';
import { AtributoService } from './atributo.service';
import { TipoService } from './tipo.service';
import { CategoriaService } from './categoria.service';

@Component({
  moduleId: module.id,
  selector: 'my-hero-detail',
  templateUrl: 'atributo-detail.component.html',
  styleUrls: [ 'atributo-detail.component.css' ]
})
export class AtributoCreateComponent implements OnInit {
    atributo: Atributo;
    tipos: Tipo[];
    categorias: Categoria[];
    modificar: boolean;
    modoCrear: boolean;
    faltanDatos: boolean;

  constructor(
      private atributoService: AtributoService,
      private tipoService: TipoService,
      private categoriaService: CategoriaService,
    private route: ActivatedRoute,
    private location: Location
    ) { }

  getCategorias(): void {
      this.categoriaService
          .getCategorias()
          .then(categorias => this.categorias = categorias);
  }

  getTipos(): void {
      this.tipoService
          .getTipos()
          .then(tipos => this.tipos = tipos);
  }

  ngOnInit(): void {
      this.modificar = true;
      this.faltanDatos = false;
      this.modoCrear = true;
      this.atributo = new Atributo();
    this.getCategorias();
    this.getTipos();
  }

  save(): void {
      if (this.atributo &&
          (this.atributo.nombre && this.atributo.nombre.trim() != "") &&
          (this.atributo.codigo && this.atributo.codigo.trim() != "") &&
          (this.atributo.descripcion && this.atributo.descripcion.trim() != "") &&
          this.atributo.categoriaID && this.atributo.tipoID) {

          this.atributoService.create(this.atributo)
              .then(() => this.goBack());
            
      } else {
          this.faltanDatos = true;
      }
  }

  cancelModal(): void {
      this.faltanDatos = false;
  }

  goBack(): void {
    this.location.back();
  }
}


/*
Copyright 2016 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/