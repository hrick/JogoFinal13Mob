using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerarAboboras : MonoBehaviour {

	public float limiteEsquerdo, limiteDireito, limiteFrontal, limiteTraseiro;
	public float frequencia;
	public GameObject aboboraPrefab;

	IEnumerator Start () {
		
		yield return new WaitForSeconds (Random.Range (3.0f, frequencia));
		Vector3 posicao;
		posicao.x = Random.Range (limiteEsquerdo, limiteDireito);
		posicao.y = transform.position.y;
		posicao.z = Random.Range (limiteFrontal, limiteTraseiro);
		Instantiate (aboboraPrefab, posicao, transform.rotation);
		StartCoroutine (Start ());
		
	}	

}
