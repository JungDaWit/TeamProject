using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] public float monsterAttack;
    [SerializeField] public float monsterHP;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TestBullet bullet = collision.gameObject.GetComponent<TestBullet>();             // Bullet�� PlayerController�� ���
            if (bullet != null)                                                              // null�� ��ȯ��. ���ݷ��� Bullet�� �������ҰŰ���
            {
                TakeDamage(bullet.bulletDamage);
                if (monsterHP <= 0)
                {
                    Destroy(gameObject);
                }

                Debug.Log("���� ü�� : " + monsterHP);
            }
        }
    }

    private void TakeDamage(float damage)
    {
        monsterHP -= damage;
    }
}
