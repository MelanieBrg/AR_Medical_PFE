using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsToBodyConnection : MonoBehaviour
{
    // the full body game object that contains all the body parts
    GameObject fullBodyAnatomyGO;

    // the body part game object that is connected to the button
    GameObject bodyPartGO;

    void Start()
    {
        // at start, connect all the buttons to the body parts
        DoButtonsBodyConnection();
    }

    private void DoButtonsBodyConnection()
    {
        fullBodyAnatomyGO = GameObject.Find("FullBodyAnatomy");

        if (fullBodyAnatomyGO == null)
        {
            Debug.LogError("GameObject FullBodyAnatomy GameObject not found in the Unity Scene!");
            return;
        }

        Debug.Log("--- Connection process start ---");
        foreach (Transform child in transform)
        {

            string childName = child.name.Replace("Button_", "");
            Debug.Log("-> Searching for " + childName + " in " + fullBodyAnatomyGO.name);

            bodyPartGO = fullBodyAnatomyGO.transform.Find(childName).gameObject;

            if (bodyPartGO == null)
            {
                Debug.LogError("GameObject " + childName + " not found in the FullBodyAnatomy GameObject!");
                return;
            }

            ToggleButton toggleButton = child.GetComponent<ToggleButton>();
            if (toggleButton != null)
            {
                toggleButton.my_object = bodyPartGO;
                Debug.Log("\tFound it. Connection between button " + childName + " and corresponding body part done.");
            }
            else
            {
                Debug.LogError("ToggleButton component not found in " + child.name);
            }
        }
    }
}
