using UnityEngine;
using System.Collections;

public class DissolveModel : MonoBehaviour {

	//public Transform newTarget;
	private float dissolveDegree = 0.0f;
	
	//var for geting the current-used material.
	private Material curMat;
	
	public float dissolveSpeed = 0.2f;
		
	// Use this for initialization
	void Start () {
		//Get the material of this object.
		//curMat = renderer.sharedMaterial;
		curMat =   GetComponent<Renderer>().material;
		//Firstly, the model is not dissolved. set the degree to 0.
		curMat.SetFloat("_Amount", 0.0f);
		dissolveDegree = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump"))
		{
			//FollowObject tmpObj = this.GetComponent<FollowObject>();
			//tmpObj.target = newTarget;
			
			StartCoroutine(Dissolving(dissolveSpeed));
			//curMat.SetFloat("_Amount", dissolveDegree);
		}

		if(Input.GetButtonDown("Jump") && curMat.GetFloat("_Amount") >= 1)
		{
			dissolveDegree = 0.0f;
			curMat.SetFloat("_Amount", dissolveDegree);
		}
	}
	
	//yield return new WaitForSeconds(
	IEnumerator Dissolving(float speed)
	{

		//start the counter for dissolving the model by adding the degree upto 1.
		if(dissolveDegree <= 1.0f)
		{
			//每次變動多少
			dissolveDegree += 0.1f;
			
			//print (dissolveDegree);
		
			//the dissoving progress with discount the degree.
			curMat.SetFloat("_Amount", dissolveDegree);
			//delay.等待
			yield return new WaitForSeconds(speed);
			//repeat the function after delay.重複呼叫
			StartCoroutine(Dissolving(speed));
		}		
	}
}
