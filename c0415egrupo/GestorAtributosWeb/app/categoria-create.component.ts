import { Component, OnInit }      from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location }               from '@angular/common';

import { Categoria }        from './categoria';
import { CategoriaService } from './categoria.service';


@Component({
  moduleId: module.id,
  selector: 'my-hero-detail',
  templateUrl: 'categoria-detail.component.html',
  styleUrls: [ 'categoria-detail.component.css' ]
})
export class CategoriaCreateComponent implements OnInit {
    categoria: Categoria;
    modificar: boolean;
    modoCrear: boolean;
    faltanDatos: boolean;

  constructor(
    private categoriaService: CategoriaService,
    private route: ActivatedRoute,
    private location: Location
    ) { }


  ngOnInit(): void {
      this.modificar = true;
      this.faltanDatos = false;
      this.modoCrear = true;
      this.categoria = new Categoria();
  }

  save(): void {
      if (this.categoria && (this.categoria.nombre && this.categoria.nombre.trim() != "")){

          this.categoriaService.create(this.categoria)
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