using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterView : MonoBehaviour
{
    public Button accessoryButton;
    public Button characterButton;
    public GameObject characterMenu;
    public GameObject accessoryMenu;

    public void SelectMenu()
    {
        characterButton.onClick.AddListener(enableCharacterMenu);
        accessoryButton.onClick.AddListener(enableAccessoryMenu);
    }

    void enableAccessoryMenu()
    {
        accessoryMenu.SetActive(true);
        characterMenu.SetActive(false);
    }

    void enableCharacterMenu()
    {
        characterMenu.SetActive(true);
        accessoryMenu.SetActive(false);
    }
    
}
