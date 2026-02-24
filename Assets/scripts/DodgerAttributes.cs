using UnityEngine;

public class DodgerAttributes
{
    int currentHealth;
    int maximumHealth;
    int currentscore;


    public DodgerAttributes(int startHealth, int maxHealth, int startscore)
    {
    currentHealth = startHealth;
    maximumHealth = maxHealth;
    currentscore = startscore;
    }

    public int GetcurrentHealth()
    {
        return currentHealth;
    }

    public int GetmaxHealth()
    {
        return maximumHealth;
    }

    public int Getcurrentscore()
    {
        return currentscore;
    }


    public void currentHealthBaseValue (int updateHealth)
    {
        currentHealth = updateHealth;
    }

    public void currentscoreBaseValue (int updatescore)
    {
        currentscore = updatescore;
    }



}    