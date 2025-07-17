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
        // TODO Problem 1 - ADD YOUR CODE HERE
        //Creating HashSet to store words we've seen
        var seen = new HashSet<string>();

        //Creating a List to store the final symmetric pairs
        var result = new List<string>();

        //Condition: foreach word in words
        foreach (var word in words)
        {
            //If words are the same, ignore it
            if (word[0] == word[1])
                continue;

            //Reverse the words
            string reversed = $"{word[1]}{word[0]}";

            //if we've seen reversed word, it's a synmetric pair
            if (seen.Contains(reversed))
            {
                result.Add($"{reversed} & {word}");
            }
            else
            {
                //Otherwise, store the current word in the set for future matching
                seen.Add(word);
            }
        }
        return result.ToArray();
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
        //Creating dictionary to store summary degrees
        var degrees = new Dictionary<string, int>();

        //Condition: Foreach line in the file
        foreach (var line in File.ReadLines(filename))
        {
            //split line into fields using ","
            var fields = line.Split(",");

            // TODO Problem 2 - ADD YOUR CODE HERE
            //Verify if line has at least 4 columms
            if (fields.Length >= 4)
            {
                //Get degree from the 4th columm (index 3)
                string degree = fields[3].Trim();

                //if degree exists in the dictionary, i++
                if (degrees.ContainsKey(degree))
                {
                    degrees[degree]++;
                }
                else
                {
                    //Otherwise, add it with initial count 1
                    degrees[degree] = 1;
                }
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
        // TODO Problem 3 - ADD YOUR CODE HERE
        //Clean both words: remove spaces and convert to lowercase
        string clean1 = word1.Replace(" ", "").ToLower();
        string clean2 = word2.Replace(" ", "").ToLower();

        //Condition: if size are different, they can't be anagrams
        if (clean1.Length != clean2.Length)
            return false;

        //Creating dictionary1: Counts letters in the first word
        var dictionary1 = new Dictionary<char, int>();
        foreach (char c in clean1)
        {
            if (dictionary1.ContainsKey(c))
                dictionary1[c]++;

            else
                dictionary1[c] = 1;
        }

        //Creating dicionary2: Counts letters in the second word
        var dictionary2 = new Dictionary<char, int>();
        foreach (char c in clean2)
        {
            if (dictionary2.ContainsKey(c))
                dictionary2[c]++;

            else
                dictionary2[c] = 1;
        }

        //Compare counts in both dictionaries
        if (dictionary1.Count != dictionary2.Count)
            return false;

        //Check each letter and its count
        foreach (var keyValuePair in dictionary1)
        {
            //If the letter is missing or the count is different, not an anagram
            if (!dictionary2.ContainsKey(keyValuePair.Key) || dictionary2[keyValuePair.Key] != keyValuePair.Value)
                return false;
        }
        return true;
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
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.

        //Condition: if there's no data, return empty array
        if (featureCollection?.Features == null)
        {
            return [];
        }

        //Variable to store result
        var result = new List<string>();

        //Condition: Foreach feature in featureCollection, get place and magnitute
        foreach (var feature in featureCollection.Features)
        {
            string place = feature.Properties.Place;
            double? mag = feature.Properties.Mag;

            //Avoid nulls
            if (!string.IsNullOrEmpty(place) && mag.HasValue)
            {
                result.Add($"{place} - Mag {mag.Value}");
            }
        }

        return result.ToArray();
    }
}