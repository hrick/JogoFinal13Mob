using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemScript : MonoBehaviour {

	public GameObject personagem;
	public float velocidade;

	Vector3 novaPosicao;
	Animation ani;

	void OnCollisionEnter(Collision c){
		if (c.gameObject.tag == "item") {
			Destroy (c.gameObject);
		}
	}


	void Start () {
		// Captura a posicao inicial do personagem
		novaPosicao = transform.position;
		ani = personagem.GetComponent<Animation> ();

		// Define a animacao inicial do personagem
		ani.CrossFade("idle");
	}

	void Update () {
	
		// Touch ou clique do mouse
		if (Input.GetButton ("Fire1") ) {			
			// Transforma o clique na tela em coordenada 3D
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			// Obtem a nova posica
			if (Physics.Raycast (ray, out hit)) {
				novaPosicao = hit.point;
			}

			// Move o personagem e orienta o personagem
			transform.position = Vector3.MoveTowards (transform.position, novaPosicao, velocidade * Time.deltaTime);
			transform.LookAt (hit.point);

			// Animacao de run
			ani.CrossFade("run");

		} else {
			// Animacao de idle
			ani.CrossFade("idle");
		}

	}

}
