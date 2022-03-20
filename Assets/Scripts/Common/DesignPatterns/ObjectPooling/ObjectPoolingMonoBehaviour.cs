using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingMonoBehaviour : MonoBehaviour {
    
    [SerializeField] private int minimumForPool;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform containerPool;
    private readonly List<GameObject> pool = new List<GameObject>();

    void Awake() {
        UpdatePool();
    }
    public void UpdateMinimumForPool(int amount) {
        minimumForPool = amount;
        UpdatePool();
    }

    /// <summary>
    /// Clear existing items already in the pool and re-create new pool
    /// </summary>
    private void UpdatePool() {
        pool.ForEach(item => {
            Destroy(item.gameObject);
        });
        
        pool.Clear();
        
        for (var i = 0; i < minimumForPool; i++) {
            AddElementOnThePool();
        }
    }

    private void AddElementOnThePool() {
        var newItem = containerPool != null ? Instantiate(prefab, containerPool.transform) : Instantiate(prefab);
        newItem.gameObject.SetActive(false);
        pool.Add(newItem);
    }
    
    public GameObject GetObjectInThePool() {
        // needs more elements on the pool
        if (pool.Count == 0) {
            AddElementOnThePool();
            minimumForPool++;
        }
        
        var item = pool[0];
        pool.Remove(item);
        item.gameObject.SetActive(true);
        return item;
    }
    
    public void ReturnObjectInThePool(GameObject item) {
        pool.Add(item);
        item.gameObject.SetActive(false);
    }
}
