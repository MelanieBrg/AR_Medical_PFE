using UnityEngine;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public List<GameObject> uiElements; // Drag your UI elements (cleaningUI, animationUI, etc.) here in the Inspector
    public GameObject cleaningZone;

    private int currentIndex = 0;

    private void Start()
    {
        // Deactivate all UI elements except the first one
        for (int i = 1; i < uiElements.Count; i++)
        {
            uiElements[i].SetActive(false);
        }

        // Deactivate cleaningZone at the beginning
        cleaningZone.SetActive(false);
    }

    public void ToggleUI()
    {
        // Deactivate the current UI
        uiElements[currentIndex].SetActive(false);

        // Increment the index or loop back to the first UI if at the end
        currentIndex = (currentIndex + 1) % uiElements.Count;

        // Activate the new UI
        uiElements[currentIndex].SetActive(true);

        // Activate cleaningZone only if the current UI is "cleaningUI"
        cleaningZone.SetActive(uiElements[currentIndex].name == "cleaningUI");
    }
}
