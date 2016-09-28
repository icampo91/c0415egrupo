import { Component, OnInit }      from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location }               from '@angular/common';

import { Categoria }        from './categoria';
import { CategoriaService } from './categoria.service';

@Component({
  moduleId: module.id,
  selector: 'my-categoria-detail',
  templateUrl: 'categoria-detail.component.html',
  styleUrls: [ 'categoria-detail.component.css' ]
})
export class CategoriaDetailComponent implements OnInit {
    categoria: Categoria;
    categoriaBorrar: Categoria;
    modificar: boolean;
    modoCrear: boolean;
    faltanDatos: boolean;
    modalBorrar: boolean;

  constructor(
    private categoriaService: CategoriaService,
    private route: ActivatedRoute,
    private location: Location
  ) {}

  ngOnInit(): void {
      this.modificar = true;
      this.faltanDatos = false;
      this.modalBorrar = false;
      this.modoCrear = false;
      this.categoria = new Categoria();

      this.route.params.forEach((params: Params) => {
        let tipo = params['tipo'];
        let id = +params['id'];
        if (tipo == 'v') {
            this.modificar = false;
        }
      this.categoriaService.getCategoria(id)
          .then(categoria => this.categoria = categoria);
    });
  }

  save(): void {
      if (this.categoria.nombre.trim() == "" ) {
          this.faltanDatos = true;
      } else {
          this.categoriaService.update(this.categoria)
              .then(() => this.goBack());
      }
  }

  showBorrarModal(categoria: Categoria): void {
      this.categoriaBorrar = categoria;
      this.modalBorrar = true;
  }
  cancelModal(): void {
      this.categoriaBorrar = null;
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