using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("DialogueCollection")]
public class DialogueContainer {

    [XmlArray("Dialogues"), XmlArrayItem("Dialogue")]
    public List<Dialogue> dialogues = new List<Dialogue>();

    public static DialogueContainer LoadFromXML(string path) {
        TextAsset xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(DialogueContainer));

        StringReader reader = new StringReader(xml.text);

        DialogueContainer dialogues = serializer.Deserialize(reader) as DialogueContainer;

        reader.Close();

        return dialogues;
    }
}
