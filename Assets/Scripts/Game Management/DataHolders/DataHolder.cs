using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


[Serializable]
public abstract class DataHolder {
    public static T ReadFromFile<T>(TextAsset file) where T:DataHolder {
        string text = file.text;
        return ReadFromText<T>(text);

    }

    public static T ReadFromPath<T>(string path) where T:DataHolder {
        string text = File.ReadAllText(path);
        return ReadFromText<T>(text);

    }

    public static T ReadFromText<T>(string text) where T : DataHolder {
        T dataholder = JsonUtility.FromJson<T>(text);
        return dataholder;
    }

    public string SelfToJson() {
        return JsonUtility.ToJson(this);

    }
}
