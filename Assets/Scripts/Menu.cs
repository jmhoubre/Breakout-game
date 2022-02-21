using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
	private const float ratio = 1f / 300f;

	[SerializeField] private TMP_Text playerNameText;
	[SerializeField] private TMP_Text warningText;

	[SerializeField] private GameObject player;

	[SerializeField] private List<GameObject> objectsToKeep;
	
	private void Awake ()
	{
		foreach (GameObject go in objectsToKeep)
		{
			DontDestroyOnLoad (go);
		}
	}

	private void Start ()
	{
		//InvokeRepeating (nameof (CreateRandomBrick), 0.5f, 1f);
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

	private void CreateRandomBrick ()
	{
		Color[] colors = new[] { Color.red, Color.blue, Color.yellow, Color.green, Color.magenta, Color.cyan, Color.gray };		

		Vector2 randomPosition = ratio * new Vector2 (
			Random.Range (50, Screen.width - 50),
			Random.Range (50, Screen.height - 50));

		Color randomColor = colors[Random.Range (0, colors.Length)];

		
		//brick.gameObject.layer = 5; // UI.		
		//StartCoroutine (DisplayBrick (brick, randomColor));
	}

	private IEnumerator DisplayBrick (GameObject _brick, Color _color)
	{
		Material material = _brick.GetComponent<Renderer> ().material;
		material.color = _color;
		float alfa = 1f;

		while (alfa > 0f)
		{
			SetAlfa (material, alfa - Time.deltaTime);
			yield return null;
		}

		SetAlfa (material, 0f);
		yield return null;

		while (alfa < 1f)
		{
			SetAlfa (material, alfa + Time.deltaTime);
			yield return null;
		}

		SetAlfa (material, 1f);
		yield return null;

		Destroy (_brick);
	}

	private void SetAlfa (Material _material, float _alfa)
	{
		Color c = _material.color;
		c.a = _alfa;
		_material.color = c;
	}
}