using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Models;

public class LogInManager : MonoBehaviour
{
    public APIReader apiReader;

    public TMP_InputField usernameTxt, passwordTxt;
    public GameObject profilePanel;
    public TextMeshProUGUI profileUsernameTxt;
    public GameObject errorTxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LogIn()
    {
        foreach(UserData user in apiReader.users)
        {
            if(user.Username == usernameTxt.text)
            {
                if(user.Password == passwordTxt.text)
                {
                    errorTxt.SetActive(false);     
                    apiReader.userData = user;
                    ShowProfile();
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

    public void ShowProfile()
    {
        profileUsernameTxt.text = $"Hello, {apiReader.userData.Username}";
        profilePanel.SetActive(true);
    }
}
