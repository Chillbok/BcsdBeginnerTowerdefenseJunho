using System.Collections;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP; //최대 체력
    private float currentHP; //현재 체력
    private bool isDie = false; //적이 사망 상태이면 isDie를 true로 설정
    private Enemy enemy;
    private SpriteRenderer spriteRenderer;

    //적의 현재 체력, 최대 체력 정보를 외부 클래스에서 확인할 수 있도록 프로퍼티 설정
    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;

    private void Awake()
    {
        currentHP = maxHP;
        enemy = GetComponent<Enemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        //Tip. 적의 체력이 damage만큼 감소해서 죽을 상황일 때 여러 타워의 공격을 동시에 받으면
        //enemy.onDie() 함수가 여러 번 실행될 수 있다.

        //현재 적의 상태가 사망 상태이면 아래 코드를 실행하지 않는다.
        if (isDie == true) return;

        //현재 체력을 damage만큼 감소
        currentHP -= damage;

        //적의 투명도를 낮추는 다음 요소가 이미 실행 중인 상황을 고려해 stop과 start를 동시에 사용
        StopCoroutine("HitAlphaAnimation");
        StartCoroutine("HitAlphaAnimation");

        //체력이 0 이하 = 적 캐릭터 사망
        if (currentHP <= 0)
        {
            isDie = true;
            //적 캐릭터 사망
            enemy.OnDie(EnemyDestroyType.Kill);
        }
    }

    private IEnumerator HitAlphaAnimation()
    {
        //현재 적의 색상을 color 변수에 저장
        Color color = spriteRenderer.color;

        //적의 투명도를 40%로 설정
        color.a = 0.4f;
        spriteRenderer.color = color;

        //0.05초 동안 대기
        yield return new WaitForSeconds(0.05f);

        //적의 투명도를 100%로 설정
        color.a = 1.0f;
        spriteRenderer.color = color;
    }
}