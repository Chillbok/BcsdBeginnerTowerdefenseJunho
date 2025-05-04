using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject towerPrefab;
    [SerializeField]
    private int towerBuildGold = 50; //타워 건설에 사용되는 골드
    [SerializeField]
    private EnemySpawner enemySpawner; //현재 맵에 존재하는 적 리스트 정보를 얻기 위해...
    [SerializeField]
    private PlayerGold playerGold; //타워 건설 시 골드 감소를 위해...

    public void SpawnTower(Transform tileTransform) //매개변수(tileTransform)의 위치에 타워 생성
    {
        //타워 건설 가능 여부 확인
        //1. 타워를 건설할 만큼 돈이 없으면 타워 건설 X
        if (towerBuildGold > playerGold.CurrentGold)
        {
            return;
        }

        Tile tile = tileTransform.GetComponent<Tile>(); //현재 타워를 건설하려고 하는 타일의 스크립트(Tile.cs) 할당

        //타워 건설 가능 여부 확인
        //1. 현재 타일의 위치에 이미 타워가 건설되어 있으면 타워 건설을 하지 않는다.
        if (tile.IsBuildTower == true) //만약 타워가 이미 건설되어 있다면
        {
            return; //아무것도 하지 않고 건너뛰기
        }

        //타워가 건설되어 있음으로 설정
        tile.IsBuildTower = true;
        //타워 건설에 필요한 골드만큼 감소
        playerGold.CurrentGold -= towerBuildGold;
        //선택한 타일의 위치에 타워 건설 (타일보다 z축 -1의 위치에 배치)
        Vector3 position = tileTransform.position + Vector3.back;
        GameObject clone = Instantiate(towerPrefab, position, Quaternion.identity);
        //타워 무기에 enemySpawner 정보 전달
        clone.GetComponent<TowerWeapon>().Setup(enemySpawner);
    }
}

/*
File: TowerSpawner.cs
Desc
: 타워 생성 제어

Functions
: SpawnTower() - 매개변수의 위치에 타워 생성
*/