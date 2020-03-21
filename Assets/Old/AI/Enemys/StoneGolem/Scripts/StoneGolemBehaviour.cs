using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoneGolemBehaviour : MonoBehaviour {
	
//Detected Target
	public bool detectedTarget;	
	public Transform Target;
//Movimentation
	public float timeToCanDie;
	public float attackDelay;
	public float movimenationSpeed;
	public bool collide;
	public AnimationClip attack;
//Life
	public float life;
//
	void Start () {
		life = 20;
	}
	
	void Update () {
		//Target Detection
		attackDelay += Time.deltaTime;
		timeToCanDie += Time.deltaTime;
		Target = GameObject.FindGameObjectWithTag("Player").transform;
		float distanceToDetect = Vector3.Distance(transform.position, Target.position);
		if(distanceToDetect < 40){
		detectedTarget = true;	
		}
		if(distanceToDetect < 60 && Input.GetMouseButtonDown(0)){
		detectedTarget = true;	
		}
		if(distanceToDetect > 70){
		detectedTarget = false;	
		}
		if(distanceToDetect < 2 && attackDelay > 0.8F){
		collide = true;
		attackDelay = 0;
		}
		if(collide){
		GetComponent<Animation>().Stop();
		GetComponent<Animation>().Play("attack");
		collide = false;
		}

	if(detectedTarget){
		Follow();
		}
		//
		if(life < 0.1F && timeToCanDie > 0.3F){
			Destroy(gameObject);
		}
	}
	
	void OnCollision (Collision collision) {
		if(collision.gameObject.tag == "Fire"){
		life = life-10;
		}
	}
	
	void Follow () {
		if(!GetComponent<Animation>().isPlaying){
			GetComponent<Animation>().Play("walking");	
		}
		Vector3 Direction = (Target.position - transform.position).normalized;
		transform.position =transform.position+Direction*Time.deltaTime*movimenationSpeed;
		Quaternion lookTo = Quaternion.LookRotation(Direction);
		transform.rotation = lookTo;	
	}
}
