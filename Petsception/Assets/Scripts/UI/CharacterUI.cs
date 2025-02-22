using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CharacterUI : MonoBehaviour
{

    [SerializeField]
    private Image dogBorder;

    [SerializeField]
    private Image catBorder;

    [SerializeField]
    private Image chameleonBorder;

    [SerializeField]
    private Sprite selectedChar;

    [SerializeField]
    private Sprite unselectedChar;

    [SerializeField]
    TMP_Text abilityText;

    public enum startingPet
    {
        Dog,
        Cat,
        Chameleon
    };

    [SerializeField]
    private startingPet starter;

    // Start is called before the first frame update
    private void Start()
    {

        if(starter==startingPet.Dog)
        {
            dogBorder.sprite = selectedChar;
            abilityText.text = "Bark";
        }

        if (starter == startingPet.Cat)
        {
            catBorder.sprite = selectedChar;
            abilityText.text = "Slow";
        }
        if (starter == startingPet.Chameleon)
        {
            chameleonBorder.sprite = selectedChar;
            abilityText.text = "Camo";
        }
        
    }

    public void updateCharacterUI(Component sender, object data)
    {
        if(data is Dog)
        {
            dogBorder.sprite = selectedChar;
            catBorder.sprite = unselectedChar;
            chameleonBorder.sprite = unselectedChar;
            abilityText.text = "Bark";
        }
        else if(data is Cat)
        {
            dogBorder.sprite = unselectedChar;
            catBorder.sprite = selectedChar;
            chameleonBorder.sprite = unselectedChar;
            abilityText.text = "Slow";
        }
        else if(data is Chameleon)
        {
            dogBorder.sprite = unselectedChar;
            catBorder.sprite = unselectedChar;
            chameleonBorder.sprite = selectedChar;
            abilityText.text = "Camo";
        }
    }
}
