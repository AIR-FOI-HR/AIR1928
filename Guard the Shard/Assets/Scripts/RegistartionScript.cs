using Assets.Scripts.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RegistartionScript : MonoBehaviour
{
    public InputField Email;
    public InputField Username;
    public InputField Password;
    public InputField ConfirmPassword;

    public void IdiNaPrijavu()
    {
        TurretControl tc = new TurretControl();
        Turret p = tc.GetTurret(1);
        Debug.Log(p.PrefabName);
        //SceneManager.LoadScene(2);
    }

    public void Registration()
    {
        UserControl userControl = new UserControl();
        if (Username.text.ToString() != "" && Password.text.ToString() != "")
        {
            if (Password.text.ToString() == ConfirmPassword.text.ToString())
            {
                if (userControl.Register(Username.text.ToString(), Password.text.ToString())=="Everything ok")
                {
                    SceneManager.LoadScene(3);
                }
                else
                {
                    Debug.Log("Username is used");
                }
            }
        }
    }
}
