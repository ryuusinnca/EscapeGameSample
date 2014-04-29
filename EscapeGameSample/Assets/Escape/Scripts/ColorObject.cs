using UnityEngine;
using System.Collections;

public class ColorObject : EscapeGameObject {

	public int flagNo=0;

	Material[] _materialArray;
	int _materialNo = 0;
	void Start(){
		_materialArray = new Material[] {
			Resources.Load ("Material/gray") as Material
			, Resources.Load ("Material/red") as Material
			, Resources.Load ("Material/green") as Material
			, Resources.Load ("Material/blue") as Material
		};

		if (!EscapeGameManager.clearFlag [flagNo]) {
			_materialNo = Random.Range (1, _materialArray.Length);
		}
		this.renderer.material = _materialArray [_materialNo];

	}

	void OnDestroy(){

	}

	public override void OnAction ()
	{
		_materialNo = Random.Range (0, _materialArray.Length);
		this.renderer.material = _materialArray [_materialNo];
		EscapeGameManager.clearFlag [flagNo] = (_materialNo == 0);
	}

}
