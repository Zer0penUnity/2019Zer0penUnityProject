using UnityEngine;
using System.Collections;

public class CamController : MonoBehaviour {

    public Transform TargetTr;
    public Vector3 CamPos = new Vector3(0, 2, -3);

    private Transform tr;

	// Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        tr.position = Vector3.Lerp(tr.position, TargetTr.position + CamPos, 1f);
        tr.LookAt(TargetTr);
	}
}
