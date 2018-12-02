using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public enum QuestStatus {
    NotStarted,
    InProgress,
    Completed
}

public class Quest {
    public QuestStatus questStatus;

    [XmlAttribute("name")]
    public string name;

    [XmlElement("QuestNPC")]
    public string questNPC;

    [XmlArray("QuestItems"), XmlArrayItem("QuestItem")]
    public string[] questItems;

    [XmlElement("ItemAmount")]
    public int itemAmount;
}
