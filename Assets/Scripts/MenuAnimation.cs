using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
	[SerializeField] private List<UIBrick> bricks;

	private void Start ()
	{
		foreach (UIBrick brick in bricks)
		{
			brick.gameObject.SetActive (true);			
		}
	}
}