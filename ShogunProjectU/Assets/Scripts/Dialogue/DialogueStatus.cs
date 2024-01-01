public static class DialogueStatus
{
    private static bool isTrigered = false;
    private static bool inQuestion = false;

    public static bool IsTrigered
    {
        get { return isTrigered; }
        set { isTrigered = value; }
    }

    public static bool InQuestion
    {
        get { return inQuestion; }
        set { inQuestion = value; }
    }
}
