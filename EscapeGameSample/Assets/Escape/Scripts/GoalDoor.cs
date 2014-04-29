using UnityEngine;
using System.Collections;

public class GoalDoor : EscapeGameObject {
	public GameObject text1;
	public GameObject text2;
	public string sceneName;

	void Start(){
		text1.SetActive (false);
		text2.SetActive (false);
	}

	public override void OnAction ()
	{
		if(EscapeGameManager.isClear()){
			Application.LoadLevel (sceneName);
		}
	}

	public override void OnEnable ()
	{
		if (EscapeGameManager.isClear ()) {
			text1.SetActive (true);
		} else {
			text2.SetActive (true);
		}

	}

	public override void OnDisable ()
	{
		text1.SetActive (false);
		text2.SetActive (false);
	}
}
