using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject towerPrefab;

    public void SpawnTower(Transform tileTransform) //매개변수(tileTransform)의 위치에 타워 생성
    {
        Tile tile = tileTransform.GetComponent<Tile>(); //현재 타워를 건설하려고 하는 타일의 스크립트(Tile.cs) 할당

        //타워 건설 가능 여부 확인
        //1. 현재 타일의 위치에 이미 타워가 건설되어 있으면 타워 건설을 하지 않는다.
        if (tile.IsBuildTower == true) //만약 타워가 이미 건설되어 있다면
        {
            return; //아무것도 하지 않고 건너뛰기
        }

        //타워가 건설되어 있음으로 설정
        tile.IsBuildTower = true;

        //선택한 타일의 위치에 타워 건설
        Instantiate(/*GameObject*/towerPrefab, /*Component*/tileTransform.position, /*ScriptableObject*/Quaternion.identity);
    }
}

/*
File: TowerSpawner.cs
Desc
: 타워 생성 제어

Functions
: SpawnTower() - 매개변수의 위치에 타워 생성
*/