using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class MusicButton : MonoBehaviour
{
    public Button musicButton;
    public Button soundButton;
    public Sprite blockA;
    public Sprite blockB;
    private int brojacM = 0;
    private int brojacS = 0;

    // Start is called before the first frame update
    void Start()
    {
        musicButton = GetComponent<Button>();
        soundButton = GetComponent<Button>();
    }

    public void changeMusicButton()
    {
        brojacM++;
        if (brojacM % 2 == 0)
        {
            musicButton.image.overrideSprite = blockA;
        }
        else
        {
            musicButton.image.overrideSprite = blockB;
        }
    }

    public void changeSoundButton()
    {
        brojacS++;
        if (brojacS % 2 == 0)
        {
            soundButton.image.overrideSprite = blockA;
        }
        else
        {
            soundButton.image.overrideSprite = blockB;
        }
    }
}
