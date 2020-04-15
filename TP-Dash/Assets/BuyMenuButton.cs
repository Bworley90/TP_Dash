using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BuyMenuButton : MonoBehaviour
{
    public Text TpToSpend;

    private void Update()
    {
        TpToSpend.text = StaticVariables.statics.tpMoney.ToString();
    }

    public void UpgradeSpeed()
    {
        if(StaticVariables.statics.tpMoney > 1)
        {
            StaticVariables.statics.cartSpeed += GameManager.gm.cartSpeedIncrease;
            StaticVariables.statics.tpMoney--;
        }
        
    }

    public void UpgradeLuckyStrike()
    {
        if(StaticVariables.statics.tpMoney > 1)
        {
            StaticVariables.statics.luckyStrike += GameManager.gm.luckyStrikeAmount;
            StaticVariables.statics.tpMoney--;
        }
    }

    public void UpgradeDiscoveryDuration()
    {
        if(StaticVariables.statics.tpMoney > 1)
        {
            StaticVariables.statics.discoverDistance += GameManager.gm.discoverDistanceAmount;
            StaticVariables.statics.tpMoney--;
        }
    }

    public void UpgradeTimeDuration()
    {
        if (StaticVariables.statics.tpMoney > 1)
        {
            StaticVariables.statics.levelDuration += GameManager.gm.levelDurationIncreaseAmount;
            StaticVariables.statics.tpMoney--;
        }
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(2);
    }

}
