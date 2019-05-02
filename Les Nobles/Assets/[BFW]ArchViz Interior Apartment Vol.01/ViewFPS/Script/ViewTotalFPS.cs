using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewTotalFPS : MonoBehaviour {

	public Text TheLable;
	float LastTime=0;
	int TheFPS =0;
	// Use this for initialization
	void Start () {
		TheLable.text="";
	}

	// Update is called once per frame
	void LateUpdate () {
		TheFPS++;
		if (Time.time>LastTime+1)
		{
			LastTime = Time.time;
			TheLable.text="Total Frame:"+TheFPS;
			TheFPS=0;
		}
	}


}
