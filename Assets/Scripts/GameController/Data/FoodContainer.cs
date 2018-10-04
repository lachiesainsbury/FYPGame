using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("FoodCollection")]
public class FoodContainer {

    [XmlArray("Foods"), XmlArrayItem("Food")]
    public List<Food> foods = new List<Food>();

    public static FoodContainer LoadFromXML(string path) {
        TextAsset xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(FoodContainer));

        StringReader reader = new StringReader(xml.text);

        FoodContainer foods = serializer.Deserialize(reader) as FoodContainer;

        reader.Close();

        return foods;
    }
}
