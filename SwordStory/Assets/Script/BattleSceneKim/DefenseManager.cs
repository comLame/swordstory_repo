﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseManager : MonoBehaviour {

	//オブジェクト参照
	public GameObject canvas; //キャンバス
	public GameObject imageShield; //シールド
	/*
	public GameObject createEnemyAttack; //createEnemyAttack
	public GameObject myAttack; //MyAttack
	*/

	//メンバ変数
	private float timeOut = 0.2f; //敵の攻撃の時間間隔
	private float timeElapsed = 0f; //時間を蓄積させる
	
	// Update is called once per frame
	void Update () {
		/*
		 * クリックしたらシールドを表示
		 * ドラッグ中はマウスに追従してシールドが移動
		 * クリックを離したらシールド非表示
		 */
		if (Input.GetMouseButtonDown (0)) {
			
			//タイマー開始
			timeElapsed += Time.deltaTime;
		}

		if (Input.GetMouseButton (0)) {
			RectTransform CanvasRect = canvas.GetComponent<RectTransform>();
			//マウスのポジション
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 screenPos = Camera.main.WorldToViewportPoint (worldPos);
			Vector2 WorldObject_ScreenPosition = new Vector2(
				((screenPos.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
				((screenPos.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)));

			//タイマー開始
			timeElapsed += Time.deltaTime;

			if (timeElapsed >= timeOut) {
				//シールド表示
				imageShield.SetActive(true);
				imageShield.transform.localPosition = WorldObject_ScreenPosition;
			}

		}

		if (Input.GetMouseButtonUp (0)) {
			//シールド非表示
			imageShield.SetActive (false);
			timeElapsed = 0;
		}
	}

}
