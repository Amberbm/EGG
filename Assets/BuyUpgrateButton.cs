using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyUpgrateButton : MonoBehaviour
{
    public static Upgrade upgrade;
    public Text text;
    public Text description;

    void Start()
    {
        SetUpdate();
    }
    // Update is called once per frame
    void Update()
    {
        //checks wheather the player should be able to press the buybutton
        
            if (upgrade != null)
            {
                if (upgrade.price <= MoneyManager.amount)
                    GetComponent<Button>().interactable = true;
                else
                    GetComponent<Button>().interactable = false;
            }
    }

    public void SetUpdate()
    {
        upgrade = PropertyManager.AllUpgrades.Find(x => x.upgradeLevel == PropertyManager.UpgradeLevel +1);
        if (upgrade != null)
        {
            text.text = upgrade.upgradeName;
            description.text = upgrade.Description;
        }
        else
        {
            text.text = "";
            description.text = "";
        }

    }
}
