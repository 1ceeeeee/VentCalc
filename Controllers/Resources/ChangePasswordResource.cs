namespace VentCalc.Controllers.Resources
{
    public class ChangePasswordResource
    {
        public string Id { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}