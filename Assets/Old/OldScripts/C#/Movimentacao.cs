using UnityEngine;
using System.Collections;

public class Movimentacao : MonoBehaviour {
	
	public static float velocidadeFrente = 1.0f;
	
	public static float velocidadeLado = 1.0f;
	
	
	void Start () {
	
		velocidadeFrente = 12f;
		velocidadeLado = 8f;

	}
	

	void Update () {
//MovimentaÃ§Ã£o	

if(Input.GetKey("w")) {
 transform.Translate(velocidadeFrente * Time.deltaTime,0,0);
		}
if(Input.GetKey("s")) {
 transform.Translate(-velocidadeFrente * Time.deltaTime,0,0);
		}
if(Input.GetKey("a")) {
 transform.Translate(0,0,velocidadeLado * Time.deltaTime);
		}
if(Input.GetKey("d")) {
 transform.Translate(0,0,-velocidadeLado * Time.deltaTime);
		}
	}
}
