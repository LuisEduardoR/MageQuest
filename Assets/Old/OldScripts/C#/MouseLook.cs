using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {
	
	private Transform Player, Cam;
	public static float velocidadeRotacao, velocidadeMovimento;

	void Start () {
		
	Screen.lockCursor = true;	
	velocidadeRotacao = 70f;
	velocidadeMovimento = 10f;
		
	Player = GetComponent<Transform>();
	Cam    = GameObject.FindGameObjectWithTag("Camera").GetComponent<Transform>();
		
	}
	

	void Update () {
		
	float orientacaoX = Input.GetAxis("Mouse X");
	float orientacaoY = Input.GetAxis("Mouse Y");
	
		if((orientacaoX != 0) || (orientacaoY != 0)) {
	
			_mouseLook(orientacaoX, orientacaoY);
		  }

	
	}
	
	void _mouseLook(float orientacaoX, float orientacaoY){
	
		if(orientacaoX != 0){
			
		Player.eulerAngles += Vector3.up*Time.deltaTime * orientacaoX * velocidadeRotacao;
	
		}	
	
	}
}
