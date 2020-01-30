using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EditProfileScript : MonoBehaviour
{
    public InputField inpUsername;

    private UserControl userControl = new UserControl();

    // Start is called before the first frame update
    void Start()
    {
        inpUsername.text = userControl.GetUser(PlayerPrefs.GetInt("userid")).Username;
    }

    public void ChangeUsername()
    {
        if (userControl.ChangeUsername(PlayerPrefs.GetInt("userid"), inpUsername.text).Result)
        {
            SceneManager.LoadScene(7);
        }
        else
        {

        }
    }

    public void Izlaz()
    {
        SceneManager.LoadScene(7);
    }
}
