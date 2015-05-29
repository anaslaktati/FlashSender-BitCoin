using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void Practice(){
		Application.LoadLevel ("SelectLevel");
	}

	public void Play(){
		Application.LoadLevel (null);
	}

	public void Exit(){
		Application.Quit ();
	}
}
