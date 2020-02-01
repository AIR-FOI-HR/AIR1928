﻿using System.Collections.Generic;
using UnityEngine;

public interface ISkillInterface
{
    void SendParameters(float range,int damage,float slow,float duration,string[] tags);
    void PrepareForUse();
    List<GameObject> SpawnObject(Vector3 vector3);
    int GiveCost();
    int GiveDmg();
    float GiveSlow();
    float GiveDuration();
}
