using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters;
using UnityEngine.SceneManagement;
using TMPro;

public class GlobalHealth : MonoBehaviour
{

    public int PlayerHealth = 10; //Oyuncunun sağlık miktarı
    public Text HealthDisplay; //Oyuncunun sağlık durumunu kullanıcıya göstermek için

    public int InternalHealth;
    



    // Use this for initialization
    void Start()
    {

    }

    // sağlık durumunu günceller.
    //"HealthDisplay.text" özelliği, "InternalHealth" değerini kullanarak sağlık durumunu metin olarak günceller. Metin "Health: " ifadesiyle başlar ve ardından "InternalHealth" değeri eklenir.
    //Eğer "PlayerHealth" 0'a eşitse, "SceneManager.LoadScene(2)" komutuyla ikinci sahneye geçiş yapılır. Bu durumda, oyuncunun sağlık değeri sıfır olduğunda oyunun sona ermesi veya yeniden başlaması gibi bir işlem gerçekleştirilebilir.
    void Update()
    {
        InternalHealth = PlayerHealth;

        HealthDisplay.text = "Health: " + InternalHealth;
        if (PlayerHealth > 10)
        {
            PlayerHealth = 10;
        }
        if (PlayerHealth == 0)
        {
           
            Invoke("Restart", 5f);
            //SceneManager.LoadScene(3);

        }


    }

    private void Restart()
    {
        SceneManager.LoadScene("Level001");
    }


  
}
