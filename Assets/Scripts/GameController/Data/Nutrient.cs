using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class Nutrient {
    [XmlAttribute("name")]
    public string name;

    [XmlArray("Functions"), XmlArrayItem("Function")]
    public string[] functions;

    [XmlElement("Description")]
    public string description;

    [XmlArray("Foods"), XmlArrayItem("Food")]
    public NutrientFood[] foods;
}

public class NutrientFood {
    [XmlAttribute("name")]
    public string name;

    [XmlElement("kJPer100g")]
    public string kJPer100g;

    [XmlElement("ContentPerServe")]
    public string contentPerServe;

    [XmlElement("RDI")]
    public string RDI;
}
