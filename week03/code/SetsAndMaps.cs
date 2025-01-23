using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // create a list to return the found pairs
        List<string> resultPairs = new List<string>();
        // create a set to store the words from the list
        HashSet<string> wordsSet = new HashSet<string>();

        foreach (string word in words){
            // first we check the letters in word are not the same
            if (word[0] == word[1]){
                continue; // we don't do anything in this round. Skip to next iteration
            }
            // reverse the current word
            string reversedWord = new string(new char[] { word[1], word[0] });
            // check if the reversed word exists in the set, in that case 
            // we add it to the result list
            if (wordsSet.Contains(reversedWord)){
                // we add the pair to the list 
                resultPairs.Add($"{word} & {reversedWord}");
            }
            else
            {
                // If the reversed word has not a pair in the set, we add the word to the set for a possible future match
                wordsSet.Add(word);
            }
        }
          
        return resultPairs.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // get the degree information in the fourth column of the file
            string degree = fields[3].Trim();
            // check if it exists in the dictionary
            if (degrees.ContainsKey(degree)){
                // increment the value for that degree
                degrees[degree]++;
            }
            // if it isn't in the dictionary, we add it and start it in 1
            else{
                degrees[degree] = 1;
            }


        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // we need to ignore any spaces and case, so we'll convert the words
        word1 = word1.ToLower().Replace(" ","");
        word2 = word2.ToLower().Replace(" ","");

        // we initialize the dictionary that will contain the count of letters in word1, which we'll use
        // to compare to the number of letters in word2
        var lettersChecker = new Dictionary<char, int>();
        // we check if the words have the same amount of letters. If not, return false and end of function
        if (word1.Length != word2.Length){ return false;}
        // we go thorugh each letter in word1 to count how many times is each letter in the word. 
        // If a letter are already in the dictionary, we sum 1. If they are not in the dictionary yet, we add them and assign value 1 to start counting
        foreach( char letter in word1){
            if (lettersChecker.ContainsKey(letter)){
                lettersChecker[letter]++;
            } else{
                lettersChecker[letter] = 1;
            }
        }
        // we go through word2 to see if they have the same letters with the same frequency
        foreach (char letter in word2){
            // if they have the same letter in the dictionary, we substract 1
            if(lettersChecker.ContainsKey(letter)){
                lettersChecker[letter]--;
            }
            // if that letter doesn't exist in the dictionary, we return false, the words are not anagrams
            else{
                return false;
            }
            // if at some point the count of each letter in the dictionary reaches a negative number, the words are not anagrams
            if (lettersChecker[letter] < 0) {
                return false;
            }
        }
        // if each and all the values in the dictionary are equal to 0, then the words are anagrams and true is returned
        return lettersChecker.Values.All(count => count == 0);
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    /// 
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        // we convert the JSON into an instance of the FeatureCollection class
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.

        //
        if (featureCollection == null || featureCollection.Features == null)
        {
            return []; // Return an empty array if there's no data from today's earthquakes
        }
        
        // create a list of strings of every place there's been an earthquake today
        var earthquakesSummary = new List<string>();
        foreach (var feature in featureCollection.Features){
            if (feature.Properties != null && feature.Properties.Place != ""){
                var summaryLine = $"{feature.Properties.Place} - Mag {feature.Properties.Mag}";
                // we add each line of information about each earthquake to the summary list
                earthquakesSummary.Add(summaryLine);
            }
        }

        return earthquakesSummary.ToArray();
    }
}