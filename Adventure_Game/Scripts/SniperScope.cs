using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Bu kod parçacığı, fare sağ tıklandığında birinci şahıs kamerayı zoomlamak için kullanılabilir.
public class SniperScope : MonoBehaviour {


	public Camera FPCCam; //birinci şahıs kamera
    public GameObject Cursor; //fare imlecinin temsil edildiği
    public GameObject SniperScopeTex; //nişangahın temsil edildiği 
    public int fieldView = 60; // kameranın görüş açısını kontrol eder.


    private bool zoomingIn = false; //zoom işleminin gerçekleşip gerçekleşmediğini belirten bir bayraktır.
    private WaitForSeconds wfsZoomTempo; //zoom işlemi sırasında beklemek için

    // wfsZoomTempo değişkenini ayarlar.
    void Start () {
		wfsZoomTempo = new WaitForSeconds (0.01f);
	}

    // zoom işlemini kontrol eder.
    //Input.GetMouseButtonDown(1) ifadesi, fare düğmesine sağ tıklandığında çalışır.
    //Eğer zoom işlemi gerçekleşmiyorsa, fare imleci gizlenir, nişangah görünür hale getirilir ve ZoomingCam adlı bir işlem başlatılır.
    //Input.GetMouseButtonUp(1) ifadesi, fare düğmesinden sağ tıklama işlemi bırakıldığında çalışır.
    //Tüm işlemler durdurulur, görüş açısı varsayılan değere döndürülür, fare imleci yeniden görünür hale getirilir ve nişangah gizlenir.
    void Update () {
		if (Input.GetMouseButtonDown (1)) {
			if (!zoomingIn) {
				Cursor.SetActive (false);
				SniperScopeTex.SetActive (true);
				StartCoroutine ("ZoomingCam");
				zoomingIn = true;
			}
		}
		if (Input.GetMouseButtonUp (1)) {
			StopAllCoroutines ();
			fieldView = 60;
			FPCCam.fieldOfView = fieldView;
			Cursor.SetActive(true);
			SniperScopeTex.SetActive (false);
			zoomingIn = false;
		}
	}

    // zoom işlemini gerçekleştirir.
    //fieldView değeri 25'ten büyük olduğu sürece döngü devam eder.
    //Her döngüde fieldView değeri azaltılır ve kamera görüş açısı güncellenir.
    //yield return wfsZoomTempo ifadesi, belirli bir süre beklemek için kullanılır.

    IEnumerator ZoomingCam() {
		while (fieldView > 25) {
			FPCCam.fieldOfView = fieldView;
			fieldView -= 2;
			yield return wfsZoomTempo;
		}
	}
}
