using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunDamage : MonoBehaviour {

	public int DamageAmount = 5; //her vuruşta hedefe verilecek hasar miktarını belirtir.
    public float AllowedRange = 15.0f; //oyuncunun ateş edebileceği maksimum mesafe
    public Transform TheZombieTransf; //zombiye verilecek hasarı kontrol etmek için

    //vuruş anında oluşturulacak olan nesneleri temsil eder.
    public GameObject TheBullet;
	public GameObject TheBlood;
	public GameObject TheGreenBlood;

	private float TargetDistance; //ateşin isabet ettiği hedefin oyuncudan olan uzaklığını tutar.
    private RaycastHit hit; //atışın isabet ettiği nesneyi tutar.


    // Use this for initialization
    void Start () {
		
	}

    /*
	 Raycast, isabet ettiği nesnenin etiketini kontrol eder ve uygun tepkiyi verir:

	Eğer isabet eden nesne "Zombie" etiketine sahipse, TheBlood nesnesi isabet noktasında oluşturulur ve vurulan zombiye "DeductPoints" fonksiyonu çağrılarak hasar miktarı iletilir.
	Eğer isabet eden nesne "ZombieHead" etiketine sahipse, TheBlood nesnesi oluşturulur ve vurulan zombiye daha yüksek bir hasar miktarı iletilir.
	Eğer isabet eden nesne "Spider" etiketine sahipse, TheGreenBlood nesnesi isabet noktasında oluşturulur ve vurulan örümceğe "DeductPoints" fonksiyonu çağrılarak hasar miktarı iletilir.
	Diğer durumlarda, TheBullet nesnesi isabet noktasında oluşturulur ve vurulan hedefe "DeductPoints" fonksiyonu çağrılarak hasar miktarı iletilir.
	Kod, vurulan hedefin etiketine bağlı olarak farklı tepkiler vererek, farklı türdeki düşmanlara zarar verebilmeyi sağlar.
	 */
    void Update () {		
		if (GlobalAmmo.LoadedAmmo >= 1) {
			if (Input.GetButtonDown ("Fire1")) {
				RaycastHit Shot;
				if (Physics.Raycast (transform.position, transform.forward, out Shot)) {
					TargetDistance = Shot.distance;
					if (TargetDistance < AllowedRange) {
						//Shot.transform.SendMessage ("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver);
						//Instantiate(TheBullet, Shot.point, Quaternion.FromToRotation(Vector3.up, Shot.normal));
						/*
						if (Physics.Raycast(transform.position, transform.forward, out hit)) {
							Instantiate(TheBullet, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
						}
						*/
						if (Shot.transform.tag == "Zombie") {
							Instantiate (TheBlood, Shot.point, Quaternion.FromToRotation (Vector3.up, Shot.normal));
							Shot.transform.SendMessage ("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver);
						} else if (Shot.transform.tag == "ZombieHead") {
							DamageAmount = 10;
							Instantiate (TheBlood, Shot.point, Quaternion.FromToRotation (Vector3.up, Shot.normal));
							TheZombieTransf.SendMessage ("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver);
						} else if (Shot.transform.tag == "Spider") {
							Instantiate (TheGreenBlood, Shot.point, Quaternion.FromToRotation (Vector3.up, Shot.normal));
							Shot.transform.SendMessage ("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver);
						} else {
							Instantiate(TheBullet, Shot.point, Quaternion.FromToRotation(Vector3.up, Shot.normal));
							Shot.transform.SendMessage ("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver);
						}
						DamageAmount = 5;
					}
				}
			}
		}
	}
}
