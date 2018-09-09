
export class User {
    constructor(
        public id: number = 0,
        public firstName: string = "",
        public secondName: string = "",
        public lastName: string = "",
        public email: string = "",
        public password: string = "",
        public userName: string = "",
        public identityId: string = ""
    ) { }
}