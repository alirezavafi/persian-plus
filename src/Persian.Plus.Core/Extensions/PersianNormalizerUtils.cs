using Persian.Plus.Core.Extensions.Normalizer;
using Persian.Plus.Core.Internal;

namespace Persian.Plus.Core.Extensions
{
    public static class PersianNormalizerUtils
    {
        public static string NormalizePersianText(this string text, PersianNormalizers normalizers)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            if (normalizers.HasFlag(PersianNormalizers.ApplyPersianNumbers))
            {
                text = text.ToPersianNumbers();
            }

            if (!text.ContainsFarsi())
            {
                return text;
            }

            if (normalizers.HasFlag(PersianNormalizers.RemoveDiacritics))
            {
                text = text.RemoveDiacritics();
            }

            if (normalizers.HasFlag(PersianNormalizers.ApplyPersianYeKe))
            {
                text = text.ApplyCorrectYeKe();
            }

            if (normalizers.HasFlag(PersianNormalizers.ApplyHalfSpaceRule))
            {
                text = text.ApplyHalfSpaceRule();
            }

            if (normalizers.HasFlag(PersianNormalizers.CleanupZwnj))
            {
                text = text.NormalizeZwnj();
            }

            if (normalizers.HasFlag(PersianNormalizers.FixDashes))
            {
                text = text.NormalizeDashes();
            }

            if (normalizers.HasFlag(PersianNormalizers.ConvertDotsToEllipsis))
            {
                text = text.NormalizeDotsToEllipsis();
            }

            if (normalizers.HasFlag(PersianNormalizers.ConvertEnglishQuotes))
            {
                text = text.NormalizeEnglishQuotes();
            }

            if (normalizers.HasFlag(PersianNormalizers.CleanupExtraMarks))
            {
                text = text.NormalizeExtraMarks();
            }

            if (normalizers.HasFlag(PersianNormalizers.RemoveAllKashida))
            {
                text = text.NormalizeAllKashida();
            }

            if (normalizers.HasFlag(PersianNormalizers.CleanupSpacingAndLineBreaks))
            {
                text = text.NormalizeSpacingAndLineBreaks();
            }

            if (normalizers.HasFlag(PersianNormalizers.RemoveOutsideInsideSpacing))
            {
                text = text.NormalizeOutsideInsideSpacing();
            }

            if (normalizers.HasFlag(PersianNormalizers.RemoveHexadecimalSymbols))
            {
                text = text.RemoveHexadecimalSymbols();
            }

            return text;
        }
    }
}