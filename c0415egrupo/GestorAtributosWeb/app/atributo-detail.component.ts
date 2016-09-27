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
export class AtributoDetailComponent implements OnInit {
    atributo: Atributo;
    tipos: Tipo[];
    categorias: Categoria[];
    modificar: boolean;
    modoCrear: boolean;

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
      this.atributo = new Atributo();

      this.route.params.forEach((params: Params) => {
        let tipo = params['tipo'];
        let id = +params['id'];        
        if (tipo == 'v') {
            this.modificar = false;
        }
        this.atributoService.getAtributo(id)
           .then(atributo => this.atributo = atributo);
      });
    this.getCategorias();
    this.getTipos();
  }

  save(): void {
      this.atributoService.update(this.atributo)
      .then(() => this.goBack());
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