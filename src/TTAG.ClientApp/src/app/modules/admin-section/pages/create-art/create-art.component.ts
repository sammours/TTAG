import { Component, OnInit, Inject } from '@angular/core';
import { Art, ArtCategory, Address } from 'src/app/_core/services/service.generated';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ArtService } from 'src/app/modules/art-section/services/art.service';

@Component({
   selector: 'app-create-art',
   templateUrl: './create-art.component.html',
   styleUrls: ['./create-art.component.scss']
})
export class CreateArtComponent implements OnInit {
   art: Art;
   address: Address;
   formArt: FormGroup;
   artCategory: Array<string> = Object.keys(ArtCategory).filter((key) => isNaN(+key));

   ngOnInit(): void {
      this.art = new Art();
      this.address = new Address();
   }

   constructor(private formBuilder: FormBuilder, private service: ArtService) {
      this.formArt = this.formBuilder.group({
         name: [null, Validators.required],
         referenceUrl: [null],
         description: [null],
         price: [0],
         releaseYear: [null],
         artCategory: [null],
         country: [null],
         city: [null],
         postalCode: [null],
         street2: [null],
         street1: [null]
      });
   }

   onSubmit(): void {
      this.art.name = this.formArt.get('name').value;
      this.art.description = this.formArt.get('description').value;
      this.art.referenceUrl = this.formArt.get('referenceUrl').value;
      this.art.price = +this.formArt.get('price').value;
      this.art.releaseYear = +new Date(this.formArt.get('releaseYear').value).getFullYear();
      //this.art.category = this.formArt.get('artCategory').value;
      this.address.street1 = this.formArt.get('street1').value;
      this.address.street2 = this.formArt.get('street2').value;
      this.address.country = this.formArt.get('country').value;
      this.address.city = this.formArt.get('city').value;
      this.address.postalCode = this.formArt.get('postalCode').value;
      this.service.add(this.art).subscribe((res) => {
         console.log(res);
         this.formArt.reset;
      });
   }
}
