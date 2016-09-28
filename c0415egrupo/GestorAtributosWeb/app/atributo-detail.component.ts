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
  selector: 'my-atributo-detail',
  templateUrl: 'atributo-detail.component.html',
  styleUrls: [ 'atributo-detail.component.css' ]
})
export class AtributoDetailComponent implements OnInit {
    atributo = new Atributo();
    tipos: Tipo[];
    categorias: Categoria[];
    atributoBorrar: Atributo;
    modificar: boolean;
    modoCrear: boolean;
    faltanDatos: boolean;
    modalBorrar: boolean;

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
      this.modalBorrar = false;
      this.modoCrear = false;
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
      if (this.atributo.nombre.trim() == "" || this.atributo.codigo.trim() == "" || this.atributo.descripcion.trim() == "") {
          this.faltanDatos = true;
      } else {
          this.atributoService.update(this.atributo)
              .then(() => this.goBack());
      }
  }

  showBorrarModal(atributo: Atributo): void {
      this.atributoBorrar = atributo;
      this.modalBorrar = true;
  }

  delete(): void {
      this.atributoService
          .delete(this.atributoBorrar.id)
          .then(() => {
              if (this.atributo === this.atributoBorrar) { this.atributo = null; }
              this.modalBorrar = false;
              this.goBack();
          });
  }

  cancelModal(): void {
      this.atributoBorrar = null;
      this.modalBorrar = false;
  }

  modoModificar(): void {
      this.modificar = true;
  }

  modoVisualizar(): void {
      this.modificar = false;
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