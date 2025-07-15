using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsSetup : MonoBehaviour
{
    private AchievementDataHolder dataholder = new();
    private void Start() {
        try {
            dataholder = LeveltxtReader.ReadData<AchievementDataHolder>(LeveltxtReader.GetGlobalFilePath("Achievements"));
        }
        catch (Exception) {
            LeveltxtReader.UpdateData(dataholder, LeveltxtReader.GetGlobalFilePath("Achievements"));
        }
        for (int i = 0; i < dataholder.values.Length; i++) {
            AchievementsData.completed[i] = dataholder.values[i];
        }

        for (int i = 0; i < AchievementList.instance.list.Count; i++) {

            if (0 == AchievementsData.completed[i]) { 
                string name = AchievementList.instance.list[i].classname;
                Type type = Type.GetType(name);

                var newboy = Activator.CreateInstance(type);
                if (newboy is AchievementChecker newboy2) {
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



