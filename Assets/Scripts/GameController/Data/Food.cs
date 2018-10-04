using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class Food {
    [XmlAttribute("name")]
    public string name;

    [XmlElement("FoodIcon")]
    public string foodIcon;

    [XmlElement("SeedIcon")]
    public string seedIcon;

    [XmlElement("Per100g")]
    public string per100g;

    [XmlElement("PerServe")]
    public string perServe;

    [XmlElement("RDI")]
    public string RDI;

    [XmlElement("Description")]
    public string description;
}
