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
                sceneId = 1;
                break;
            case "Level1":
                sceneId = 1;
                break;
            case "Level2":
                sceneId = 2;
                break;
            case "Level3":
                sceneId = 3;
                break;
            case "Level4":
                sceneId = 4;
                break;
            case "Level1Story":
                sceneId = 5;
                break;
            case "Level2Story":
                sceneId = 6;
                break;
            case "Level3Story":
                sceneId = 7;
                break;
            case "Level4Story":
                sceneId = 8;
                break;
            default:
                sceneId = 0;
                break;
        }
        return sceneId;
    }
}
