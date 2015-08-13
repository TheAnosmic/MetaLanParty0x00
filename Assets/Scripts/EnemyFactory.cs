using UnityEngine;
using System.Collections;

public class EnemyFactory {
    public GameObject Target { get; set; }
    public GameObject[] PossibleEnemies { get; set; }
    private GameObject m_producer;


    public EnemyFactory(GameObject producer)
    {
        m_producer = producer;
    }

    public void Create(int count, Vector2 topLeft, Vector2 bottomRight)
    {
        var enemiesCount = PossibleEnemies.Length;
        if (enemiesCount > 0)
        {
            for (int i = 0; i < count; i++)
            {
                var randomEnemy = Random.Range(0, enemiesCount);
                var enemy = PossibleEnemies[randomEnemy];

                Vector3 position = new Vector3();
                position.x = Random.Range(topLeft.x, bottomRight.x);
                position.y = Random.Range(topLeft.y, bottomRight.y);
                enemy.GetComponent<Enemy>().target = Target.transform;
                var genaratedEnemy = Object.Instantiate(enemy, position, m_producer.transform.rotation) as Enemy;
            }
        }    
    }
}
