using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentScript : MonoBehaviour
{
    public ScrollRect ScrollView;
    public GameObject ScrollContent;
    public GameObject ScrollItemPrefab;
    public ToggleGroup toggleGroup;

    private Sprite slika;

    // Start is called before the first frame update
    void Start()
    {
        List<Skill> skills = new List<Skill>();
        SkillControl skillControl = new SkillControl();

        skills = skillControl.GetSkills();

        foreach (var item in skills)
        {
            generateItem(item.Dat, item.ID);
        }
    }

    void generateItem(string nazivSlike, int idSkilla)
    {
        GameObject scrollItemObj = Instantiate(ScrollItemPrefab);
        scrollItemObj.transform.SetParent(ScrollContent.transform, false);
        slika = Resources.Load<Sprite>(nazivSlike);
        scrollItemObj.transform.Find("Background").gameObject.GetComponent<Image>().sprite = slika;
        scrollItemObj.transform.name = idSkilla.ToString();
        scrollItemObj.transform.gameObject.GetComponent<Toggle>().group = toggleGroup;
    }
}
