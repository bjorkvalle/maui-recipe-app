namespace bjorkvalle.infrastructure.Utilities
{
    public static class Translations
    {
        public static Dictionary<string, Dictionary<string, string>> LanguageMap =>
            new()
            {
                {
                    Keys.Invitation.Title,
                    new Dictionary<string, string>
                    {
                        { Keys.Languages.Swedish, "Bröllopsinbjudan!" },
                        { Keys.Languages.English, "Wedding invitation!" },
                        { Keys.Languages.Romanian, "Invitație la cununia civilă!" }
                    }
                },
                {
                    Keys.Invitation.Description,
                    new Dictionary<string, string>
                    {
                        {
                            Keys.Languages.Swedish,
                            """
                            Välkomna till vår vigsel <strong>i rådhuset i Göteborg den 22 april</strong>. Ceremoni och lunch inom loppet av 1-2 timmar! 😲
                            
                            För den som kan, orkar och vill så blir det fika, aktiviteter och enklare middag hemma hos oss på kvällen sen.
                            🥔🥬🧄🍺🥳
                            """
                        },
                        {
                            Keys.Languages.English,
                            """
                            Welcome to our wedding <strong>at the courthouse in Gothenburg on April 22nd</strong>. Ceremony and lunch within the span of a few hours! 😲
                            
                            For those who are able, willing, and interested, we'll have fika, activities, and some simple dinner at our home in the evening.
                            🥔🥬🧄🍺🥳
                            """
                        },
                        {
                            Keys.Languages.Romanian,
                            """
                            <strong>Andreea & Eric - 22 aprilie 2023</strong>
                            
                            Cu mare bucurie vă invităm să ne fiți alături la cununia noastră civilă. Această zi este una specială pentru noi și suntem încântați să împărtășim acest moment important cu oamenii cei mai apropiați și dragi nouă. 
                            
                            Haideți să creăm împreună noi amintiri pline de emoție. 🥳
                            
                            Familia Björkvall ❤️
                            """
                        },
                    }
                },
                {
                    Keys.Invitation.Buttons.Schedule,
                    new Dictionary<string, string>
                    {
                        { Keys.Languages.Swedish, "Programmet" },
                        { Keys.Languages.English, "Schedule" },
                        { Keys.Languages.Romanian, "Program" },
                    }
                },
                {
                    Keys.Invitation.Buttons.Restaurant,
                    new Dictionary<string, string>
                    {
                        { Keys.Languages.Swedish, "Restaurangen" },
                        { Keys.Languages.English, "Restaurant (swe)" },
                        { Keys.Languages.Romanian, "Restaurant (swe)" },
                    }
                },
                {
                    Keys.Schedule.Title,
                    new Dictionary<string, string>
                    {
                        { Keys.Languages.Swedish, "När? Vad? Var?" },
                        { Keys.Languages.English, "When? What? Where?" },
                        { Keys.Languages.Romanian, "Unde? Ce? Când?" },
                    }
                },
                {
                    Keys.Schedule.Gathering,
                    new Dictionary<string, string>
                    {
                        { Keys.Languages.Swedish, "Samling" },
                        { Keys.Languages.English, "Gathering" },
                        { Keys.Languages.Romanian, "Întâlnire" },
                    }
                },
                {
                    Keys.Schedule.Ceremony,
                    new Dictionary<string, string>
                    {
                        { Keys.Languages.Swedish, "Ceremoni" },
                        { Keys.Languages.English, "Ceremony" },
                        { Keys.Languages.Romanian, "Ceremonie" },
                    }
                },
                {
                    Keys.Schedule.Lunch,
                    new Dictionary<string, string>
                    {
                        { Keys.Languages.Swedish, "Lunch" },
                        { Keys.Languages.English, "Lunch" },
                        { Keys.Languages.Romanian, "Prânz" },
                    }
                },
                {
                    Keys.Schedule.Coffee,
                    new Dictionary<string, string>
                    {
                        { Keys.Languages.Swedish, "Fika" },
                        { Keys.Languages.English, "Fika" },
                        { Keys.Languages.Romanian, "Fika" },
                    }
                },
                {
                    Keys.Schedule.Dinner,
                    new Dictionary<string, string>
                    {
                        { Keys.Languages.Swedish, "Middag" },
                        { Keys.Languages.English, "Dinner" },
                    }
                },
                {
                    Keys.Schedule.DinnerActivities,
                    new Dictionary<string, string>
                    {
                        { Keys.Languages.Swedish, "Middag + Aktiviteter" },
                        { Keys.Languages.English, "Dinner + Activities" },
                        { Keys.Languages.Romanian, "Cină + Activități" },
                    }
                },
                {
                    Keys.Schedule.Quiz,
                    new Dictionary<string, string>
                    {
                        { Keys.Languages.Swedish, "Quiz" },
                        { Keys.Languages.English, "Quiz" },
                        { Keys.Languages.Romanian, "Quiz" },
                    }
                },
                {
                    Keys.Schedule.AfternoonActivities,
                    new Dictionary<string, string>
                    {
                        { Keys.Languages.Swedish, "Fika, aktiviteter och middag" },
                        { Keys.Languages.English, "Fika, activities and dinner" },
                    }
                },
                {
                    Keys.Schedule.Unplanned,
                    new Dictionary<string, string>
                    {
                        { Keys.Languages.Swedish, "Oplanerat" },
                        { Keys.Languages.English, "Unplanned" },
                    }
                },
                {
                    Keys.Schedule.Courthouse,
                    new Dictionary<string, string>
                    {
                        { Keys.Languages.Swedish, "Rådhuset" },
                        { Keys.Languages.English, "Courthouse" },
                        { Keys.Languages.Romanian, "Primărie" },
                    }
                },
                {
                    Keys.Schedule.CourthouseSquare,
                    new Dictionary<string, string>
                    {
                        { Keys.Languages.Swedish, "Gustav Adolfs torg" },
                        { Keys.Languages.English, "Gustav Adolfs torg" },
                        { Keys.Languages.Romanian, "Piața Gustav Adolf" },
                    }
                },
                {
                    Keys.Schedule.OurPlace,
                    new Dictionary<string, string>
                    {
                        { Keys.Languages.Swedish, "Hemma hos oss" },
                        { Keys.Languages.English, "Our place" },
                        { Keys.Languages.Romanian, "Acasă la noi" },
                    }
                },
            };

        public static string GetValue(string key, string langKey)
        {
            if (LanguageMap.TryGetValue(key, out Dictionary<string, string> langDict))
            {
                if (string.IsNullOrEmpty(langKey))
                    langKey = "en";

                return langDict.GetValueOrDefault(
                    langKey,
                    $"{GetPlaceholder(langKey)}.{GetPlaceholder(key)}"
                );
            }
            return GetPlaceholder(key);
        }

        public static string GetPlaceholder(string key)
        {
            return $"[{key}]";
        }

        public static class Keys
        {
            public static class Invitation
            {
                public const string Title = $"{nameof(Invitation)}{nameof(Title)}";
                public const string Description = $"{nameof(Invitation)}{nameof(Description)}";

                public static class Buttons
                {
                    public const string Schedule =
                        $"{nameof(Invitation)}{nameof(Buttons)}{nameof(Schedule)}";
                    public const string Restaurant =
                        $"{nameof(Invitation)}{nameof(Buttons)}{nameof(Restaurant)}";
                }
            }

            public static class Album
            {
                public const string Title = $"{nameof(Album)}{nameof(Title)}";
                public const string Description = $"{nameof(Album)}{nameof(Description)}";
            }

            public static class Schedule
            {
                public const string Title = $"{nameof(Schedule)}{nameof(Title)}";
                public const string Description = $"{nameof(Schedule)}{nameof(Description)}";
                public const string Gathering = $"{nameof(Schedule)}{nameof(Gathering)}";
                public const string Ceremony = $"{nameof(Schedule)}{nameof(Ceremony)}";
                public const string Lunch = $"{nameof(Schedule)}{nameof(Lunch)}";
                public const string Coffee = $"{nameof(Schedule)}{nameof(Coffee)}";
                public const string Dinner = $"{nameof(Schedule)}{nameof(Dinner)}";
                public const string DinnerActivities = $"{nameof(Schedule)}{nameof(DinnerActivities)}";
                public const string Quiz = $"{nameof(Schedule)}{nameof(Quiz)}";
                public const string Unplanned = $"{nameof(Schedule)}{nameof(Unplanned)}";
                public const string AfternoonActivities = $"{nameof(Schedule)}{nameof(AfternoonActivities)}";
                public const string Courthouse = $"{nameof(Schedule)}{nameof(Courthouse)}";
                public const string CourthouseSquare = $"{nameof(Schedule)}{nameof(CourthouseSquare)}";
                public const string OurPlace = $"{nameof(Schedule)}{nameof(OurPlace)}";
            }

            public static class Languages
            {
                public const string Swedish = "se";
                public const string English = "en";
                public const string Romanian = "ro";
            }
        }
    }
}
