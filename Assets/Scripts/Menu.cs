using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
	[SerializeField] private TMP_Text playerNameText;
	[SerializeField] private TMP_Text warningText;

	[SerializeField] private GameObject player;

	private void Awake ()
	{
		DontDestroyOnLoad (player);
	}

	public void LoadMainScene ()
	{
		if (playerNameText.text.Length > 3)
		{
			player.GetComponent<Player> ().SetPlayerName (playerNameText.text);
			SceneManager.LoadScene ("main");
		}
		else
		{
			StartCoroutine (DisplayWarning ());
		}
	}

	private IEnumerator DisplayWarning ()
	{
		warningText.gameObject.SetActive (true);

		yield return new WaitForSeconds (1f);
		warningText.gameObject.SetActive (false);
	}
}