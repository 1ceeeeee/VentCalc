export class Credentials {
    constructor(
        public userName: string = "",
        public password: string = "",
        public auth_token: string ="",
        public expires_in: number = 0,
        public id: string = "",
        public roles: string[] = []
    ) { }
}