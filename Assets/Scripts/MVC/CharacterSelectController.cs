using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectController : MonoBehaviour
{
    public List<CharacterModel> characters;
    public List<CharacterModel> accessories;
    public GameObject currentCharacter;
    //private GameObject newCharacter;
    //public GameObject currentAccessory;
    private GameObject newAccessory;
    private Text buttonText;
    public Button optionButton;

    private void Start()
    {
        buttonText = GetComponentInChildren<Text>();
    }
    public void characterChange()
    {
        optionButton.onClick.AddListener(changeCharacter);
    }
    void changeCharacter()
    {
        for(int i = 0; i < characters.Count; i++)
        {
            if (characters[i].customizationName == buttonText.text)
            {
                characters[i].customizationGameObject.SetActive(true);
                currentCharacter.SetActive(false);
                currentCharacter = characters[i].customizationGameObject;
            }
        }
    }




}
