using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModel : MonoBehaviour
{
    public string customizationName;
    [HideInInspector] public GameObject customizationGameObject;
    public CustomizationType type;

    private void Start()
    {
        customizationGameObject = this.gameObject;
    }
}

public enum CustomizationType
{
    ACCESSORY,
    CHARACTER
}
