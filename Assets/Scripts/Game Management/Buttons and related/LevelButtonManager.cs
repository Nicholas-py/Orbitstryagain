using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonManager : MonoBehaviour
{

    public GameObject defaultunlocked;
    public GameObject defaultlocked;

    private int levelcount;
    private int unlockedcount;

    void Start()
    {
        levelcount = GlobalData.levelcount;
        unlockedcount = PlayerData.levelunlockedcount;
        GameObject current;
        for (int i = 1; i <= levelcount; i++) {
            if (i <= unlockedcount) {
                current = Instantiate(defaultunlocked);
                current.GetComponent<LevelLoadButton>().level = i;

            }
            else {
                current = Instantiate(defaultlocked);
            }
            current.transform.SetParent(transform);

            RectTransform recttransform = current.GetComponent<RectTransform>();
            recttransform.localScale = defaultlocked.transform.localScale;
            recttransform.position = GetNthCoordinate(i);

        }
        defaultlocked.SetActive(false);
        defaultunlocked.SetActive(false);
    }

    Vector2 GetNthCoordinate(int n) {
        return new Vector2(0, 60 - 45 * n)/transform.localScale.x;
    }
}
