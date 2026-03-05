using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class MenuManager : MonoBehaviour
{
    public GameObject startMenuCanvas;    // Drag StartMenuCanvas here
    public ARSession arSession;           // Drag ARSession object here
    public GameObject arSessionOriginObj; // Drag ARSessionOrigin GameObject here

    void Start()
    {
        // Disable AR and show the menu
        if (arSession != null) arSession.enabled = false;
        if (arSessionOriginObj != null) arSessionOriginObj.SetActive(false);
        startMenuCanvas.SetActive(true);
    }



    public void BeginExperience()
    {
        // Hide the menu
        startMenuCanvas.SetActive(false);

        // Make sure XR Origin is active before ARSession runs
        if (arSessionOriginObj != null) 
        arSessionOriginObj.SetActive(true);

        if (arSession != null) 
        arSession.enabled = true;
    }
    // public void BeginExperience()
    // {
    //     // Enable AR and hide menu
    //     startMenuCanvas.SetActive(false);
    //     if (arSession != null) arSession.enabled = true;
    //     if (arSessionOriginObj != null) arSessionOriginObj.SetActive(true);
    // }
}
