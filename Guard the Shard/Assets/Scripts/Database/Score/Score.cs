using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Database
{ 
    [System.Serializable]
    public class Scores 
    {
        public int LevelID;
        public int UserID;
        public int Score;
    }
    [System.Serializable]
    public class ScoresData
    {
        public List<Scores> Scores;

    }
}