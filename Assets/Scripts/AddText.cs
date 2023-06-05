using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddText : MonoBehaviour
{
    [SerializeField]
	private Transform TaskPanel;
	
	[SerializeField]
	private GameObject txt;
	
	private int numberOfNumbers = 12;
	
    void Awake()
	{
		if(SceneManager.GetActiveScene().name=="11round")
		{
			numberOfNumbers = 3;
		}
		if(SceneManager.GetActiveScene().name=="12round")
		{
			numberOfNumbers = 6;
		}
		if(SceneManager.GetActiveScene().name=="13round")
		{
			numberOfNumbers = 9;
		}
		for (int i = 0; i < numberOfNumbers; i++) {
			GameObject text = Instantiate(txt);
			text.name = "" + i;
			text.transform.SetParent(TaskPanel, false);
		}
	}
}