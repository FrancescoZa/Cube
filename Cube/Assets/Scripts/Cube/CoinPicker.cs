using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinPicker : MonoBehaviour
{
	private float coin = 0;
	public TextMeshProUGUI textCoins;
	private void OnTriggerEnter2D(Collider2D other)
	{

		if (other.transform.tag == "Coin")
		{
			coin++;
			textCoins.text = coin.ToString();
			GetComponent<PlayerController>().playCoinSound();
			Destroy(other.gameObject);
		}else if (other.transform.tag == "20Coin")
		{
			coin = coin+20;
			textCoins.text = coin.ToString();
			GetComponent<PlayerController>().playCoinSound();
			Destroy(other.gameObject);
		}
	}


}
