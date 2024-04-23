import { Art } from 'src/app/_core/services/service.generated';
import { Validator } from 'src/app/_shared/validators/base.validator';
import { IsNotOrEmptyRule } from 'src/app/_shared/validators/rules.validator';

export class ArtValidator extends Validator<Art> {
    constructor(art: Art) {
        super();
        this.rules.push(new IsNotOrEmptyRule(art.name, 'Name is required'));
    }
}
