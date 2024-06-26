using System;
using UnityEngine;
using TMPro; // Add this namespace for TextMeshPro

public class RoadToHeavenlessController : MonoBehaviour
{
    public GameObject loginPanel, signupPanel, profilePanel, menuPanel, notificationPanel;

    public TMP_InputField loginUsername, loginPassword, signupUsername, signupPassword, signupCPassword;

    public TMP_Text notif_Title_Text, notif_Message_Text, profileUsername_Text;

    public int currentScreen = CurrentScreen.CurrentScreenPanel;


    private string storedUsername;
    private string storedPassword;

    private void Start()
    {
        currentScreen = CurrentScreen.CurrentScreenPanel;
        switch (currentScreen)
        {
            case 0:
                OpenLoginPanel();
                break;
            case 1:
                OpenSignUpPanel();
                break;
            case 2:
                OpenProfilePanel();
                break;
            case 3:
                OpenMenuPanel();
                break;
        }
    }

    public void ResetPanel()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(false);
        profilePanel.SetActive(false);
        menuPanel.SetActive(false);
    }

    public void OpenLoginPanel()
    {
        currentScreen = 0;
        ResetPanel();
        loginPanel.SetActive(true);
    }

    public void OpenSignUpPanel()
    {
        currentScreen = 1;
        ResetPanel();
        signupPanel.SetActive(true);
    }

    public void OpenProfilePanel()
    {
        currentScreen = 2;
        ResetPanel();
        profilePanel.SetActive(true);
        profileUsername_Text.text = storedUsername; // Display the username in the profile panel
    }

    public void OpenMenuPanel()
    {
        currentScreen = 3;
        ResetPanel();
        menuPanel.SetActive(true);
    }

    public void LoginUser()
    {
        if (string.IsNullOrEmpty(loginUsername.text) || string.IsNullOrEmpty(loginPassword.text))
        {
            ShowNotificationMessage("Error", "Fields Empty! Please Input Details In All Fields");
            return;
        }

        if (loginUsername.text == storedUsername && loginPassword.text == storedPassword)
        {
            ShowNotificationMessage("Success", "Login successful!");
            OpenProfilePanel(); // Switch to the profile panel on successful login
        }
        else
        {
            ShowNotificationMessage("Error", "Invalid username or password");
        }
    }

    public void SignUpUser()
    {
        if (string.IsNullOrEmpty(signupUsername.text) || string.IsNullOrEmpty(signupPassword.text) || string.IsNullOrEmpty(signupCPassword.text))
        {
            ShowNotificationMessage("Error", "Fields Empty! Please Input Details In All Fields");
            return;
        }

        if (signupPassword.text != signupCPassword.text)
        {
            ShowNotificationMessage("Error", "Passwords do not match");
            return;
        }

        // Perform sign-up logic here
        storedUsername = signupUsername.text;
        storedPassword = signupPassword.text;

        ShowNotificationMessage("Success", "Sign up successful! Please log in.");
        OpenLoginPanel(); // Switch back to the login panel
    }

    private void ShowNotificationMessage(string title, string message)
    {
        notif_Title_Text.text = title;
        notif_Message_Text.text = message;

        notificationPanel.SetActive(true);
    }

    public void CloseNotifPanel()
    {
        notif_Title_Text.text = "";
        notif_Message_Text.text = "";

        notificationPanel.SetActive(false);
    }

    public void LogOut()
    {
        profilePanel.SetActive(false);
        profileUsername_Text.text = "";
        OpenLoginPanel();
    }

    public void Menu()
    {
        OpenMenuPanel();
    }
}


