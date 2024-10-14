using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeRich : AchievementChecker {

    public override void SetUp() {
        index = 2;
        GameEvents.leavinglevel += OnSceneChange;

    }

    void OnSceneChange(string leavingscene) {
        CheckFor();
    }

    public override void CheckFor() {
        if (PlayerData.points > 100000) {
            Achieve();
        }
    }
}