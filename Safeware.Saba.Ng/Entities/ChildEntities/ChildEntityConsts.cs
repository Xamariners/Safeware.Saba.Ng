namespace Safeware.Saba.Ng.ChildEntities
{
    public static class ChildEntityConsts
    {
        private const string DefaultSorting = "{0}Name asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ChildEntity." : string.Empty);
        }

    }
}