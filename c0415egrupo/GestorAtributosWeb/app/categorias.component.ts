import { Component, OnInit } from '@angular/core';
import { Router }            from '@angular/router';

import { Categoria }                from './categoria';
import { CategoriaService }         from './categoria.service';

@Component({
  moduleId: module.id,
  selector: 'my-categorias',
  templateUrl: 'categorias.component.html',
  styleUrls: [ 'categorias.component.css' ]
})
export class CategoriasComponent implements OnInit {
    categorias: Categoria[];
    selectedCategoria: Categoria;
    categoriaBorrar: Categoria;
    modalBorrar: boolean;

  constructor(
      private categoriaService: CategoriaService,
      private router: Router) { }


  getCategorias(): void {
      this.categoriaService
          .getCategorias()
          .then(categorias => this.categorias = categorias);
  }

  add(categoria: Categoria): void {
    if (!categoria) { return; }
    this.categoriaService.create(categoria)
        .then(categoria => {
        this.categorias.push(categoria);
        this.selectedCategoria = null;
      });
  }
  showBorrarModal(categoria: Categoria) {
      this.categoriaBorrar = categoria;
      this.modalBorrar = true;
  }
  cancelModal(): void {
      this.categoriaBorrar = null;
      this.modalBorrar = false;
  }

  delete(): void {
      this.categoriaService
          .delete(this.categoriaBorrar.id)
          .then(() => {
              this.categorias = this.categorias.filter(a => a !== this.categoriaBorrar);
              if (this.selectedCategoria === this.categoriaBorrar) { this.selectedCategoria = null; }
              this.modalBorrar = false;
        });
  }

  ngOnInit(): void {
      this.modalBorrar = false;
      this.getCategorias();
  }

  onSelect(categoria: Categoria): void {
      this.selectedCategoria = categoria;
  }

  gotoDetail(categoria: Categoria): void {
      this.router.navigate(['/detailCategoria', 'v', categoria.id]);
  }

  gotoModify(categoria: Categoria): void {
      this.router.navigate(['/detailCategoria', 'm', categoria.id]);
  }
  gotoCreate(): void {
      this.router.navigate(['/detailCategoria']);
  }
}