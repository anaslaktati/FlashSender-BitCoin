using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour 
{
	public GUISkin myskin;  //custom GUIskin 
	public string levelToLoad;
	public bool paused = false;
	
	private void Start()
	{
		Time.timeScale=1; //Set the timeScale back to 1 for Restart option to work  
	}
	
	private void Update()
	{
		
		if (Input.GetKeyDown(KeyCode.Escape) ) //check if Escape key/Back key is pressed
		{
			paused = !paused ;
		}
		
		if(paused)
			Time.timeScale = 0;  //set the timeScale to 0 so that all the procedings are halted
		else
			Time.timeScale = 1;  //set it back to 1 on unpausing the game
		
	}
	
	private void OnGUI()
	{
		GUI.skin=myskin;   //use the custom GUISkin
		
		if (paused){    
			
			GUI.Box(new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), "PAUSED");
			//GUI.Label(new Rect(Screen.width/4+10, Screen.height/4+Screen.height/10+10, Screen.width/2-20, Screen.height/10), "YOUR SCORE: "+ ((int)score));
			
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+Screen.height/10+10, Screen.width/2-20, Screen.height/10), "RESUME")){
				paused = false;
			}
			
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+2*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "RESTART")){
				Application.LoadLevel(Application.loadedLevel);
			}
			
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+3*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "MAIN MENU")){
				Application.LoadLevel(levelToLoad);
			} 
		}
	}
}