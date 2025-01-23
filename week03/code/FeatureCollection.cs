using System.ComponentModel;

// the collection we'll deserialize
public class FeatureCollection
{
    public List<Feature> Features { get; set; }
}

// every singular pair of location and magnitude
public class Feature
{
    public Properties Properties {get; set;}
}

// we'll need a list of places and magnitudes
public class Properties
{
    public string Place {get; set;}
    public double Mag { get; set;}
}