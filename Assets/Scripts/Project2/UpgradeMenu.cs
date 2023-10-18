using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] private ThirdPersonCharacterController ThirdPerson;
    [SerializeField] private ScoreUpdate scoreUpdate;
    [SerializeField] private UpgradeThrowSpeed thrower;
    [SerializeField] private TMP_Text CostText1;
    [SerializeField] private TMP_Text CostText2;
    [SerializeField] private TMP_Text CostText3;
    [SerializeField] private TMP_Text CostText4;
    [SerializeField] private TMP_Text CostText5;


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
        cost5 = 5;
    }

    public void UpgradeHealth()
    {
        if(score >= cost1)
        {
            ThirdPerson.UpgradeHealth(20);
            scoreUpdate.score -= cost1;

            cost1 = cost1 * 2;

            CostText1.SetText(cost1.ToString());
        }
    }
    public void UpgradeSpeed()
    {
        if (score >= cost2)
        {
            ThirdPerson.UpgradeSpeed(0.5f);
            scoreUpdate.score -= cost2;

            cost2 = cost2 * 2;
            CostText2.SetText(cost2.ToString());
        }
    }

    public void UpgradeJump()
    {
        if (score >= cost3)
        {
            ThirdPerson.UpgradeJump(0.1f);
            scoreUpdate.score -= cost3;

            cost3 = cost3 * 2;
            CostText3.SetText(cost3.ToString());
        }
    }

    public void UpgradeThrow()
    {
        if (score >= cost4)
        {
            thrower.UpgradeThrow(0.2f);
            scoreUpdate.score -= cost4;

            cost4 = cost4 * 2;
            CostText4.SetText(cost4.ToString());
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

                cost5 = cost5 * 2;
                CostText5.SetText(cost5.ToString());
            }
        }
    }
}
