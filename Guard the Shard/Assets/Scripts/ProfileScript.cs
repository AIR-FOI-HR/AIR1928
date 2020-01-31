using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Database;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProfileScript : MonoBehaviour
{
    public Text txtUsername;
    
    private User user = new User();
    private UserControl userControl = new UserControl();


    // Start is called before the first frame update
    void Start()
    {
        user = userControl.GetUser(PlayerPrefs.GetInt("userid"));
        txtUsername.text = user.Username;
    }

    public void Izlaz()
    {
        SceneManager.LoadScene(3);
    }

    public void EditProfile()
    {
        SceneManager.LoadScene(8);
    }

    public void ChangePassword()
    {
        SceneManager.LoadScene(9);
    }

    public void Achivements()
    {
        SceneManager.LoadScene(14);
    }
}
