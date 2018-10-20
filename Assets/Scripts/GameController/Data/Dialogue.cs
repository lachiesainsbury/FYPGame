using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class Dialogue {
    [XmlAttribute("NPC")]
    public string NPC;

    [XmlElement("QuestOffer")]
    public string questOffer;

    [XmlElement("QuestInProgress")]
    public string questInProgress;

    [XmlElement("QuestHandIn")]
    public string questHandIn;

    public static string questConflict = "You already have a quest. Come see me when you've finished it!";

    public static string questCompleted = "Thanks again for your help! Check in with some other town members" + 
                                          " and see if they need a hand.";
}
