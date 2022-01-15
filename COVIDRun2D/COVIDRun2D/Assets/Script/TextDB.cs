using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class TextDB : MonoBehaviour
{
    public static string ReadText(string path)
    {
        string word = File.ReadAllText(path);
        return word;
    }


    public static string ReadString(string path)
    {
       

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path); 
        Debug.Log(reader.ReadToEnd());
        reader.Close();

        return reader.ReadToEnd();
    }

    public static string[] ReadStringArray(string path)
    {
        string[] lines = File.ReadAllLines(path);  
  
        return lines;
    }

   public static void WriteString(string path,string text)
    {
     

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(text);
        writer.Close();

       
    }
    public static void WriteText(string path,string text)
    {
        using(StreamWriter writetext = new StreamWriter(path))
        {
            writetext.WriteLine(text);
            writetext.Close();
        }
    }

    public static void OverwriteText(string path ,string text)
    {
            File.WriteAllText (path, text);
    }
}
