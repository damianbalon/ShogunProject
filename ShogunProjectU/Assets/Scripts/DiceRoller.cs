using UnityEngine;

public static class DiceRoller
{
    public static int RollDice(int numberOfDice)
    {

        int successes = 0;
        int specialEffects = 0;

        for (int i = 0; i < numberOfDice; i++)
        {
            int rollResult = Random.Range(1, 6); 

            if (rollResult == 5 || rollResult == 6)
            {
                successes++;

                if (rollResult == 6)
                {
                    specialEffects++;
                }
            }
        }

        return successes > 0 ? specialEffects+1 : 0;
    }
    public static int RollDiceRaw(int numberOfDice) {
        int score = 0;
        for(int i = 0; i < numberOfDice; i++) {
            score += Random.Range(1, 6);
        }
        return score;
    }
}
