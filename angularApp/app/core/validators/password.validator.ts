import { FormGroup } from '@angular/forms';

export class PasswordValidator {

    static validate(registrationFormGroup: FormGroup) {
        let password = registrationFormGroup.controls.password.value;
        let repeatPassword = registrationFormGroup.controls.repeatPassword.value;
 
        if (repeatPassword.length <= 0) {
            return null;
        }
        console.log(password);
        console.log(repeatPassword);
        if (repeatPassword !== password) {
            console.log('passwordCheck !== password');
            return {
                notMatchPassword: true
            };
        }
 
        return null;
 
    }
}
