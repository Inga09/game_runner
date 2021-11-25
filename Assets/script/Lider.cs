using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Lider : MonoBehaviour
{
    public List<Text> names;
    public Text playerName;
    public Text score;
    const string fileName = @"C:\Users\student\Desktop\8901_Afanaseva\dem_Afanaseva_8901\Assets\resources\Leaders.txt";
    private List<string> ReadFromTextFile()
    {
        List<string> lines = new List<string>();
        try
        {
            // Create a StreamReader  
            using (StreamReader reader = new StreamReader(fileName))
            {
                
                string line;
                // Read line by line  
                while ((line = reader.ReadLine()) != null)
                    lines.Add(line);
            }
        }
        catch (IOException exp)
        {
            throw exp;
        }
        return lines;
    }

    public void SetRecords()
    {
        List<string> records = ReadFromTextFile();
        int count = Mathf.Min(names.Count, records.Count);
        for (byte i = 0; i < count; i++)
        {
            names[i].text = records[i];
        }
    }

    public void SetFileRecords()
    {
        WriteTextFile(playerName.text, Ints(ScoreTrim(score.text)));
    }

    private int Ints(object ob)
    {
        return Convert.ToInt32(ob);
    }

    private string ScoreTrim(string record)
    {
        return record.Substring(record.LastIndexOf(" ") + 1);
    }

    private void WriteTextFile(string name, int score)
    {
        List<string> records = ReadFromTextFile();
        try
        {
            bool success = false;
            for (byte i = 0; i < records.Count; i++)
            {
                string playerScore = ScoreTrim(records[i]);
                int compareScore = Ints(playerScore);

                if (!success && score > compareScore)
                {
                    success = score < compareScore;
                    records[i] = $"{name} {score}";
                }
            }
            File.WriteAllLines(fileName, records);
            // Create a StreamReader  
        }
        catch (IOException exp)
        {
            throw exp;
        }
    }
}
