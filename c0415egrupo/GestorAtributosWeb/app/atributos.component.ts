import { Component, OnInit } from '@angular/core';
import { Router }            from '@angular/router';

import { Atributo }                 from './atributo';
import { Tipo }                     from './tipo';
import { Categoria }                from './categoria';
import { AtributoService }          from './atributo.service';
import { TipoService }              from './tipo.service';
import { CategoriaService }         from './categoria.service';
import { AtributoSearchService }    from './atributo-search.service';


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
    atributoBorrar: Atributo;
    modalBorrar: boolean;

  constructor(
      private atributoService: AtributoService,
      private tipoService: TipoService,
      private categoriaService: CategoriaService,
      private atributoSearchService: AtributoSearchService,
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

  showBorrarModal(atributo: Atributo) {
      this.atributoBorrar = atributo;
      this.modalBorrar = true;
  }

  add(atributo: Atributo): void {
    if (!atributo) { return; }
    this.atributoService.create(atributo)
        .then(atributo => {
        this.atributos.push(atributo);
        this.selectedAtributo = null;
      });
  }

  delete(): void {
      this.atributoService
          .delete(this.atributoBorrar.id)
          .then(() => {
          this.atributos = this.atributos.filter(a => a !== this.atributoBorrar);
          if (this.selectedAtributo === this.atributoBorrar) { this.selectedAtributo = null; }
          this.modalBorrar = false;
        });
  }

  ngOnInit(): void {
      this.modalBorrar = false;
      this.getAtributos();
      this.getTipos();
      this.getCategorias();
  }

  filtrar(codigo: string) {
      this.atributoSearchService
          .filter(codigo)
          .then(atributos => this.atributos = atributos);
  }

  cancelModal(): void {
      this.atributoBorrar = null;
      this.modalBorrar = false;
  }

  onSelect(atributo: Atributo): void {
      this.selectedAtributo = atributo;
  }

  gotoDetail(atributo: Atributo): void {
      this.router.navigate(['/detail','v',atributo.id]);
  }

  gotoModify(atributo: Atributo): void {
      this.router.navigate(['/detail', 'm', atributo.id]);
  }

  gotoCreate(): void {
      this.router.navigate(['/detail']);
  }
}