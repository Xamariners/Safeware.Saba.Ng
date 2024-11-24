namespace Safeware.Saba.Ng.MasterEntities
{
    public static class MasterEntityConsts
    {
        private const string DefaultSorting = "{0}Name asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "MasterEntity." : string.Empty);
        }

    }
}