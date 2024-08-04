using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Yüklenecek sahne adý
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene(2); // Ýkinci sahnenin build indeksi (0'dan baþlar)
    }
}
