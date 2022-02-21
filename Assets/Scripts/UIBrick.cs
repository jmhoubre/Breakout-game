using UnityEngine;

public class UIBrick : MonoBehaviour
{
	private const float MIN_X = -8f;
	private const float MAX_X = 8f;
	private const float MIN_Y = -4f;
	private const float MAX_Y = 2f;

	private void Start ()
	{
		RandomColor ();
		InvokeRepeating (nameof (ModifyBrick), Random.Range (0.2f, 1.8f), 2f);
	}

	private void ModifyBrick ()
	{
		RandomColor ();
		RandomPosition ();
	}

	private void RandomPosition ()
	{
		float x = Random.Range (MIN_X, MAX_X);
		float y = Random.Range (MIN_Y, MAX_Y);
		while (x > -2.8f && x < 2.8f && y < 0.45f && y > -2f)
		{
			x = Random.Range (MIN_X, MAX_X);
			y = Random.Range (MIN_Y, MAX_Y);
		}

		Vector3 randomPosition = new Vector3 (x, y, 0f);
		transform.position = randomPosition;
	}

	private void RandomColor ()
	{
		Color[] colors = new[] { Color.red, Color.blue, Color.yellow, Color.green, Color.magenta, Color.cyan };
		Color randomColor = colors[Random.Range (0, colors.Length)];
		GetComponent<Renderer> ().material.color = randomColor;
	}
}