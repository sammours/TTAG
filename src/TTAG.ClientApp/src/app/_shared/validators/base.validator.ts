import { IValidationRule } from './rules.validator';

export class Validator<T> {
    public errorMessages: string[];
    public isValid: boolean;
    public rules: IValidationRule[];

    constructor() {
        this.errorMessages = new Array<string>();
        this.isValid = true;
        this.rules = new Array<IValidationRule>();
    }

    public validate() {
        this.rules.forEach(rule => {
            rule.validate();
            if (!rule.isValid) {
                this.errorMessages.push(rule.errorMessage);
                this.isValid = false;
            }
        });
    }

    public getErrorMessages() {
        return this.errorMessages.join(', ');
    }
}
