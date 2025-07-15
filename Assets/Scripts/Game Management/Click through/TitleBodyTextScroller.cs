using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class TitleBodyTextScroller : ClickThroughMenu
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI text;

    // Must be a list of PageOfText jsons separated by semicolons
    public TextAsset jsondata;
    


    protected PageOfText currentpage;
    protected List<PageOfText> pages;

    public override void DisplayPage (int pagenumber) {
        currentpage = pages[pagenumber];
        title.text = currentpage.title;
        text.text = currentpage.text;
    }

    public override void Initialize() {
        pages = GetList<PageOfText>(jsondata.text);
        maxpages = pages.Count;
        currentpage = pages[0];
    }

    public static List<T> GetList<T>(string text) where T : DataHolder {
        string[] strings = text.Split(";");
        List<T> pages = new();
        foreach (string str in strings) {
            pages.Add(DataHolder.ReadFromText<T>(str));
        }
        return pages;
    }

}