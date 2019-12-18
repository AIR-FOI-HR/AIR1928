using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetLevelId 
{
    public int LevelId()
    {
        Scene scene = SceneManager.GetActiveScene();
        int sceneId;
        switch (scene.name)
        {
            case "SampleScene":
                sceneId = 5;
                break;
            case "Map_2":
                sceneId = 6;
                break;
            case "Map_3":
                sceneId = 7;
                break;
            case "Map_4":
                sceneId = 8;
                break;

            default:
                sceneId = 0;
                break;
        }
        return sceneId;
    }
}
