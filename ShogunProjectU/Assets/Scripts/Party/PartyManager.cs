using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    //Jakiś kontener na klasę identyfikującą postać
    [SerializeField] private List<Character> party;
    public List<Character> Party {
        get {return party;}
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
