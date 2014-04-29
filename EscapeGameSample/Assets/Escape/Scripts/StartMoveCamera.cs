using UnityEngine;
using System.Collections;

public class StartMoveCamera : MonoBehaviour {

	public Transform beginPos;
	public Transform endPos;

	// Use this for initialization
	void Start () {
		Camera.main.transform.position = beginPos.position;
		Camera.main.transform.rotation = beginPos.rotation;

		iTween.MoveTo(Camera.main.gameObject
			,iTween.Hash(
				"position",endPos.position
				,"time",1
				,"easetype",iTween.EaseType.easeOutQuad));

		iTween.RotateTo(Camera.main.gameObject
			, iTween.Hash("rotation", endPos.eulerAngles, "easeType", "easeOutQuad"));
	}

}
