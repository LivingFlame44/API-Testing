using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangePasswordManager : MonoBehaviour
{
    public APIReader apiReader;
    public TMP_InputField usernameTxt, oldPasswordTxt, newPasswordTxt;

    public GameObject errorTxt;
    public GameObject changePasswordPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePassword()
    {
        foreach (UserData user in apiReader.users)
        {
            if (user.Username == usernameTxt.text)
            {
                if (user.Password == oldPasswordTxt.text)
                {
                    errorTxt.SetActive(false);
                    apiReader.userData = user;
                    UpdatePassword();
                    CleanUp();
                    return;
                }

                else
                {
                    errorTxt.SetActive(true);
                    return;
                }
            }
        }
        errorTxt.SetActive(true);
    }

    public void UpdatePassword()
    {
        apiReader.userData.Password = newPasswordTxt.text;
        apiReader.PatchUser();
        apiReader.Get();
    }

    public void CleanUp()
    {
        usernameTxt.text = null;
        oldPasswordTxt.text = null;
        newPasswordTxt.text = null;


        changePasswordPanel.SetActive(false);
    }
}
