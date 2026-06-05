using UnityEngine;
using System.Collections.Generic;

public class TargetSpawner : MonoBehaviour
{
    
    [System.Serializable]
    public struct SpawnPointConfig
    {
        [Header("Configurações do Ponto")]
        public Transform spawnPosition; 
        public GameObject targetPrefab; 
        public int quantity;            
        public float scale;             

        [Header("Configurações do Alvo")]
        public bool moveHorizontal;
        public bool moveVertical;
        public int health;
        public int pointsValue;
    }

   
    public List<SpawnPointConfig> spawnPoints;

    void Start()
    {
        SpawnAllTargets();
    }

    void SpawnAllTargets()
    {
        foreach (SpawnPointConfig config in spawnPoints)
        {
            if (config.spawnPosition == null || config.targetPrefab == null)
            {
                Debug.LogWarning("Spawn Position ou Target Prefab não definido em um dos pontos!");
                continue;
            }

            
            for (int i = 0; i < config.quantity; i++)
            {
               
                GameObject newTarget = Instantiate(config.targetPrefab, config.spawnPosition.position, Quaternion.identity);
                
                
                Target targetScript = newTarget.GetComponent<Target>();
                if (targetScript != null)
                {
                    targetScript.SetupTarget(config.health, config.pointsValue, config.scale, config.moveHorizontal, config.moveVertical);
                }
            }
        }
    }
}
