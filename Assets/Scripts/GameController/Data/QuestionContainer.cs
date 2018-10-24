using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("QuestionCollection")]
public class QuestionContainer {

    [XmlArray("Questions"), XmlArrayItem("Question")]
    public List<Question> questions = new List<Question>();

    public static QuestionContainer LoadFromXML(string path) {
        TextAsset xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(QuestionContainer));

        StringReader reader = new StringReader(xml.text);

        QuestionContainer questions = serializer.Deserialize(reader) as QuestionContainer;

        reader.Close();

        return questions;
    }
}
