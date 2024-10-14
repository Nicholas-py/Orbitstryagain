using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using TMPro.Examples;




public class LeveltxtReader
{

   public static void UpdateData (DataHolder dataholder, string filepath) {
        string text = dataholder.SelfToJson();
        File.WriteAllText(filepath, text);
        //Debug.Log(File.ReadAllText(filepath));

    }

    public static T ReadData <T>(string filepath) where T:DataHolder{
        T dataholder;
        if (filepath[0] == 'C' && filepath[1] == ':' && filepath[2] == '/') {
            dataholder = DataHolder.ReadFromText<T>(File.ReadAllText(filepath));

        }
        else {
            TextAsset file = Resources.Load(filepath) as TextAsset;
            dataholder = DataHolder.ReadFromFile<T>(file);
        }
        return dataholder;


    }


    public static string GetGlobalFilePath(string name) {
        string path = Application.persistentDataPath + "/" + name + ".txt";
        return path;

    }

    public static string GetLocalFilePath(string name) {
        return name; //Only for resources.Load()

    }



}
