using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ShoppingItem1Controller : MonoBehaviour
{
    public GlobalScore globalScore;
    public TextMeshProUGUI redpriceItemText;
    public TextMeshProUGUI bluepriceItemText;
    public TextMeshProUGUI blackpriceItemText;
    public FirstPersonController fpc;
    public GameObject shoppingUI;

    public void UseRed()
    {


        int price = int.Parse(redpriceItemText.text);

        if (globalScore.CurrentScore >= price && int.Parse(globalScore.ScoreText.text) >= price)
        {
            globalScore.CurrentScore -= price;
            int updatedScore = int.Parse(globalScore.ScoreText.text) - price;
            updatedScore = Mathf.Max(updatedScore, 0); // Skoru en düþük 0 olarak sýnýrla
            globalScore.ScoreText.text = updatedScore.ToString();
            fpc.m_JumpSpeed += 2;
        }

    }


    public void UseBlue()
    {


        int price = int.Parse(bluepriceItemText.text);

        if (globalScore.CurrentScore >= price && int.Parse(globalScore.ScoreText.text) >= price)
        {
            globalScore.CurrentScore -= price;
            int updatedScore = int.Parse(globalScore.ScoreText.text) - price;
            updatedScore = Mathf.Max(updatedScore, 0); // Skoru en düþük 0 olarak sýnýrla
            globalScore.ScoreText.text = updatedScore.ToString();
            fpc.m_RunSpeed += 2;
        }

    }

    public void UseBlack()
    {


        int price = int.Parse(blackpriceItemText.text);

        if (globalScore.CurrentScore >= price && int.Parse(globalScore.ScoreText.text) >= price)
        {
            globalScore.CurrentScore -= price;
            int updatedScore = int.Parse(globalScore.ScoreText.text) - price;
            updatedScore = Mathf.Max(updatedScore, 0); // Skoru en düþük 0 olarak sýnýrla
            globalScore.ScoreText.text = updatedScore.ToString();
            fpc.m_JumpSpeed += 50;
        }

    }



    void Update()
    {
        if (shoppingUI.activeSelf && Input.GetKeyDown(KeyCode.L))
        {
            UseBlack();
        }
        else if (shoppingUI.activeSelf && (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8)))
        {
            UseBlue();
        }
        else if (shoppingUI.activeSelf && (Input.GetKeyDown(KeyCode.Keypad9) || Input.GetKeyDown(KeyCode.Alpha9)))
        {
            UseRed();
        }
    }
}
