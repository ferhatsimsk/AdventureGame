using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Y�klenecek sahne ad�
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene(2); // �kinci sahnenin build indeksi (0'dan ba�lar)
    }
}
