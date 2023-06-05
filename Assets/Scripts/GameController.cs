using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	private Color redbrown = new Color32(111, 31, 31, 255);
	private Color yellowgreen = new Color32(32, 176, 5, 255);
	private int numberOfNumbers = 12;
	public float timeStart = 20f;
	public float beforeTime = 0f;
	public Text Timer;
	public GameObject Tasks;
	public GameObject Answers;
	public GameObject Results;
	public GameObject APanel;
	public Button doneButton;
	private bool needUpdate = true;
	public int Score = 0;
	public Text ResultScore;
	
	public List<Text> txts = new List<Text>();
	public List<InputField> anss = new List<InputField>();
	
	void Awake()
	{
		if(SceneManager.GetActiveScene().name=="11round")
		{
			numberOfNumbers = 3;
			timeStart = 10;
		}
		if(SceneManager.GetActiveScene().name=="12round")
		{
			numberOfNumbers = 6;
			timeStart = 10;
		}
		if(SceneManager.GetActiveScene().name=="13round")
		{
			numberOfNumbers = 9;
			timeStart = 10;
		}
		APanel.SetActive (false);
		Tasks.SetActive (true);
		Answers.SetActive (false);
		AddListener();
	}
	
    void Start()
    {	
		if ((SceneManager.GetActiveScene().name == "21round") || (SceneManager.GetActiveScene().name == "22round") || (SceneManager.GetActiveScene().name == "23round"))
		{
			APanel.SetActive (true);
			Tasks.SetActive (false);
			beforeTime = 20f;
		}
		APanel.SetActive (false);
		Tasks.SetActive (true);
		GetTexts();
        Timer.text = timeStart.ToString();
    }
	
    void Update()
    {
		if (beforeTime > 0)
		{
			Tasks.SetActive(false);
			APanel.SetActive(true);
			beforeTime -= Time.deltaTime;
			Timer.text = Mathf.Round(beforeTime).ToString();
		} else {
			if (timeStart > 0)
			{
				APanel.SetActive (false);
				Tasks.SetActive (true);
				timeStart -= Time.deltaTime;
				Timer.text = Mathf.Round(timeStart).ToString();
			} else {
				if (needUpdate)
				{
					Tasks.SetActive (false);
					Answers.SetActive (true);
					doneButton.gameObject.SetActive(true);
					Timer.gameObject.SetActive(false);
					needUpdate = false;
					GetResults();
				}
			}
		}
    }
	
	void GetTexts()
	{
		GameObject[] objects = GameObject.FindGameObjectsWithTag ("Text");
		for (int i = 0; i < objects.Length; i++)
		{
			txts.Add(objects[i].GetComponent<Text>());
			string temp = Random.Range(9, 100).ToString();
			for (int j = 0; j < txts.Count; j++)
			{
				while (txts[j].text == temp)
				{
					temp = Random.Range(9, 100).ToString();
				}
			}
			txts[i].text = temp;
			if(SceneManager.GetActiveScene().name=="33round" || SceneManager.GetActiveScene().name=="23round" || SceneManager.GetActiveScene().name=="22round")
			{
				txts[i].color = redbrown;
			}
			if(SceneManager.GetActiveScene().name=="31round")
			{
				txts[i].color = yellowgreen;
			}
		}
	}
	
	void GetResults()
	{
		GameObject[] objects = GameObject.FindGameObjectsWithTag ("Answer");
		for (int i = 0; i < objects.Length; i++)
		{
			anss.Add(objects[i].GetComponent<InputField>());
		}
	}
	
	void AddListener()
	{
		doneButton.onClick.AddListener(() => GameFinished());
	}
	
	void GameFinished()
	{
		Answers.SetActive (false);
		doneButton.gameObject.SetActive(false);
		Results.SetActive (true);
		for (int i = 0; i < anss.Count; i++)
		{
			if (anss[i].text == txts[i].text)
			{
				Score += 1;
			}
		}
		if (SceneManager.GetActiveScene().name=="13round" && (Score > PlayerPrefs.GetInt("13score") || !PlayerPrefs.HasKey("13score")))
		{
			PlayerPrefs.SetInt ("13score", Score);
		}
		if (SceneManager.GetActiveScene().name=="12round" && (Score > PlayerPrefs.GetInt("12score") || !PlayerPrefs.HasKey("12score")))
		{
			PlayerPrefs.SetInt ("12score", Score);
		}
		if (SceneManager.GetActiveScene().name=="11round" && (Score > PlayerPrefs.GetInt("11score") || !PlayerPrefs.HasKey("11score")))
		{
			PlayerPrefs.SetInt ("11score", Score);
		}
		if (SceneManager.GetActiveScene().name=="23round" && (Score > PlayerPrefs.GetInt("23score") || !PlayerPrefs.HasKey("23score")))
		{
			PlayerPrefs.SetInt ("23score", Score);
		}
		if (SceneManager.GetActiveScene().name=="22round" && (Score > PlayerPrefs.GetInt("22score") || !PlayerPrefs.HasKey("22score")))
		{
			PlayerPrefs.SetInt ("22score", Score);
		}
		if (SceneManager.GetActiveScene().name=="21round" && (Score > PlayerPrefs.GetInt("21score") || !PlayerPrefs.HasKey("21score")))
		{
			PlayerPrefs.SetInt ("21score", Score);
		}
		if (SceneManager.GetActiveScene().name=="33round" && (Score > PlayerPrefs.GetInt("33score") || !PlayerPrefs.HasKey("23score")))
		{
			PlayerPrefs.SetInt ("33score", Score);
		}
		if (SceneManager.GetActiveScene().name=="32round" && (Score > PlayerPrefs.GetInt("32score") || !PlayerPrefs.HasKey("22score")))
		{
			PlayerPrefs.SetInt ("32score", Score);
		}
		if (SceneManager.GetActiveScene().name=="31round" && (Score > PlayerPrefs.GetInt("31score") || !PlayerPrefs.HasKey("21score")))
		{
			PlayerPrefs.SetInt ("31score", Score);
		}
		ResultScore.text = "Ваш результат: " + Score.ToString() + " из " + numberOfNumbers;
	}
}
