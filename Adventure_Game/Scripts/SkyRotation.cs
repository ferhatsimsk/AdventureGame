using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyRotation : MonoBehaviour {

	public float RotateSpeed = 0.5f; // Skybox'ın dönme hızını kontrol eder. Varsayılan değeri 0.5f olarak belirlenmiştir.

    // Use this for initialization
    void Start () {
		
	}

    // _Rotation özelliğini kullanarak Skybox'ın dönme miktarını ayarlar. Time.time zamanı kullanarak dönme hızını hesaplar ve RotateSpeed değişkeniyle çarparak dönme hızını kontrol eder.
    void Update () {
		RenderSettings.skybox.SetFloat ("_Rotation", Time.time * RotateSpeed);
	}
}
