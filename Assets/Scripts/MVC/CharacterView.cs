using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterView : MonoBehaviour
{
    public Button accessoryButton;
    public Button characterButton;
    public GameObject characterMenu;
    public GameObject accessoryMenu;
    public GameObject characterCamera;
    public GameObject accessoryCamera;

    public Transform spawnPoint;
    private CharacterSelectController MVController;
    private int currentCharacterIndex = 0;
    private int currentAccessoryIndex = 0;
    private GameObject currentButton;
    public GameObject playerGameObject;
    //private GameObject playerGameObjectParent;

    private void Start()
    {
        //playerGameObjectParent = GameObject.FindGameObjectWithTag("Player");
        //playerGameObject = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
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

    public void finalizeCharacter()
    {
        //playerGameObject.transform.position = spawnPoint.transform.position;
        DontDestroyOnLoad(playerGameObject);
        playerGameObject.GetComponent<AimStateManager>().enabled = true;
        playerGameObject.GetComponent<MovementStateManager>().enabled = true;
        playerGameObject.GetComponent<PlayerCombat>().enabled = true;

        playerGameObject.transform.GetChild(2).gameObject.SetActive(true);
        NextScene();
        //Invoke("NextScene", 3);
        
    }

    private void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        Cursor.lockState = CursorLockMode.Locked;
    }
}
