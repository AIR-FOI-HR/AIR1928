using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSpriteButton : MonoBehaviour
{
    public Button changeButton;
    public Sprite groundSprite;
    public Sprite aerialSprite;

    void Awake()
    {
        changeButton.onClick.AddListener(Change);
    }
    // Start is called before the first frame update
    void Start()
    {
        changeButton.GetComponent<Image>().sprite = aerialSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Change()
    {
        if (changeButton.GetComponent<Image>().sprite == aerialSprite)
        {
            changeButton.GetComponent<Image>().sprite = groundSprite;
        }
        else
        {
            changeButton.GetComponent<Image>().sprite = aerialSprite;
        }
    }
}
