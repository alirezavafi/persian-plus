namespace Persian.Plus.Core.Extensions
{
    public static class NationalCodeExtensions
    {
        public static bool IsNationalCode(this string nationalCode)
        {
            if (string.IsNullOrWhiteSpace(nationalCode))
            {
                return false;
            }

            nationalCode = nationalCode.PadLeft(10, '0');

            const int nationalCodeLength = 10;
            if (nationalCode.Length != nationalCodeLength)
            {
                return false;
            }

            if (!nationalCode.IsNumber())
            {
                return false;
            }

            var j = nationalCodeLength;
            var sum = 0;
            for (var i = 0; i < nationalCode.Length - 1; i++)
            {
                sum += (int)char.GetNumericValue(nationalCode[i]) * j--;
            }

            var remainder = sum % 11;
            var controlNumber = (int)char.GetNumericValue(nationalCode[9]);
            return remainder < 2 && controlNumber == remainder ||
                   remainder >= 2 && controlNumber == 11 - remainder;
        }
    }
}