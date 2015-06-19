using UnityEngine;
using System.Collections;

public class SelectLevel : MonoBehaviour {

	public string level1, level2, level3;

	public void Level1(){

		Application.LoadLevel (level1);
	}

	public void Level2(){
		Application.LoadLevel (level2);
	}

	public void Level3(){
		Application.LoadLevel (level3);
	}
}
