using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour {
	private int _health;
	public Text textHealth;
	public GameObject dieMenu;
	public string date;
	void Start() {
		_health = 3;
	}

	void Update()
	{
		textHealth.text = "血量："+_health.ToString();
	}

	public void Hurt(int damage) {
		_health -= damage;
		if (_health < 1)
		{        Time.timeScale = 0;
			date = DateTime.Now.Date.ToString();
			dieMenu.SetActive(true);
			
		}
		
	}
	
}
