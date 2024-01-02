using UnityEngine;
using TMPro;

public class CharacterPanel : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private TMP_Text characterInfoText; // Przypisz obiekt TMP_Text z Unity
    [SerializeField] private TMP_Text characterInfoName;
    [SerializeField] private GameEvent On;
    [SerializeField] private GameEvent Off; 
    bool IsOn; 
    void Start()
    {
        // SprawdŸ, czy obiekt Character zosta³ przypisany
        if (character == null)
        {
            Debug.LogError("Character not assigned to CharacterPanel!");
            return;
        }
        IsOn = false;
        // Wyœwietl informacje o postaci
        
    }

    void UpdateCharacterInfo()
    {
        // Utwórz tekst z informacjami o postaci
        string characterInfo =
            "Justice:    " + character.Justice + "\n" +
            "Courage:   " + character.Courage + "\n" +
            "Compassion: " + character.Compassion + "\n" +
            "Respect:    " + character.Respect + "\n" +
            "Integrity:  " + character.Integrity + "\n" +
            "Honor:      " + character.Honor + "\n" +
            "Loyalty:    " + character.Loyalty;

        // Aktualizuj tekst w obiekcie TMP_Text
        characterInfoText.text = characterInfo;

        characterInfoName.text = character.Charactername;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) {
            if (IsOn == false)
            {
                On.Raise();
                IsOn = true;
            }
            else
            {
                Off.Raise();
                IsOn = false;
            }
        }

        if(IsOn == true) {

            UpdateCharacterInfo();
        }
    }
}
