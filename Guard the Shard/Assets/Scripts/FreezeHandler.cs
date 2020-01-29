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
    //sam skill koji se u ovu varijablu učitava
    GameObject InstanceOfSkill = null;
    //UI element koji poziva skill
    public Button freezeButton;
    //skripta koja handla poziv skilla
    public SkillHandlerScript skripta;
    //dedukcija energije iz objekta
    public bool DeductCost(int cost)
    {
        
        float usableEnergy = GameObject.Find("EnergyContainer").GetComponent<Energy>().currentEnergy;
        if (usableEnergy >= cost)
        {
            GameObject.Find("EnergyContainer").GetComponent<Energy>().Deduct(cost);
            return true;
        }
        return false;

    }
    //učitavanje resursa u varijablu
    public void PrepareForUse()
    {
        skripta = FindObjectOfType<SkillHandlerScript>();
        InstanceOfSkill = Resources.Load("FreezeSkill") as GameObject;
        freezeButton = GameObject.Find("ThirdSkillButton").GetComponent<Button>();
        freezeButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("ico_2");
        freezeButton.onClick.AddListener(delegate { UseSkill(0); });
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
            GameObject created = Instantiate(InstanceOfSkill, vector3, Quaternion.identity);
            created.GetComponent<Freeze>().GetParameters(SkillRange, SkillDamage, SkillSlow, SKillDuration);
        }
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
}
