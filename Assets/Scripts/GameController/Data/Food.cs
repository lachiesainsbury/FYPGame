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

    // Nutritional Info

    [XmlElement("Description")]
    public string description;
}
