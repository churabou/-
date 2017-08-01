using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameCard _gamecard;

	public static List<Color> colors = new List<Color>();

	// Use this for initialization
	void Start () {

		for (var i = 0; i < 36; i++) {
			switch (i%6)
			{
			case 0:
				colors.Add (Color.magenta);
				break;
			case 1:
				colors.Add (Color.green);
				break;
			case 2:
				colors.Add (Color.blue);
				break;
			case 3:
				colors.Add (Color.cyan);
				break;
			case 4:
				colors.Add (Color.gray);
				break;
			case 5:
				colors.Add (Color.yellow);
				break;
			default:
				break;
			}
		}


		for (var i = 0; i < 36; i++) {
			GameCard _ = Instantiate (_gamecard);
			_.transform.parent = GameObject.Find ("Grid").transform;
			_.transform.localScale = new Vector3 (1, 1, 1);
			_.setBackCard (i);
		}		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
