namespace NasaExoplanetQuery.Settings
{
    using System;

    public static class Settings
    {
        private static ISettings current;

        public static ISettings Current
        {
            get
            {
                if (current == null)
                {
                    throw new InvalidOperationException("You need to configure the current Setting");
                }

                return current;
            }

            set => current = value;
        }

        public static string OverviewPageLink => Current.OverviewPageLink();
    }
}
