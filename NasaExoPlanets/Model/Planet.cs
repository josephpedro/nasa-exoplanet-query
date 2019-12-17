namespace NasaExoPlanets.Model
{
    using System.Net;
    using NasaExoplanetQuery.Settings;

    public class Planet
    {
        /// <summary>
        /// Host Name
        /// </summary>
        public string pl_hostname { get; set; }

        /// <summary>
        /// Planet Letter
        /// </summary>
        public string pl_letter { get; set; }

        /// <summary>
        /// Discovery Method
        /// </summary>
        public string pl_discmethod { get; set; }

        /// <summary>
        /// Discovery Facility
        /// </summary>
        public string pl_facility { get; set; }

        public string nasa_exoplanet_archive_details_link { get => string.Format("{0}{1}", Settings.OverviewPageLink, WebUtility.UrlEncode(this.pl_hostname)); }
    }
}
