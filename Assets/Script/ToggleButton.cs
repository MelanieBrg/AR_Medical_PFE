using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    private bool isToggled = false;
    private Image buttonImage; 
    public GameObject my_object;

    private void Start()
    {
        // Récupérez la composante Image du bouton
        buttonImage = GetComponent<Image>();

        SetInitialState();
    }

    public void OnButtonClick()
    {
        // Inversez l'état du bouton
        isToggled = !isToggled;

        // Mettez à jour la couleur du bouton en fonction de l'état
        if (isToggled)
        {
            // Bouton activé, mettez la couleur verte
            buttonImage.color = Color.green;
            ShowObjectByButtonTag();
        }
        else
        {
            // Bouton désactivé
            buttonImage.color = Color.red;
            HideObjectByButtonTag();
        }
    }

    private void SetInitialState()
    {
        // Mettez tous les boutons dans l'état initial activé
        isToggled = true;
        buttonImage.color = Color.green;
    }

    private void ShowObjectByButtonTag()
    {
        my_object.SetActive(true);
    }

    private void HideObjectByButtonTag()
    {
        my_object.SetActive(false);
    }
}
