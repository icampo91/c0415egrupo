import { Component, OnInit }      from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location }               from '@angular/common';

import { Atributo }        from './atributo';
import { AtributoService } from './atributo.service';

@Component({
  moduleId: module.id,
  selector: 'my-hero-detail',
  templateUrl: 'atributo-detail.component.html',
  styleUrls: [ 'atributo-detail.component.css' ]
})
export class AtributoDetailComponent implements OnInit {
  atributo: Atributo;

  constructor(
    private atributoService: AtributoService,
    private route: ActivatedRoute,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.route.params.forEach((params: Params) => {
      let id = +params['id'];
      this.atributoService.getAtributo(id)
          .then(atributo => this.atributo = atributo);
    });
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