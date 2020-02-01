using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireballHandler : MonoBehaviour, ISkillInterface
{
    //parametri koji su preneseni i dalje se prenose
    int cost = 30;
    float SkillRange = 0;
    int SkillDamage = 0;
    float SkillSlow = 0;
    float SKillDuration = 0;
    string[] Tags =null;
    //sam skill koji se u ovu varijablu učitava
    GameObject InstanceOfSkill = null;
    //UI element koji poziva skill
    public Button fireballButton;
    //skripta koja handla poziv skilla
    public SkillHandlerScript skripta;
    public int GiveCost()
    {
        return cost;
    }
    //učitavanje resursa u varijablu
    public void PrepareForUse()
    {
        skripta = FindObjectOfType<SkillHandlerScript>();
        InstanceOfSkill = Resources.Load("FireballSkill") as GameObject;
        fireballButton = GameObject.Find("FirstSkillButton").GetComponent<Button>();
        fireballButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("ico_1");
        fireballButton.onClick.AddListener(delegate { UseSkill(2); });
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
        created.GetComponent<Fireball>().GetParameters(SkillRange, Tags);
        return created.GetComponent<Fireball>().GetAllEnemies();
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
