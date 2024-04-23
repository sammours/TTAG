export interface IValidationRule {
    errorMessage: string;
    isValid: boolean;
    value: string;

    validate(): void;
}

export class IsNotOrEmptyRule implements IValidationRule {
    public errorMessage = '';
    public isValid = true;
    public value: string;

    constructor(value: string, errorMessage: string) {
        this.value = value;
        this.errorMessage = errorMessage;
    }
    public validate() {
        if (this.value == null || this.value === '') {
            this.isValid = false;
        }
    }
}

export class IsEmailRule implements IValidationRule {
    public errorMessage = '';
    public isValid = true;
    public value: string;
    constructor(value: string, errorMessage: string) {
        this.value = value;
        this.errorMessage = errorMessage;
    }
    public validate() {
        // check if valid email
    }
}

export class IsPhoneRule implements IValidationRule {
    public errorMessage = '';
    public isValid = true;
    public value: string;
    constructor(value: string, errorMessage: string) {
        this.value = value;
        this.errorMessage = errorMessage;
    }
    public validate() {
        // check if valid email
    }
}