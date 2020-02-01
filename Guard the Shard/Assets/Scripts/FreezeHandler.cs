using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FreezeHandler : MonoBehaviour, ISkillInterface
{
    //parametri koji su preneseni i dalje se prenose
    int cost = 30;
    float SkillRange = 0;
    int SkillDamage = 0;
    float SkillSlow = 0;
    float SKillDuration = 0;
    string[] Tags = null;
    //sam skill koji se u ovu varijablu učitava
    GameObject InstanceOfSkill = null;    
    //dedukcija energije iz objekta
    //UI element koji poziva skill    
    GameObject sprite = null;

    public int GiveCost()
    {
        return cost;
    }
    //učitavanje resursa u varijablu
    public void PrepareForUse(Vector3 buttonPosition, Transform parentObject)
    {        
        InstanceOfSkill = Resources.Load("FreezeSkill") as GameObject;
        sprite = Resources.Load("iko_2") as GameObject;        
        GameObject createdSprite = Instantiate(sprite, buttonPosition, Quaternion.identity);
        createdSprite.transform.parent = parentObject;

    }
    //prijenos parametara
    public void SendParameters(float range, int damage, float slow, float duration,string[] tags)
    {
        SkillRange = range;
        SkillDamage = damage;
        SkillSlow = slow;
        SKillDuration = duration;
        Tags = tags;
    }
    //samo instanciranje učitanog skilla i prosljeđivanje skilla
    public List<GameObject> SpawnObject(Vector3 vector3)
    {
        GameObject created = Instantiate(InstanceOfSkill, vector3, Quaternion.identity);
        created.GetComponent<Freeze>().GetParameters(SkillRange, Tags);
        return created.GetComponent<Freeze>().GetAllEnemies();
    }
        
    public int GiveDmg()
    {
        return SkillDamage;
    }

    public float GiveSlow()
    {
        return SkillSlow;
    }

    public float GiveDuration()
    {
        return SKillDuration;
    }
}
