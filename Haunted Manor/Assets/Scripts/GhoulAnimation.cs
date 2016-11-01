using UnityEngine;
using System.Collections;
using System;

public class GhoulAnimation : MonoBehaviour {

  public GameObject ghoulPrefab;
  Animator animator;
  Vector3 position;
  Vector3 lastPosition;


  void Start () {
    animator = ghoulPrefab.GetComponent<Animator>();
    position = ghoulPrefab.GetComponent<Transform>().position;
    lastPosition = position;
  }
	
	// Update is called once per frame
	void Update () {
    position = ghoulPrefab.GetComponent<Transform>().position;
    CheckAnimationState();
    lastPosition = position;
	}

  private void CheckAnimationState()
  {
    if(position != lastPosition)
    {
      animator.SetTrigger("isMoving");
    }
    else
    {
      animator.SetTrigger("isIdle");
    }
  }
}
