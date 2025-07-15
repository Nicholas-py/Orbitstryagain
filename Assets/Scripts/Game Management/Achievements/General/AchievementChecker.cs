using UnityEngine;

public abstract class AchievementChecker {
    protected int index;
    private bool completed = false;

    public GameObject popup;
    public AchievementsSetup parent;
    public abstract void SetUp();
    public abstract void CheckFor();

    public void Achieve() {
        if (!completed) {
            AchievementsData.completed[index] = 1;
            completed = true;
            AchievementsData.Save();
            GameEvents.achievementgotten?.Invoke(index);
        }
    }

}
