using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
	//トリガーモードで他のオブジェクトと接触した場合の処理
	void OnTriggerEnter(Collider other)
	{
		//障害物に衝突した場合
		if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag" || other.gameObject.tag == "CoinTag")
		{
			Destroy(other.gameObject);
		}
	}
}
