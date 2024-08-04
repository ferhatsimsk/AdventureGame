using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Belirli bir süre boyunca bekleyip sonra sahne değiştirme işlemi gerçekleştirilir.
public class SplashToMenu : MonoBehaviour {

	private WaitForSeconds wfsplashend; //beklenmesi gereken süreyi temsil eder.

    // wfsplashend nesnesi 5.5f süresiyle oluşturulur. Ardından, WaitForSplashEnd adlı bir yineleyici işlevin başlatılması için StartCoroutine("WaitForSplashEnd") çağrısı yapılır.
    void Start () {
		wfsplashend = new WaitForSeconds (5.5f);
		StartCoroutine ("WaitForSplashEnd");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //yield return wfsplashend; ifadesi kullanılarak belirtilen sürenin geçmesi beklenir. Ardından, SceneManager.LoadScene(4) ifadesiyle sahne değiştirme işlemi gerçekleştirilir. Bu kod, belirtilen sürenin ardından 4. sahneye geçiş yapar.
    IEnumerator WaitForSplashEnd() {
		yield return wfsplashend;
		SceneManager.LoadScene (4);
	}
}
