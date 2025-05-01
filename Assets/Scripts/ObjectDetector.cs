// 마우스 클릭으로 오브젝트를 선택하도록 해주는 스크립트
using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    [SerializeField]
    private TowerSpawner towerSpawner;

    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;

    private void Awake()
    {
        //"MainCamera" 태그를 가지고 있는 오브젝트 탐색 후 Camera 컴포넌트 정보 전달
        //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); 와 동일
        mainCamera = Camera.main; //카메라 컴포넌트 변수에 할당
    }

    private void Update()
    {
        //마우스 왼쪽 버튼을 눌렀을 때
        if (Input.GetMouseButtonDown(0))
        {
            //카메라 위치에서 화면의 마우스 위치를 관통하는 광선 생성
            //레이저 포인터를 생각하자!
            //ray.origin : 광선의 시작 위치(=카메라 위치)
            //ray.direction : 광선의 진행 방향
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            //2D 모니터를 통해 3D 월드의 오브젝트를 마우스로 선택하는 방법
            //광선에 부딪히는 오브젝트를 검출해서 hit에 저장
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //광선에 부딪힌 오브젝트의 태그가 "Tile"이면
                if (hit.transform.CompareTag("Tile"))
                {
                    //타워를 생성하는 SpawnTower() 호출
                    towerSpawner.SpawnTower(hit.transform);
                }
            }
        }
    }
}
