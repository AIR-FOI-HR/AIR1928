using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHandlerScript : MonoBehaviour
{
    public Vector3 LastClickPosition;
    public int skillToUSe = 0;
    public LevelDataControler scriptWithData = null;
    public List<ISkillInterface> ListOfSkills = new List<ISkillInterface>();
    private bool RaycastElemnt(string tag, RaycastHit2D[] hits)
    {
        bool answer = false;
        foreach (var item in hits)
        {
            if (item.collider.tag == tag)
            {
                answer = true;
                //Debug.Log(item.transform.InverseTransformDirection(item.point));
                LastClickPosition = item.transform.InverseTransformDirection(item.point);
            }
        }
        return answer;
    }

    void Start()
    {
        scriptWithData = GameObject.Find("DataHandler").GetComponent<LevelDataControler>();
        GetModules();
    }

    void GetModules()
    {
        foreach (SkillData item in scriptWithData.allLevelData.skill)
        {
            GameObject objectToSpawn = Resources.Load(item.PrefabName) as GameObject;
            Debug.Log(item.PrefabName);
            if (objectToSpawn == null) Debug.Log("Nothing");
            GameObject target = Instantiate(objectToSpawn, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            ListOfSkills.Add((ISkillInterface)target.GetComponent(typeof(ISkillInterface)));
        }
    }

    void Update()
    {
        //ako je uhvaćen tap
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //raycasting
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            RaycastHit2D[] hits = Physics2D.RaycastAll(mouseWorldPos, Vector2.zero);
            //skill usable area nije selektiran
            if (RaycastElemnt("SkillArea", hits))
            {
                ListOfSkills[skillToUSe].SpawnObject(LastClickPosition);
                //ISkillInterface skill = GameObject.Find("FireballHandler").GetComponent<ISkillInterface>();
                //skill.SpawnObject(LastClickPosition);
                //Debug.Log("Spawn");
            }
        }
    }
}
