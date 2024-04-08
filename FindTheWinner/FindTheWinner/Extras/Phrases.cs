namespace FindTheWinner.Extras
{
    public static class Phrases
    {
        public static string[] Greetings = {
            "Alright, mate!",
            "How's it going, old chap?",
            "'Ello, guv'nor!",
            "Hiya, mate!",
            "Alright, matey!",
            "'Morning, sunshine!",
            "How do you do, old bean?",
            "'Ello, matey!",
            "Hey there, chief!",
            "How's the day treating ya, mate?"
        };

        public static string[] Goodbyes =
        {
            "Cheerio, mate!",
            "Toodle-oo, old chap!",
            "Ta-ta for now!",
            "See you later, mate!",
            "Catch you later, matey!",
            "'Night, sunshine!",
            "Farewell, old bean!",
            "Take care, mate!",
            "Goodbye, chief!",
            "'Til we meet again, mate!"
        };

        public static string[] NothingFound =
        {
            "Nothing found.",
            "No results found.",
            "Sorry, nothing matched your search.",
            "We couldn't find anything.",
            "Looks like there's nothing here.",
            "Unfortunately, no matches were found.",
            "Regrettably, nothing was found.",
            "Alas, nothing was discovered.",
            "Sorry, but there are no results.",
            "It appears that nothing has been found."
        };

        public static string[] SomethingFound =
        {
            "Alright mate, there are some!",
            "Hey buddy, we found some!",
            "Hey friend, yep, there are some!",
            "Looks like we've got some, mate!",
            "Ah, there are some, buddy!",
            "Indeed, there are some, friend!",
            "Yes, we found some, mate!",
            "Great news, there are some, buddy!",
            "Hooray, there are some, friend!",
            "Fantastic, there are some, mate!"
        };


        public static string[] FetchingWinners =
        {
            "Attempting to fetch winners from their website...",
            "Fetching winners from their site...",
            "Trying to retrieve winners from their website...",
            "Loading the list of winners...",
            "Fetching the list of winners...",
            "Attempting to load winners from their website...",
            "Retrieving winners from their site...",
            "Trying to fetch the list of winners...",
            "Loading winners from their website...",
            "Retrieving the list of winners..."
        };

        public static string[] FetchingCsv = {
            "Going through your addresses from the CSV file you've provided, mate...",
            "Checking out addresses from the CSV file you've given me, guv'nor...",
            "Having a butcher's at the addresses from the CSV file you've provided, mate...",
            "Scanning the addresses from the CSV file you've given me, matey...",
            "Having a gander at the addresses from the CSV file you've provided, mate...",
            "Taking a look at addresses from the CSV file you've given me, matey...",
            "Sorting out addresses from the CSV file you've provided, mate...",
            "Having a squiz at the addresses from the CSV file you've given me, matey...",
            "Going through the addresses from the CSV file you've provided, mate...",
            "Checking out the addresses from the CSV file you've given me, mate..."
        };

        public static string Random(this string[] array)
        {
            if (array == null || array.Length == 0)
                throw new ArgumentException("The array must not be null or empty.", nameof(array));

            int randomIndex = new Random().Next(0, array.Length);
            return array[randomIndex];
        }
    }
}
