using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour {
	
	private Transform Player;
	public float Velocidade;
	
	void Start() {
		
		Player = GameObject.FindGameObjectWithTag("Player").transform;
		if(Velocidade <= 0) {
		Velocidade=7;
		}
		
	} 
	void Update () {
		
		controleDaDistancia();
}
	void controleDaDistancia () {
	float distanciaAoPlayer = Vector3.Distance(transform.position, Player.position);
	if(distanciaAoPlayer <65 && distanciaAoPlayer > 1){
		seguirJogador(true);
			
		}else{
		seguirJogador(false);
		}
	}
	void seguirJogador (bool seguir) {
		if(seguir) {
		Vector3 Direcao = (Player.position - transform.position).normalized;
		transform.position =transform.position+Direcao * Time.deltaTime * Velocidade;
		Quaternion olharPara = Quaternion.LookRotation(Direcao);
		transform.rotation = olharPara;
	}else{ 
	return;
	}
}
}