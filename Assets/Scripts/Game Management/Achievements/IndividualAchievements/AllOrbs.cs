using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllOrbs : AchievementChecker {

    public override void SetUp() {
        index = 1;
        GameEvents.flagreached += CheckFor;

    }

    public override void CheckFor() {
        if (GameStats.orbsgrabbed == 3) {
            Achieve();
        }
    }
}


