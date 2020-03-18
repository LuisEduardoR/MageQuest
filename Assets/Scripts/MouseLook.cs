using UnityEngine;
using System.Collections;

using MageQuest.Player;

public class MouseLook : MonoBehaviour {
	
	private PlayerScript player;
	private Transform PlayerTransform, Cam;
	public static float velocidadeRotacao, velocidadeMovimento;

	void Start () {
		
	Screen.lockCursor = true;	
	velocidadeRotacao = 70f;
	velocidadeMovimento = 10f;
	
	player = FindObjectOfType<PlayerScript>();
	PlayerTransform = player.transform;
	Cam    = GameObject.FindGameObjectWithTag("Camera").GetComponent<Transform>();
		
	}
	

	void Update () {
		
		if(player.isPaused)
			return;

	float orientacaoX = Input.GetAxis("Mouse X");
	float orientacaoY = Input.GetAxis("Mouse Y");
	
		if((orientacaoX != 0) || (orientacaoY != 0)) {
	
			_mouseLook(orientacaoX, orientacaoY);
		  }

	
	}
	
	void _mouseLook(float orientacaoX, float orientacaoY){
	
		if(orientacaoX != 0){
			
		PlayerTransform.eulerAngles += Vector3.up*Time.deltaTime * orientacaoX * velocidadeRotacao;
	
		}	
	
	}
}
