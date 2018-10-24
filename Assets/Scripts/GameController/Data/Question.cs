using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class Question {
    [XmlAttribute("value")]
    public string value;

    [XmlArray("Options"), XmlArrayItem("Option")]
    public Option[] options;
}

public class Option {
    [XmlAttribute("value")]
    public string value;

    [XmlAttribute("response")]
    public string response;

    [XmlAttribute("correct")]
    public string correct;
}
