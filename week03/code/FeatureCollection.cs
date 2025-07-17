public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary

    //Creating list to stores features like place and mag from the JSON doc.
    public List<Feature> Features { get; set; }
}

public class Feature
{
    //It's about the properties object in the JSON, we can find earthquake details 
    public Properties Properties { get; set; }
}

public class Properties
{
    //Variables to store places and magnitude of the earthquakes
    //Place: Location where the earthquake happened
    //Mag: Magnitude of the earthquake
    public string Place { get; set; }
    public double? Mag { get; set; }
}