using Microsoft.AspNetCore.Components;

namespace bjorkvalle.infrastructure.Extensions
{
    public static class NavigationExtensions
    {
        /// <summary>
        /// get relative path
        /// </summary>
        /// <param name="nav"></param>
        /// <returns>RelativePath() => counter/3?q=hi</returns>
        public static string RelativePath(this NavigationManager nav) => nav.ToBaseRelativePath(nav.Uri);

        public static string Query(this NavigationManager nav) => new UriBuilder(nav.Uri).Query;

        /// <summary>
        /// e.g /aftonbladet/print
        /// </summary>
        /// <param name="nav"></param>
        /// <returns></returns>
        public static string Path(this NavigationManager nav) => new UriBuilder(nav.Uri).Path;

        public static string PathAndQuery(this NavigationManager nav) => Path(nav) + Query(nav);
    }
}
