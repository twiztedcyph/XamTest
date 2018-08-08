namespace FCA.Helpers
{
    public static class StringHelper
    {
        public static string RemoveQuotes(string target, string quoteString)
        {
            target = target.Trim();
            if (target.StartsWith(quoteString) && target.EndsWith(quoteString))
            {
                target = target.Substring(1, target.Length - 2);
            }
            return target;
        }

        public static string AddQuotes(string target, string quoteString)
        {
            target = target.Trim();
            if (!target.StartsWith(quoteString))
                target = quoteString + target;
            if (!target.EndsWith(quoteString))
                target += quoteString;
            return target;
        }
    }
}
