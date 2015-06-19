using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {

	public GameObject player;
	public string levelToLoad;//level we're playing
	public string next;//the next level
	public bool pause = false;
	private WheelJointBikeMovement script;

	void Awake(){
		script = player.GetComponent<WheelJointBikeMovement> ();
	}

	void Start () {
		Time.timeScale = 0;


	}


	void OnTriggerEnter2D(Collider2D col){

		pause = true;

		if (pause) {
			Time.timeScale=0;

		}	
	}

	private void OnGUI()
	{
				
		if (pause){    
			
			GUI.Box(new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), "Level Cleared");
			//GUI.Label(new Rect(Screen.width/4+10, Screen.height/4+Screen.height/10+10, Screen.width/2-20, Screen.height/10), "YOUR SCORE: "+ ((int)score));
			
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+Screen.height/10+10, Screen.width/2-20, Screen.height/10), "Restart")){
				Application.LoadLevel(Application.loadedLevel);
			}
			
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+2*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "Main Menu")){
				Application.LoadLevel(levelToLoad);
			}
			
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+3*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "Next Level")){
				Application.LoadLevel(next);
			} 
		}
	}
}
