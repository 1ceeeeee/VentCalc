import { FormGroup } from '@angular/forms';

export class PasswordValidator {

    static validate(registrationFormGroup: FormGroup) {
        let password = registrationFormGroup.controls.password.value;
        let repeatPassword = registrationFormGroup.controls.repeatPassword.value;

        if (repeatPassword.length <= 0) {
            return null;
        }

        if (repeatPassword !== password) {

            return {
                notMatchPassword: true
            };
        }

        return null;

    }
}
