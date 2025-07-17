using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickThroughAchievements : ClickThroughMenu {
    private int currentindex;

    [SerializeField]
    private int numberperpage; 

    private AchievementLoader loader;

    public override void Initialize() {
        
        loader = GetComponentInChildren<AchievementLoader>();
        loader.numberperpage = numberperpage;
        

        currentindex = 0;
        maxpages = (int)Mathf.Ceil(1.0f*AchievementsData.count/numberperpage);


    }

    public override void DisplayPage(int pagenumber) {
        currentindex = pagenumber*numberperpage;
        loader.UpdateButtons(currentindex);
    }
}

