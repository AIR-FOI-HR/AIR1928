using System;
using System.Collections.Generic;

[Serializable]
public class AllLevelData
{
    public int TurID;
    public float TurAttSp;
    public float BullSpeed;
    public string TurPrefab;
    public float TurDmgRange;
    public float TurDamage;
    public List<EnemyListData> enemies;
    public List<WaveData> waves;
}

[Serializable]
public class EnemyListData
{
    public int EneID;
    public int EneHP;
    public string EnePrefabName;
    public char EneType;
    public float EneSpeed;
    public int EneWorth;
}

[Serializable]
public class WaveData
{
    public int LevelNum;
    public int Enemy;
    public int Number;
    public int TimerAfterWave;
}
