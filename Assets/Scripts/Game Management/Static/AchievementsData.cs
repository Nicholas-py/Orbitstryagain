

public class AchievementsData {
    public const int count = GlobalData.achievementscount;
    public static int mostrecent;


    public static int[] completed = new int[count] { 0,0,0 };

    public static void Save() {
        AchievementDataHolder dataholder = new AchievementDataHolder();
        dataholder.values = completed;
        LeveltxtReader.UpdateData(dataholder, LeveltxtReader.GetGlobalFilePath("Achievements"));
    }
}
