using UnityEngine;

public class PrivacyPolicyManager : MonoBehaviour
{
    public GameObject MenuPanel;     // MenuPanel
    public GameObject PrivacyPanel;       // PrivacyPanel

    public void ShowPrivacyPolicy()
    {
        MenuPanel.SetActive(false);
        PrivacyPanel.SetActive(true);
    }

    public void ClosePrivacyPolicy()
    {
        PrivacyPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }
}
