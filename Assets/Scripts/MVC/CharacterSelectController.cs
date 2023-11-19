using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectController : MonoBehaviour
{
    public GameObject charactersParent;
    public GameObject accessoriesParent;
    public GameObject characterButtonsParent;
    public GameObject accessoriesButtonsParent;

    private GameObject newAccessory;
    [HideInInspector] public List<GameObject> accessories;
    [HideInInspector] public List<GameObject> characters;
    private List<GameObject> charactersParentButtons;
    private List<GameObject> accessoriesParentButtons;
    [HideInInspector] public List<GameObject> charactersButtons;
    [HideInInspector] public List<GameObject> accessoriesButtons;

    private void Start()
    {
        accessories = new List<GameObject>();
        characters = new List<GameObject>();
        accessoriesButtons = new List<GameObject>();
        charactersButtons = new List<GameObject>();
        accessoriesParentButtons = new List<GameObject>();
        charactersParentButtons = new List<GameObject>();

        //get characters and accessories list
        getList(charactersParent, characters);
        getList(accessoriesParent, accessories);
        //get gameobject containers
        getList(characterButtonsParent, charactersParentButtons);
        getList(accessoriesButtonsParent, accessoriesParentButtons);
        //get buttons
        getButton(charactersParentButtons, charactersButtons);
        getButton(accessoriesParentButtons, accessoriesButtons);

    }

    void getList(GameObject parent, List<GameObject> childList)
    {
        for(int i = 0; i < parent.transform.childCount ; i++)
        {
            childList.Add(parent.transform.GetChild(i).gameObject);
        }
    }

    void getButton(List<GameObject> childList, List<GameObject> buttonList)
    {
        for(int i = 0; i < childList.Count ; i++)
        {
            buttonList.Add(childList[i].transform.Find("Button (Legacy)").gameObject);
        }
    }

}
