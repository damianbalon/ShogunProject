using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatBehavior : MonoBehaviour
{
    private Character charData;
    private int initiative = 0;
    private bool iniReady = false;
    public int Initiative { 
        get {
            if(!iniReady) RerollInitiative();
            return initiative;
        } 
    }
    [SerializeField] private List<Ability> moveset;
    // Start is called before the first frame update
    void Start()
    {
        charData = GetComponent<Character>();
        if(charData == null) {
            Debug.LogWarning("No character data component found to work with!");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //dodawanie do listy walczących
    public void RegisterCombat() {

    }

    //usuwanie z listy walczących
    public void UnregisterCombat() {
        
    }

    public void RerollInitiative() {
        initiative = DiceRoller.RollDiceRaw(1) + GetComponent<Character>().Courage; //nie pamiętam który to miał być atrybut
        iniReady = true;
    }
}
