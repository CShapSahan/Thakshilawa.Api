using System.Text;

namespace Application.Services
{
    public static class Setting
    {
        internal static string SecretKey = "FCAE7A85-4CFD-485D-8AC6-274D220D6874";
        public static byte[] GenerateSecretByte() => Encoding.ASCII.GetBytes(SecretKey);
    }
}
