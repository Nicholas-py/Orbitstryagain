using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoFuelWin : AchievementChecker {

    public override void SetUp() {
        index = 0;
        GameEvents.flagreached += CheckFor;

    }

    public override void CheckFor() {
        if (GameStats.fuelleft <= 0) {
            Achieve();
        }
    }
}
