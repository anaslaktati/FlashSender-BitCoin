using UnityEngine;
using System.Collections;

public class SelectLevel : MonoBehaviour {


	public void Level1(){

		Application.LoadLevel ("TestScene");
	}

	public void Level2(){
		Application.LoadLevel (null);
	}

	public void Level3(){
		Application.LoadLevel (null);
	}
}
