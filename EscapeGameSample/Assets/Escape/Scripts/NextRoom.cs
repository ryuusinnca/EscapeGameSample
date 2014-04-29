using UnityEngine;
using System.Collections;

public class NextRoom : EscapeGameObject {
	public GameObject text;
	public string sceneName;

	void Start(){
		text.SetActive (false);
	}

	public override void OnAction ()
	{
		Application.LoadLevel (sceneName);
	}

	public override void OnEnable ()
	{
		text.SetActive (true);
	}

	public override void OnDisable ()
	{
		text.SetActive (false);
	}
}
