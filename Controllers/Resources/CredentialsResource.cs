namespace VentCalc.Controllers.Resources
{
    public class CredentialsResource
    {
        public string UserName { get; set; }
        public string Password { get; set; } 
        public string Auth_token {get;set;}
        public int Expires_in {get;set;}
        public string Id { get; set; }
    }
}