using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsSetup : MonoBehaviour
{
    private AchievementDataHolder dataholder = new AchievementDataHolder();
    private void Start() {

        try {
            AchievementDataHolder dataholder = LeveltxtReader.ReadData<AchievementDataHolder>(LeveltxtReader.GetGlobalFilePath("Achievements"));
        }
        catch {
            LeveltxtReader.UpdateData(dataholder, LeveltxtReader.GetGlobalFilePath("Achievements"));
        }
        for (int i = 0; i < dataholder.values.Length; i++) {
            AchievementsData.completed[i] = dataholder.values[i];
        }

        for (int i = 0; i < AchievementsData.achievements.Length; i++) {

            if (!AchievementsData.completed[i]) { 
                string name = AchievementsData.achievements[i];
                Type type = Type.GetType(name);

                var newboy = Activator.CreateInstance(type);
                if (newboy is AchievementChecker) {
                    AchievementChecker newboy2 = (AchievementChecker)newboy;
                    newboy2.parent = this;
                    newboy2.SetUp();
                }

                else {
                    throw new Exception("Nonexistent achievement type");
                }
            }
        }

    }

}



