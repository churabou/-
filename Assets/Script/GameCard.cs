using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameCard : MonoBehaviour {



	private string id;
	public GameObject card;
	private Button button {
		get{
			return card.GetComponent<Button>();
		 }
	}
		
	// Use this for initialization
	void Start () {

	}




	//cardオブジェクトを180度回転させると、逆さまになるのでクリックしてもイベントがトリガーされないのでクリックは一回しかできない用になっていた。
	public void onClickCard(){
		StatusManager.count += 1;
		StatusManager.selectedCards.Add (this);
		button.GetComponentInChildren<Image>().color = Color.green;
		iTween.RotateTo (card, iTween.Hash ("y", 180, "oncomplete", "OnRotateComplete",
			"isLocal", true));

	}


	//連続でタップされた時とか面倒くさい。とりあえず1秒待っている。
	private void OnRotateComplete(){


		if (StatusManager.count == 2) {
			for (var i=0; i<2; i++){

			GameCard gc = StatusManager.selectedCards [i];
             
			gc.button.GetComponentInChildren<Image>().color = Color.red;
			iTween.RotateTo (gc.card, iTween.Hash ("y", 0, "oncomplete", "OnRotateComplete",
				"isLocal", true));
			}
			StatusReset ();
		}

	}


	private void StatusReset(){
		StatusManager.count = 0;
		StatusManager.selectedCards = new List<GameCard>();
	}


}
