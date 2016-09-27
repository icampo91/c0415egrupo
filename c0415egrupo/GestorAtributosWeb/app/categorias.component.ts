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

  delete(categoria: Categoria): void {
      this.categoriaService
          .delete(categoria.id)
          .then(() => {
          this.categorias = this.categorias.filter(a => a !== categoria);
          if (this.selectedCategoria === categoria) { this.selectedCategoria = null; }
        });
  }

  ngOnInit(): void {
      this.getCategorias();
  }

  onSelect(categoria: Categoria): void {
      this.selectedCategoria = categoria;
  }

  gotoDetail(categoria: Categoria): void {
      this.router.navigate(['/detailCategoria', categoria.id]);
  }
}