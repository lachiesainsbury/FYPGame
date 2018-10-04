using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("NutrientCollection")]
public class NutrientContainer {

    [XmlArray("Nutrients"), XmlArrayItem("Nutrient")]
    public List<Nutrient> nutrients = new List<Nutrient>();

    public static NutrientContainer LoadFromXML(string path) {
        TextAsset xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(NutrientContainer));

        StringReader reader = new StringReader(xml.text);

        NutrientContainer nutrients = serializer.Deserialize(reader) as NutrientContainer;

        reader.Close();

        return nutrients;
    }
}
