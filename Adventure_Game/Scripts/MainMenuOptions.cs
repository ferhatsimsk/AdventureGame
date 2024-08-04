using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuOptions : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //oyun sahnesinin yüklenmesi 
	//Play button
    public void PlayGame() {
		SceneManager.LoadScene (1);
	}

    
}
