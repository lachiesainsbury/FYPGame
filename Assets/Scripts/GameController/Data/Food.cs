using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public enum FoodType {
    Food, Seeds
}

public class Food {
    public FoodType foodType;

    [XmlAttribute("name")]
    public string name;

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

    [XmlElement("kJPer100g")]
    public string kJPer100g;

    [XmlElement("ContentPerServe")]
    public string contentPerServe;

    [XmlElement("RDI")]
    public string RDI;

    [XmlElement("Description")]
    public string description;
}
