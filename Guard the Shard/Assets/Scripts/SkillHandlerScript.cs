using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHandlerScript : MonoBehaviour
{
    // Ova klasa služi upravljanju vještinama , to uključuje više stvari počevši od samog dohvaćanja podataka preko instanciranja  do pozivanja instanciranih vještina

    //zadnja pozicija klika/tap koja je nužna kako i znali gdje se navedeni skil treba baciti tj. aktivirati ; prosljedi se handleru za skill
    public Vector3 LastClickPosition;
    //0 za prvi skill , 1 za drugi itd ; ovo služi kako bi znali koji skill pozvati
    public int skillToUSe = 0;
    //jeli omogućeno baciti/probati baciti skill nakon svakog bacanja ide na false;
    public bool Enabled = true;
    //skripta koja sadržava podatke koji nam trebaju
    public LevelDataControler scriptWithData = null;
    //lista skilova koji su učitani (tj biti će)
    public List<ISkillInterface> ListOfSkills = new List<ISkillInterface>();
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
        //dohvaćanje skripte s podatcima
        scriptWithData = GameObject.Find("DataHandler").GetComponent<LevelDataControler>();
        //poziv funkcije za učitavanje vještina u listu
        GetModules();
    }
    //učitavanje vještina u listu i prosljeđivanje parametara
    void GetModules()
    {
        //index u listi
        int index = 0;
        //za svaki dohvaćeni skill se odradi sljedeće
        foreach (SkillData item in scriptWithData.allLevelData.skill)
        {
            //loada se prefab u privremeni objekt
            GameObject objectToSpawn = Resources.Load(item.PrefabName) as GameObject;
            //Debug.Log(item.PrefabName);
            //if (objectToSpawn == null) Debug.Log("Nothing");
            //instancira se učitani objekt
            GameObject target = Instantiate(objectToSpawn, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            //dodaje se klasa z a upravljanje objektom koja nasljeđuje interface u listu kako bi se kasnije pozivalo
            ListOfSkills.Add((ISkillInterface)target.GetComponent(typeof(ISkillInterface)));
            //prosljeđivanje parametara koji su očitani iz baze toj klasi
            ListOfSkills[index].SendParameters(item.RangeSkill, item.Damage, item.SlowSkill, item.Duration);
            //prelazak na sljedeći index u listi
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
            //skill usable area nije selektiran
            if (RaycastElemnt("SkillArea", hits) && Enabled)
            {
                //aktivacija skill
                ListOfSkills[skillToUSe].SpawnObject(LastClickPosition);
                //onemogućavanje korištenja skilla
                Enabled = false;
            }
        }
    }
}
