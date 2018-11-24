import { ErrorHandler } from '@angular/core';

export class GlobalErrorHandler implements ErrorHandler {
    constructor() { }
    handleError(error: any): void {
        console.log(error);
        throw error;
    }

}