using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour
{
	//carPrefabを入れる
	public GameObject carPrefab;

	//coinPrefabを入れる
	public GameObject coinPrefab;

	//cornPrefabを入れる
	public GameObject cornePrefab;

	//スタート地点
	private int startPos = 80;

	//ゴール地点
	private int goalPos = 360;

	//
	private float itemInstancePosZ;

	//アイテムを出すx方向の範囲
	private float posRange = 3.4f;

	private Transform unitychan;

	// Use this for initialization
	void Start()
	{
		unitychan = GameObject.Find("unitychan").transform;

		itemInstancePosZ = startPos;
		/*
		//一定の距離ごとにアイテムを生成
		for (int i = startPos; i < goalPos; i += 15)
		{
			//どのアイテムを出すのかをランダムに設定
			int num = Random.Range(1, 11);

			if (num <= 2)
			{
				//コーンをx軸方向に一直線に生成
				for (float j = -1; j <= 1; j += 0.4f)
				{
					GameObject corne = Instantiate(cornePrefab);
					corne.transform.position = new Vector3(4 * j, corne.transform.position.y, i);
				}
			}
			else
			{
				//レーンごとにアイテムを生成
				for (int j = -1; j <= 1; j++)
				{
					//アイテムの種類を決める
					int item = Random.Range(1, 11);

					//アイテムを置くZ座標のオフセットをランダムに設定
					int offsetZ = Random.Range(-5, 6);

					//60%コイン配置:30%車配置:10%何もなし
					if (1 <= item && item <= 6)
					{
						//コインを生成

						GameObject coin = Instantiate(coinPrefab);
						coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
					}
					else if (7 <= item && item <= 9)
					{
						//車を生成
						GameObject car = Instantiate(carPrefab);
						car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
					}
				}
			}
		}
		*/
	}

	public void Update()
	{
		//プレイヤーのZ座標の45先がアイテム生成場所を超えたら
		if (unitychan.position.z + 45 > this.itemInstancePosZ && unitychan.position.z + 45 < goalPos)
		{
			//アイテムを生成
			ItemInstance();

			//アイテム生成場所を更新
			this.itemInstancePosZ += 15;
		}
	}

	public void ItemInstance()
	{
		//どのアイテムを出すのかをランダムに設定
		int num = Random.Range(1, 11);

		if (num <= 2)
		{
			//コーンをx軸方向に一直線に生成
			for (float i = -1; i <= 1; i += 0.4f)
			{
				GameObject corne = Instantiate(cornePrefab);
				corne.transform.position = new Vector3(4 * i, corne.transform.position.y, itemInstancePosZ);
			}
		}
		else
		{
			//レーンごとにアイテムを生成
			for (int i = -1; i <= 1; i++)
			{
				//アイテムの種類を決める
				int item = Random.Range(1, 11);

				//アイテムを置くZ座標のオフセットをランダムに設定
				int offsetZ = Random.Range(-5, 6);

				//60%コイン配置:30%車配置:10%何もなし
				if (1 <= item && item <= 6)
				{
					//コインを生成
					GameObject coin = Instantiate(coinPrefab);
					coin.transform.position = new Vector3(posRange * i, coin.transform.position.y, itemInstancePosZ + offsetZ);
				}
				else if (7 <= item && item <= 9)
				{
					//車を生成
					GameObject car = Instantiate(carPrefab);
					car.transform.position = new Vector3(posRange * i, car.transform.position.y, itemInstancePosZ + offsetZ);
				}
			}
		}
	}
}