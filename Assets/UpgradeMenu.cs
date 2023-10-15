using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] private ThirdPersonCharacterController ThirdPerson;
    [SerializeField] private ScoreUpdate scoreUpdate;
    [SerializeField] private UpgradeThrowSpeed thrower;

    private int score;

    private int cost1;
    private int cost2;
    private int cost3;
    private int cost4;
    private int cost5;

    private void Update()
    {
        score = scoreUpdate.score;

        cost1 = 40;
        cost2 = 40;
        cost3 = 40;
        cost4 = 40;
        cost5 = 40;
    }

    public void UpgradeHealth()
    {
        if(score >= cost1)
        {
            ThirdPerson.UpgradeHealth(20);
            scoreUpdate.score -= cost1;

            cost1 *= 2;
        }
    }
    public void UpgradeSpeed()
    {
        if (score >= cost2)
        {
            ThirdPerson.UpgradeSpeed(2f);
            scoreUpdate.score -= cost2;

            cost2 *= 2;
        }
    }

    public void UpgradeJump()
    {
        if (score >= cost3)
        {
            ThirdPerson.UpgradeJump(0.2f);
            scoreUpdate.score -= cost3;

            cost3 *= 2;
        }
    }

    public void UpgradeThrow()
    {
        if (score >= cost4)
        {
            thrower.UpgradeThrow(2f);
            scoreUpdate.score -= cost4;

            cost4 *= 2;
        }
    }

    public void Heal()
    {
        if (score >= cost5)
        {
            if(ThirdPerson.playerHealth <= ThirdPerson.playerMaxHealth) 
            {
                ThirdPerson.Heal(10);
                scoreUpdate.score -= cost5;

                cost5 *= 2;
            }
        }
    }
}
