using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnLevel : MonoBehaviour {

    // 1 numaralı sahneyi yüklemek için
    void Start () {
		SceneManager.LoadScene (1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
