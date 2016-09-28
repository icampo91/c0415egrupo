import { Component, OnInit } from '@angular/core';
import { Router }            from '@angular/router';
import { Observable }        from 'rxjs/Observable';
import { Subject }           from 'rxjs/Subject';

import { AtributoSearchService } from './atributo-search.service';
import { Atributo } from './atributo';

@Component({
    moduleId: module.id,
    selector: 'atributo-search',
    templateUrl: 'atributo-search.component.html',
    styleUrls: ['atributo-search.component.css'],
    providers: [AtributoSearchService]
})
export class AtributoSearchComponent implements OnInit {
    atributos: Observable<Atributo[]>;
    private searchTerms = new Subject<string>();

    constructor(
        private atributoSearchService: AtributoSearchService,
        private router: Router) { }

    search(term: string): void {
        this.searchTerms.next(term);
    }

    ngOnInit(): void {
        this.atributos = this.searchTerms
            .debounceTime(300)
            .distinctUntilChanged()
            .switchMap(term => term
                ? this.atributoSearchService.search(term)
                : Observable.of<Atributo[]>([]))
            .catch(error => {
                console.log(error);
                return Observable.of<Atributo[]>([]);
            });
    }

    gotoDetail(atributo: Atributo): void {
        let link = ['/detail/v', atributo.id];
        this.router.navigate(link);
    }
}