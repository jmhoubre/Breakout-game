using UnityEngine;

public class Player : MonoBehaviour
{
	public string PlayerName { get; private set; }
	public int BestScore { get; private set; }

	public void SetPlayerName (string name) => PlayerName = name;
}