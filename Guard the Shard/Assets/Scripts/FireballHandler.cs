using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballHandler : MonoBehaviour, ISkillInterface
{
    //parametri koji su preneseni i dalje se prenose
    int cost = 5;
    float SkillRange = 0;
    int SkillDamage = 0;
    float SkillSlow = 0;
    float SKillDuration = 0;
    //sam skill koji se u ovu varijablu učitava
    GameObject InstanceOfSkill = null;
    //dedukcija energije iz objekta
    public bool DeductCost(int cost)
    {
        int usableEnergy = GameObject.Find("EnergyHandler").GetComponent<EnergyHandlerScript>().Energy;
        if(usableEnergy >= cost)
        {
            GameObject.Find("EnergyHandler").GetComponent<EnergyHandlerScript>().Deduct(cost);
            return true;
        }
        return false;

    }
    //učitavanje resursa u varijablu
    public void PrepareForUse()
    {
        InstanceOfSkill = Resources.Load("FireballSkill") as GameObject;
    }
    //prijenos parametara
    public void SendParameters(float range, int damage, float slow, float duration)
    {
        SkillRange = range;
        SkillDamage = damage;
        SkillSlow = slow;
        SKillDuration = duration;
    }
    //samo instanciranje učitanog skilla i prosljeđivanje skilla
    public void SpawnObject(Vector3 vector3)
    {
        if (DeductCost(cost))
        {
            GameObject created =  Instantiate(InstanceOfSkill, vector3, Quaternion.identity);
            created.GetComponent<Fireball>().GetParameters(SkillRange, SkillDamage, SkillSlow, SKillDuration);
        }
    }
    void Awake()
    {
        PrepareForUse();
    }
}
