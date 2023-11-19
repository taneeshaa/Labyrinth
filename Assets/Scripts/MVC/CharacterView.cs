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
    public GameObject characterCamera;
    public GameObject accessoryCamera;
    private CharacterSelectController MVController;
    private int currentCharacterIndex = 0;
    private int currentAccessoryIndex = 0;
    private GameObject currentButton;

    private void Start()
    {
        MVController = GetComponent<CharacterSelectController>();
    }

    public void SelectCharacter()
    {

        currentButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        for(int i = 0; i < MVController.charactersButtons.Count;  i++)
        {
            if (MVController.charactersButtons[i] == currentButton)
            {
                MVController.characters[currentCharacterIndex].SetActive(false);
                currentCharacterIndex = i;
                MVController.characters[i].SetActive(true);
                Debug.Log("switch successful");
            }
        }
    }

    public void SelectAccessory()
    {
        currentButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        for (int i = 0; i < MVController.accessoriesButtons.Count; i++)
        {
            if (MVController.accessoriesButtons[i] == currentButton)
            {
                MVController.accessories[currentAccessoryIndex].SetActive(false);
                currentAccessoryIndex = i;
                MVController.accessories[i].SetActive(true);
                Debug.Log("switch successful");
            }
        }
    }
    public void SelectMenu()
    {
        characterButton.onClick.AddListener(enableCharacterMenu);
        accessoryButton.onClick.AddListener(enableAccessoryMenu);
    }

    void enableAccessoryMenu()
    {
        accessoryMenu.SetActive(true);
        accessoryCamera.SetActive(true);
        characterCamera.SetActive(false);
        characterMenu.SetActive(false);
    }

    void enableCharacterMenu()
    {
        characterMenu.SetActive(true);
        characterCamera.SetActive(true);
        accessoryCamera.SetActive(false );
        accessoryMenu.SetActive(false);
    }
    
}
