using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("QuestCollection")]
public class QuestContainer {

    [XmlArray("Quests"), XmlArrayItem("Quest")]
    public List<Quest> quests = new List<Quest>();

    public static QuestContainer LoadFromXML(string path) {
        TextAsset xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(QuestContainer));

        StringReader reader = new StringReader(xml.text);

        QuestContainer quests = serializer.Deserialize(reader) as QuestContainer;

        reader.Close();

        return quests;
    }
}
