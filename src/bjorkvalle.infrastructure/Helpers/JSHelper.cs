namespace bjorkvalle.infrastructure.Helpers
{
    public static class JSHelper
    {
        public static class Functions
        {
            public static class LocalStorage
            {
                //public const string Get = "getItem";
                public const string Get = "localStorage.getItem";
                public const string Set = "localStorage.setItem";//"setItem";
                public const string Remove = "removeItem";
            }

            public static class BrowserStorage
            {
                public const string Get = "getBrowserItem";
                public const string Set = "setBrowserItem";
                public const string Remove = "removeBrowserItem";
            }

            public const string ScrollTo = "scrollTo";
            public const string FocusById = "focusById";
        }

        public static class StorageKeys
        {
            public static class Auth
            {
                public const string Token = "atoken";
            }

            public static class UI
            {
                public const string ProductsLocalConfig = "products-config";
                public const string Page = "page";
                public const string OrderForm = "orderForm";
            }
        }
    }
}
