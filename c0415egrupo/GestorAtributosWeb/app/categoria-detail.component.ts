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
export class CategoriaDetailComponent implements OnInit {
  categoria: Categoria;

  constructor(
    private categoriaService: CategoriaService,
    private route: ActivatedRoute,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.route.params.forEach((params: Params) => {
      let id = +params['id'];
      this.categoriaService.getCategoria(id)
          .then(categoria => this.categoria = categoria);
    });
  }

  save(): void {
      this.categoriaService.update(this.categoria)
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