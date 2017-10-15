using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour {

    Transform followTarget;
    Vector3 offset;

	void Start () {
        offset = transform.position;
        followTarget = PlayerManager.instance.player.transform;
	}
	
	void LateUpdate () {
        transform.position = followTarget.position + offset;
	}
}
