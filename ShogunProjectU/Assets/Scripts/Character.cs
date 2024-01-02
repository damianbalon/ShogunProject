using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private string charactername;

    [SerializeField] private int justice;
    [SerializeField] private int courage;
    [SerializeField] private int compassion;
    [SerializeField] private int respect;
    [SerializeField] private int integrity;
    [SerializeField] private int honor;
    [SerializeField] private int loyalty;

    public string Charactername
    {
        get { return charactername; }
    }

    public int Justice
    {
        get { return justice; }
        set { justice = Mathf.Clamp(value, 1, 7); }
    }

    public int Courage
    {
        get { return courage; }
        set { courage = Mathf.Clamp(value, 1, 7); }
    }

    public int Compassion
    {
        get { return compassion; }
        set { compassion = Mathf.Clamp(value, 1, 7); }
    }

    public int Respect
    {
        get { return respect; }
        set { respect = Mathf.Clamp(value, 1, 7); }
    }

    public int Integrity
    {
        get { return integrity; }
        set { integrity = Mathf.Clamp(value, 1, 7); }
    }

    public int Honor
    {
        get { return honor; }
        set { honor = Mathf.Clamp(value, 1, 7); }
    }

    public int Loyalty
    {
        get { return loyalty; }
        set { loyalty = Mathf.Clamp(value, 1, 7); }
    }

    public int GetAttributeValue(string attributeName)
    {
        switch (attributeName.ToLower())
        {
            case "justice":
                return Justice;
            case "courage":
                return Courage;
            case "compassion":
                return Compassion;
            case "respect":
                return Respect;
            case "integrity":
                return Integrity;
            case "honor":
                return Honor;
            case "loyalty":
                return Loyalty;
            default:
                // Handle unknown attribute name
                return 0;
        }

    }
        void Start()
    {
        // Initialization if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Update if needed
    }
}
