using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;

public class DialougeSerializerScript 
{
    // Start is called before the first frame update
   public class DialougeDetails
    {
       public string Name { get; set; }
       public string Dialouge { get; set; }
       public int DialougeDestination { get; set; }
    }

     public void createXML(object obj, string filename)
    { using (var stream = new FileStream(filename, FileMode.Create))
        {
              var XML = new XmlSerializer(typeof(DialougeDetails));
              XML.Serialize(stream, obj);

        }
    }

     public DialougeDetails LoadDialogue(string filename)
    {   using (var stream = new FileStream(filename, FileMode.Open))
        {
              var XML = new XmlSerializer(typeof(DialougeDetails));
              return (DialougeDetails)XML.Deserialize(stream);

        }
       // TextReader reader = new StreamReader(@"D:\myXml.xml");
       // object obj = deserializer.Deserialize(reader);
       // DialougeDetails XmlData = (DialougeDetails)obj;
        //return XmlData;
       // reader.Close();
    }

   
}
