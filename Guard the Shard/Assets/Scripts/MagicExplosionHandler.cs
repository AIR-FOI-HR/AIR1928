using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MagicExplosionHandler : MonoBehaviour, ISkillInterface
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
    public Button magicButton;
    //skripta koja handla poziv skilla
    public SkillHandlerScript skripta;
    public int GiveCost()
    {
        return cost;
    }
    //učitavanje resursa u varijablu
    public void PrepareForUse()
    {
        InstanceOfSkill = Resources.Load("MagicExplosionSkill") as GameObject;
        skripta = FindObjectOfType<SkillHandlerScript>();
        magicButton = GameObject.Find("SecondSkillButton").GetComponent<Button>();
        magicButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("ico_7");
        magicButton.onClick.AddListener(delegate { UseSkill(1); });
    }
    //prijenos parametara
    public void SendParameters(float range, int damage, float slow, float duration, string[] tags)
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
        created.GetComponent<MagicExplosion>().GetParameters(SkillRange, Tags);
        return created.GetComponent<MagicExplosion>().GetAllEnemies();
    }
    void Awake()
    {
        PrepareForUse();
    }
    public void UseSkill(int skillId)
    {
        skripta.Enabled = true;
        skripta.skillToUSe = skillId;
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
