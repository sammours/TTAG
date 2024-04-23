import { Component, OnInit, ChangeDetectorRef, Inject } from '@angular/core';
import { Art, ArtCategory } from 'src/app/_core/services/service.generated';
import { ArtService } from './../../services/art.service';
import { ActivatedRoute } from '@angular/router';

@Component({
   selector: 'app-art-list',
   templateUrl: './art-list.component.html',
   styleUrls: ['./art-list.component.scss']
})
export class ArtListComponent implements OnInit {
   public displayedColumns: string[] = ['name', 'description', 'releaseYear', 'price', 'referenceUrl', 'category'];
   public arts: Array<Art>;
   public artCategory: ArtCategory;
   public isLoading = false;
   public term = '';
   public artName = '';
   
   constructor(private service: ArtService, private route: ActivatedRoute, private ref: ChangeDetectorRef) {
      this.arts = new Array<Art>();
   }

   ngOnInit(): void {
      this.route.queryParams.subscribe((params) => {
         if (params && params.term) {
            this.term = params.term;
            this.getArts();
         }
      });
   }

   public onFilterClicked() {
      this.getArts();
   }

   public onSearchClicked() {
      this.getArts();
   }

   private getArts() {
      this.isLoading = true;
      this.service.getAll().subscribe((result) => {
         this.arts = result;
         this.isLoading = false;
         this.ref.markForCheck();
      });
   }
}
