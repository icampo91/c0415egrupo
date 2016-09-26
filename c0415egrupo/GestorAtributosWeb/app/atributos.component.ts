import { Component, OnInit } from '@angular/core';
import { Router }            from '@angular/router';

import { Atributo }                from './atributo';
import { Tipo }                    from './tipo';
import { Categoria }                from './categoria';
import { AtributoService }         from './atributo.service';
import { TipoService }         from './tipo.service';
import { CategoriaService }         from './categoria.service';

@Component({
  moduleId: module.id,
  selector: 'my-atributos',
  templateUrl: 'atributos.component.html',
  styleUrls: [ 'atributos.component.css' ]
})
export class AtributosComponent implements OnInit {
    atributos: Atributo[];
    tipos: Tipo[];
    categorias: Categoria[];
    selectedAtributo: Atributo;

  constructor(
      private atributoService: AtributoService,
      private tipoService: TipoService,
      private categoriaService: CategoriaService,
      private router: Router) { }

  getAtributos(): void {
    this.atributoService
        .getAtributos()
        .then(atributos => this.atributos = atributos);
  }

  getTipos(): void {
      this.tipoService
          .getTipos()
          .then(tipos => this.tipos = tipos);
  }

  getCategorias(): void {
      this.categoriaService
          .getCategorias()
          .then(categorias => this.categorias = categorias);
  }

  add(atributo: Atributo): void {
    if (!atributo) { return; }
    this.atributoService.create(atributo)
        .then(atributo => {
        this.atributos.push(atributo);
        this.selectedAtributo = null;
      });
  }

  delete(atributo: Atributo): void {
      this.atributoService
          .delete(atributo.IdAtributo)
          .then(() => {
          this.atributos = this.atributos.filter(a => a !== atributo);
          if (this.selectedAtributo === atributo) { this.selectedAtributo = null; }
        });
  }

  ngOnInit(): void {
      this.getAtributos();
      this.getTipos();
      this.getCategorias();
  }

  onSelect(atributo: Atributo): void {
      this.selectedAtributo = atributo;
  }

  gotoDetail(): void {
      this.router.navigate(['/detail', this.selectedAtributo.IdAtributo]);
  }
}