
export class User {
    constructor(
        public id: number = 0,
        public firstName: string = "",
        public middleName: string = "",
        public lastName: string = "",
        public email: string = "",
        public password: string = "",
        public login: string = ""        
    ) { }
}