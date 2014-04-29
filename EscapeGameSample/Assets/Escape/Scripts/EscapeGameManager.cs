using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EscapeGameManager : MonoBehaviour
{
	public static BitArray clearFlag = new BitArray (2,false);

	public Transform defaultPos;
	EscapeGameObject _escapeGameObject;

	// Update()の前に一度だけ呼び出される
	void Start ()
	{
		foreach(bool flag in clearFlag){
			Debug.Log ("clearFlag:"+flag);
		}
	}

	// 毎フレーム呼び出される
	void Update ()
	{
		// マウス左クリック
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;


			bool isHit = Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition)
								, out hit
								, Mathf.Infinity);

			if (isHit) {
				EscapeGameObject eg = hit.transform.GetComponent<EscapeGameObject> ();

				if (eg != null) {
					if (canAction (eg)) {
						eg.OnAction ();
					} else {
						MoveCamera (eg.loolPos);
						_escapeGameObject = eg;
						_escapeGameObject.OnEnable ();
					}
				} else {
					MoveCamera (this.defaultPos);
					if (_escapeGameObject!=null) {
						_escapeGameObject.OnDisable ();
					}
					_escapeGameObject = null;
				}
			}
		}


	}

	void MoveCamera(Transform target){
		iTween.MoveTo(Camera.main.gameObject
			,iTween.Hash(
				"position",target.position
				,"time",1
				,"easetype",iTween.EaseType.easeOutQuad));

		iTween.RotateTo(Camera.main.gameObject
			, iTween.Hash("rotation", target.eulerAngles, "easeType", "easeOutQuad"));
	}

	bool canAction(EscapeGameObject eg){
		if(eg==this._escapeGameObject
			&& Camera.main.GetComponent<iTween>()==null){
			return true;
		}
		return false;
	}

	public static bool isClear(){
		bool resutl = true;
		foreach(bool flag in clearFlag){
			resutl &= flag;
		}
		return resutl;
	}
}
