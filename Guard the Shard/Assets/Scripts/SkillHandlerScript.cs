﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillHandlerScript : MonoBehaviour
{
    // Ova klasa služi upravljanju vještinama , to uključuje više stvari počevši od samog dohvaćanja podataka preko instanciranja  do pozivanja instanciranih vještina

    string[] tags = { "EarthEnemy", "AirEnemy" };
    public Vector3 LastClickPosition;
    //0 za prvi skill , 1 za drugi itd ; ovo služi kako bi znali koji skill pozvati
    public int skillToUSe;
    //jeli omogućeno baciti/probati baciti skill nakon svakog bacanja ide na false;
    public bool Enabled = false;
    //skripta koja sadržava podatke koji nam trebaju
    public LevelDataControler scriptWithData = null;
    //lista skilova koji su učitani (tj biti će)
    public List<ISkillInterface> ListOfSkills = new List<ISkillInterface>();
    public Energy energija = null;
     
    //obični raycast koji traži collider s tagom ako je pogodio collider vraća true
     
    private bool RaycastElemnt(string tag, RaycastHit2D[] hits)
    {
        bool answer = false;
        foreach (var item in hits)
        {
            if (item.collider.tag == tag)
            {
                answer = true;
                //Debug.Log(item.transform.InverseTransformDirection(item.point));
                // ako je došlo do pogotka se sejva lokacija kolizije s colliderom
                LastClickPosition = item.transform.InverseTransformDirection(item.point);
            }
        }
        return answer;
    }

    void Start()
    {
        energija = GameObject.Find("EnergyContainer").GetComponent<Energy>();
        scriptWithData = GameObject.Find("DataHandler").GetComponent<LevelDataControler>();
        GetModules();
    }
    //učitavanje vještina u listu i prosljeđivanje parametara
    void GetModules()
    {
        int index = 0;
        foreach (SkillData item in scriptWithData.allLevelData.skill)
        {
            GameObject objectToSpawn = Resources.Load(item.PrefabName) as GameObject;
            GameObject target = Instantiate(objectToSpawn, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            //dodaje se klasa za upravljanje objektom koja nasljeđuje interface u listu kako bi se kasnije pozivalo
            ListOfSkills.Add((ISkillInterface)target.GetComponent(typeof(ISkillInterface)));
            ListOfSkills[index].SendParameters(item.RangeSkill, item.Damage, item.SlowSkill, item.Duration,tags);
            //dodaj button 
            GameObject prefabButton = Resources.Load("SkillButton") as GameObject;
            GameObject goButton = Instantiate(prefabButton);
            Transform inGameCanvas = GameObject.Find("InGameCanvas").transform;
            goButton.transform.SetParent(inGameCanvas);            
            
            Vector3 buttonPosition = new Vector3(-281 + index * 160, -201);
            goButton.transform.localPosition = buttonPosition;
            goButton.GetComponentInChildren<Text>().text = index.ToString();
            
            Button tempButton = goButton.GetComponent<Button>();            
            //tempButton.onClick.AddListener(() => UseSkill(0));

            goButton.GetComponent<Button>().onClick.AddListener(() => UseSkill(tempButton.GetComponentInChildren<Text>().text));
            ListOfSkills[index].PrepareForUse(goButton.transform.position, inGameCanvas);

            index++;
        }
        
    }

    void Update()
    {
        
        //ako je uhvaćen tap bez držanja
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            
            //raycasting kako bi dohvatit sve udarce u collidere
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            RaycastHit2D[] hits = Physics2D.RaycastAll(mouseWorldPos, Vector2.zero);
            if (RaycastElemnt("SkillArea", hits) && Enabled)
            {
                if (energija.currentEnergy >= ListOfSkills[skillToUSe].GiveCost())
                {
                    energija.Deduct(ListOfSkills[skillToUSe].GiveCost());
                    List<GameObject> targets = ListOfSkills[skillToUSe].SpawnObject(LastClickPosition);
                    DoEfect(targets, ListOfSkills[skillToUSe].GiveDmg(), ListOfSkills[skillToUSe].GiveSlow(), ListOfSkills[skillToUSe].GiveDuration());
                    Enabled = false;
                }
                Enabled = false;
            }
        }
    }
    public void DoEfect(List<GameObject> targets,int dmg,float slow,float duration)
    {
        foreach (GameObject enemy in targets)
        {
            enemy.GetComponent<NeprijateljFunction>().TakeDamage(dmg);
            if (slow > 0) enemy.GetComponent<NeprijateljKretanje>().SlowEnemy(slow, duration);
        }
    }

    public void UseSkill(string skillId)
    {
        Debug.Log(skillId);
        Enabled = true;
        skillToUSe = int.Parse(skillId);
    }

}
