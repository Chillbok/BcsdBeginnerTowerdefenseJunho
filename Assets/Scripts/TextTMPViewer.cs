using UnityEngine;
using TMPro;

public class TextTMPViewer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textPlayerHP; //Text - TextMeshPro UI [플레이어의 체력]
    [SerializeField]
    private TextMeshProUGUI textPlayerGold; //Text - TextMeshPro UI [플레이어의 골드]
    [SerializeField]
    private TextMeshProUGUI textWave; //Text - TextMeshPro UI [현재 웨이브 / 총 웨이브]
    [SerializeField]
    private TextMeshProUGUI textEnemyCount; //Text - TextMeshPro UI [현재 적 숫자 / 최대 적 숫자]
    [SerializeField]
    private PlayerHP playerHP; //플레이어의 체력 정보
    [SerializeField]
    private PlayerGold playerGold; //플레이어의 골드 정보
    [SerializeField]
    private WaveSystem waveSystem; //웨이브 정보
    [SerializeField]
    private EnemySpawner enemySpawner; //적 정보

    private void Update()
    {
        textPlayerHP.text = playerHP.CurrentHP + "/" + playerHP.MaxHP;
        textPlayerGold.text = playerGold.CurrentGold.ToString(); //playerGold.CurrentGold는 정수이고, textPlayerGold.text에는 문자열을 저장할 수 있기 때문에, .ToString()으로 정수를 문자열로 변환한다.
        textWave.text = waveSystem.CurrentWave + "/" + waveSystem.MaxWave;
        textEnemyCount.text = enemySpawner.CurrentEnemyCount + "/" + enemySpawner.MaxEnemyCount;
    }
}
