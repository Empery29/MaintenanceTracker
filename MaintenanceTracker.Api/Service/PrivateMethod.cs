namespace MaintenanceTracker.Api.Service
{
    public class PrivateMethod
    {
        private static readonly Random _random = new Random();

        public static string GenerateRequestTrackingNumber()
        {
            string prefix = "MAIN";
            string datePart = DateTime.UtcNow.ToString("yyyyMMdd"); // e.g., 20250826
            string uniquePart = GenerateRandomAlphaNumericWithSymbols(8); // 8 chars with letters, numbers, symbols

            return $"{prefix}-{datePart}-{uniquePart}";
        }

        private static string GenerateRandomAlphaNumericWithSymbols(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*";
            return new string(Enumerable.Repeat(chars, length)
                                        .Select(s => s[_random.Next(s.Length)])
                                        .ToArray());
        }

       

        }

}
