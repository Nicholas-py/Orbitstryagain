public class Achievement {
    public int index;
    public string name;
    public string prettyname;
    public string description;
}


public class AchievementsData {
    public const int count = 3;
    public static int mostrecent;

    public static string[] achievements = new string[count] { "NoFuelWin", "AllOrbs", "BeRich" };
    public static string[] prettyachievements = new string[count] { "No fuel win", "3 Orb Game", "Be Rich"};
    public static string[] description = new string[count] { "Win a game with no fuel remaining", "Collect all 3 orbs in a level", "Have 100 000 points at once" };


    public static bool[] completed = new bool[count] { false, false, false };

    public static void Save() {
        AchievementDataHolder dataholder = new AchievementDataHolder();
        dataholder.values = completed;
        LeveltxtReader.UpdateData(dataholder, LeveltxtReader.GetGlobalFilePath("Achievements"));
    }
}
