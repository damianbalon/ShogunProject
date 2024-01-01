[System.Serializable]
public class DialogueStatus
{
    private bool isTrigered;
    private bool inQuestion;

    public bool IsTrigered
    {
        get { return isTrigered; }
        set { isTrigered = value; }
    }

    public bool InQuestion
    {
        get { return inQuestion; }
        set { inQuestion = value; }
    }
}
