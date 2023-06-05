using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordsController : MonoBehaviour
{
	public Text resRound11;
	public Text resRound12;
	public Text resRound13;
	public Text resRound21;
	public Text resRound22;
	public Text resRound23;
	public Text resRound31;
	public Text resRound32;
	public Text resRound33;
    void Update()
    {
		resRound11.text = "0";
		resRound12.text = "0";
		resRound13.text = "0";
		resRound21.text = "0";
		resRound22.text = "0";
		resRound23.text = "0";
		resRound31.text = "0";
		resRound32.text = "0";
		resRound33.text = "0";
        if (PlayerPrefs.HasKey("11score"))
		{	resRound11.text = PlayerPrefs.GetInt("11score").ToString();}
        if (PlayerPrefs.HasKey("12score"))
		{	resRound12.text = PlayerPrefs.GetInt("12score").ToString();}
        if (PlayerPrefs.HasKey("13score"))
		{	resRound13.text = PlayerPrefs.GetInt("13score").ToString();}
        if (PlayerPrefs.HasKey("21score"))
		{	resRound11.text = PlayerPrefs.GetInt("21score").ToString();}
        if (PlayerPrefs.HasKey("22score"))
		{	resRound12.text = PlayerPrefs.GetInt("22score").ToString();}
        if (PlayerPrefs.HasKey("23score"))
		{	resRound13.text = PlayerPrefs.GetInt("23score").ToString();}
        if (PlayerPrefs.HasKey("31score"))
		{	resRound21.text = PlayerPrefs.GetInt("31score").ToString();}
        if (PlayerPrefs.HasKey("32score"))
		{	resRound22.text = PlayerPrefs.GetInt("32score").ToString();}
        if (PlayerPrefs.HasKey("33score"))
		{	resRound23.text = PlayerPrefs.GetInt("33score").ToString();}
    }
}
