import { ToastrService } from 'ngx-toastr';
import { ArtClient, Art } from 'src/app/_core/services/service.generated';
import { ArtValidator } from '../validation/art.validator';
import { Observable, of } from 'rxjs';
import { Injectable } from '@angular/core';
import { map, catchError } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class ArtService {
    constructor(private client: ArtClient, private toaster: ToastrService) {}

    public getAll(): Observable<Art[]> {
        return this.client.getAll();
    }

    public add(art: Art): Observable<Art> {
        const validator = new ArtValidator(art);
        validator.validate();
        if (!validator.isValid) {
            this.toaster.error(validator.getErrorMessages(), 'Error', { enableHtml: true, timeOut: 7000 });
            return of<Art>();
        }

        return this.client.add(art).pipe(
            map(result => {
                this.toaster.success('Art added correctly', 'Success', { enableHtml: true, timeOut: 7000 });
                return result;
            })
            // ,
            // catchError(error => {
            //     this.toaster.error(error.message, 'Error', { enableHtml: true, timeOut: 7000 });
            // })
        );
    }
}
