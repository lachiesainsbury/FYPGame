using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class Food : Item {
    [XmlAttribute("name")]
    public string name;

    [XmlAttribute("buyable")]
    public bool buyable;

    [XmlArray("Categories"), XmlArrayItem("Nutrient")]
    public string[] categories;

    [XmlElement("FoodIcon")]
    public string foodIcon;

    [XmlElement("SeedIcon")]
    public string seedIcon;

    [XmlElement("GrowthStageOne")]
    public string growthStageOneTile;

    [XmlArray("GrowthStageTwo"), XmlArrayItem("GrowthTile")]
    public string[] growthStageTwoTiles;

    [XmlArray("GrowthStageThree"), XmlArrayItem("GrowthTile")]
    public string[] growthStageThreeTiles;

    [XmlArray("GrowthStageFour"), XmlArrayItem("GrowthTile")]
    public string[] growthStageFourTiles;

    [XmlElement("Description")]
    public string description;
}