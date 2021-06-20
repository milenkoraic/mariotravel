namespace DubrovnikTours.Web.App.Infrastructure.TextModification
{
    public static class StringExtensions
    {
        public static string UppercaseFirstLetter(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            var strChars = str.ToCharArray();
            strChars[0] = char.ToUpper(strChars[0]);

            return new string(strChars);
        }
    }
}