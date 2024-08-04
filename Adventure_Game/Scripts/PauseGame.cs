using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using System.IO;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

	public FirstPersonController ThePlayer; //oyuncunun hareketini yönetir.
    public GameObject PauseMenu; //duraklatma menüsünü (pause menüsünü) temsil eder.

    private bool paused = false; //oyunun duraklatılıp duraklatılmadığını tutar.


    // oyunun duraklatılıp duraklatılmadığını tutar.
    void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

    // oyun duraklatma düğmesine basılıp basılmadığını kontrol eder. Eğer duraklatma düğmesine basıldıysa, durumuna göre oyunu duraklatır veya devam ettirir.
    //Input.GetButtonDown("Pause") ifadesi, "Pause" adlı bir düğmeye basıldığında true değeri döndürür. Bu durumda, eğer oyun duraklatılmamışsa, fare imleci kilidini kaldırır, görünür yapar, zaman ölçeğini 0.0f yapar (oyunu duraklatır), paused değişkenini true yapar, oyuncu hareketini devre dışı bırakır ve duraklatma menüsünü etkinleştirir. Eğer oyun zaten duraklatılmışsa, ResumeGame işlevini çağırarak oyunu devam ettirir.
    //
	void Update () {
		if (Input.GetButtonDown ("Pause")) {
			if (!paused) {
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				Time.timeScale = 0.0f;
				paused = true;
				ThePlayer.enabled = false;
				PauseMenu.SetActive(true);
			} else {
				ResumeGame ();
			}
		}
	}

    //ResumeGame işlevi, oyunu devam ettirir. Fare imleci görünürlüğünü kapatır, zaman ölçeğini 1.0f yapar (oyunu normal hızda devam ettirir), paused değişkenini false yapar, oyuncu hareketini etkinleştirir ve duraklatma menüsünü devre dışı bırakır.
    public void ResumeGame() {
		Cursor.visible = false;
		Time.timeScale = 1.0f;
		paused = false;
		ThePlayer.enabled = true;
		PauseMenu.SetActive(false);
	}

 
}
