using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelCreator : MonoBehaviour {
    public int levelnumber;
    private string filepath;

    public bool unlocked = false;

    void Awake() {
        if (GameStats.level != 0) {
            levelnumber = GameStats.level;
            filepath = GetFilepath();
            CreateLevel(LeveltxtReader.ReadData<LevelDataHolder>(filepath));

        }
        else {
            PlayerData.spaceshiplevel = (int)(levelnumber * 1.5);
            PlayerData.spaceshiplevels = new int[1] { (int)(levelnumber * 1.5) };
            PlayerData.currentspaceship = 0;
            Spaceships.photos = new List<Sprite>() { GetComponentInChildren<Arrowkeysscript>().gameObject.GetComponent<SpriteRenderer>().sprite };
        }
    }

    string GetFilepath() {
        if (Application.isPlaying) {
            return LeveltxtReader.GetLocalFilePath("level" + levelnumber.ToString());
        }
        else {
            return Application.dataPath + "/Level backups/level" + levelnumber.ToString() + ".txt";
        }
    }




    LevelDataHolder PackageLevel() {
        LevelDataHolder dataholder = new();

        dataholder.level = levelnumber;

        GameObject physicsholder = GetComponentInChildren<Physicses>().gameObject;

        GameObject spaceship = physicsholder.GetComponentInChildren<PlayerScript>().gameObject;
        dataholder.spaceshippos = spaceship.transform.position;
        dataholder.spaceshipspeed = spaceship.GetComponent<ObjectScript>().startv;




        OrbScript[] orbs = GetComponentsInChildren<OrbScript>();
        for (int i = 0; i < orbs.Length; i++) {
            dataholder.orbs[i] = orbs[i].transform.position;
        }

        GameObject frame = GetComponentInChildren<Wall>().gameObject;
        dataholder.framesize = frame.transform.localScale;

        ObjectScript[] orbiters = GetComponentsInChildren<ObjectScript>();
        dataholder.objects = new OrbitObjectDataHolder[orbiters.Length - 1];

        int offset = 0;
        for (int i = 0; i < orbiters.Length; i++) {
            ObjectScript script = orbiters[i];
            if (script.gameObject.GetComponent<PlayerScript>() == null) {
                dataholder.objects[i - offset] = OrbitObjectDataHolder.GetDataHolder(script);
            }
            else {
                offset++;
            }
        }
        GameObject flag = GetComponentInChildren<FlagScript>().transform.parent.gameObject;
        ObjectScript flagbject = flag.GetComponent<ObjectScript>();
        dataholder.flagobject = System.Array.IndexOf(orbiters, flagbject) - offset;
        dataholder.flagrotation = flag.transform.rotation.z;

        Camera maincam = GetComponentInChildren<Camera>();
        dataholder.camerasize = maincam.orthographicSize;


        LeveltxtReader.UpdateData(dataholder, filepath);
        return dataholder;
    }




    void CreateLevel(LevelDataHolder dataholder) {
        GameStats.level = dataholder.level;
        GameObject physicsholder = GetComponentInChildren<Physicses>().gameObject;

        GameObject spaceship = physicsholder.GetComponentInChildren<PlayerScript>().gameObject;

        TrailRenderer trail = spaceship.GetComponent<TrailRenderer>();
        trail.enabled = false;
        spaceship.transform.localPosition = dataholder.spaceshippos;
        trail.enabled = true;

        ObjectScript playerobjectscript = spaceship.GetComponent<ObjectScript>();
        playerobjectscript.startv = dataholder.spaceshipspeed;

        OrbScript[] orbs = GetComponentsInChildren<OrbScript>();
        for (int i = 0; i < orbs.Length; i++) {
            orbs[i].transform.position = dataholder.orbs[i];
        }

        GameObject frame = GetComponentInChildren<Wall>().gameObject;
        frame.transform.localScale = dataholder.framesize;

        StarCopier starfield = GetComponentInChildren<StarCopier>();
        starfield.starfieldcount = new Vector2(12 + (int)(dataholder.framesize.x / 10), 12 + (int)(dataholder.framesize.y / 5));

        GameObject baseobject = GetComponentsInChildren<ObjectScript>()[1].gameObject;
        if (baseobject.GetComponentInChildren<FlagScript>() != null) {
            baseobject.GetComponentInChildren<FlagScript>().transform.parent = physicsholder.transform;
        }

        foreach (ObjectScript obj in GetComponentsInChildren<ObjectScript>()) {
            if (obj.gameObject.GetComponent<PlayerScript>() == null) {
                obj.gameObject.tag = "ToDestroy";
            }
        }

        ObjectScript[] objects = new ObjectScript[dataholder.objects.Length];
        for (int i = 0; i < dataholder.objects.Length; i++) {
            GameObject newboy;
            newboy = Instantiate(baseobject);
            newboy.tag = "OrbitingObject";
            newboy.name = "Spacerock";
            newboy.transform.parent = physicsholder.transform;
            ObjectScript objectscript = newboy.GetComponent<ObjectScript>();
            objects[i] = objectscript;
            OrbitObjectDataHolder.UpdateObject(dataholder.objects[i], objects[i]);
        }
        foreach (ObjectScript script in gameObject.GetComponentsInChildren<ObjectScript>()) {
            if (script.gameObject.CompareTag("ToDestroy")) {
                if (Application.isEditor && !Application.isPlaying) {
                    DestroyImmediate(script.gameObject);
                }
                else {
                    Destroy(script.gameObject);

                }

            }
        }

        GameObject flag = GetComponentInChildren<FlagScript>().gameObject;
        flag.transform.parent = objects[dataholder.flagobject].transform;
        flag.transform.localPosition = Vector3.zero;

        flag.transform.rotation = new Quaternion();
        flag.transform.rotation = Quaternion.Euler(new Vector3(0, 0, dataholder.flagrotation));

        Camera maincam = GetComponentInChildren<Camera>();
        maincam.orthographicSize = dataholder.camerasize;

    }


    [ProButton]
    public void LoadLevelToInspector() {
        if (!unlocked) { Debug.Log("Unlock to continue"); return; }
        Debug.Log("Loading level " + levelnumber);
        Debug.Log("Don't forget, sprites here won't save - add them to the SpriteList object on the PhysicsBox object, and change the objectscript.sprite field");
        filepath = GetFilepath();
        CreateLevel(LeveltxtReader.ReadData<LevelDataHolder>(filepath));
        unlocked = false;
    }

    [ProButton]
    public void SaveLevel() {
        if (!unlocked) { Debug.Log("Unlock to continue"); return; }
        Debug.Log("Saving level " + levelnumber);
        Debug.Log("Once you're ready to ship, move the level" + levelnumber + ".txt asset from Level Backups to Resources");
        filepath = GetFilepath();
        PackageLevel();
        unlocked = false;

    }
}
