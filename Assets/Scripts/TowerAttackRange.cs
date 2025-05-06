using UnityEngine;

public class TowerAttackRange : MonoBehaviour
{
    public void OnAttackRange(Vector3 position, float range)
    {
        gameObject.SetActive(true); //공격범위 활성화

        //공격 범위 크기
        float diameter = range * 2.0f; //공격범위(AttackRange)는 반지름이므로, 지름(Diameter)은 공격범위의 2배
        transform.localScale = Vector3.one * diameter;
        //공격 범위 위치
        transform.position = position;
    }
    public void OffAttackRange()
    {
        gameObject.SetActive(false); //공격범위 비활성화
    }
}
