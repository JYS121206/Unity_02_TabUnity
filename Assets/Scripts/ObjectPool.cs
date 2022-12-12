using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    //[Unity Basic Skills] 06. 메모리 풀 (MemoryPool)
    //https://youtu.be/WVnuA6Jay8Q

    private class PoolItem
    {
        public bool isActive;
        public ParticleSystem hitParticle;
    }

    //int inceaseCount = 1;
    int maxCount;
    int acctiveCount;

    ParticleSystem poolObject;
    List<PoolItem> poolItemList;

    public ObjectPool()
    {
        maxCount = 0;
        acctiveCount = 0;

        poolItemList = new List<PoolItem>();
    }

    //오브젝트를 하나 생성 후 maxCount에 그 수를 추가합니다.
    //오브젝트는 생성 후 SetActive(false) 상태가 되며
    //bool isActive 또한 false가 됩니다.
    //이유는 잘 모르겠음
    //생성한 오브젝트를 리스트에 추가합니다.
    public void InstantiateObject()
    {
        maxCount++;

        PoolItem poolItem = new PoolItem();

        poolItem.isActive = false;

        float randX = Random.Range(-0.7f, 0.7f);
        float randY = Random.Range(-0.7f, 0.7f);

        poolItem.hitParticle = ObjectManager.GetInstance().CreateHitEffect();
        poolItem.hitParticle.transform.localScale = new Vector3(0.2f, 0.2f, 0.3f);
        poolItem.hitParticle.transform.localPosition = new Vector3(0 + randX, 0.7f + randY, -0.5f);

        poolItem.hitParticle.gameObject.SetActive(false);

        poolItemList.Add(poolItem);
    }

    //현재 관리 중인 모든 오브젝트를 삭제 (활성/비활성 무관)
    //씬을 넘어갈 때 사용할 예정입니다.
    public void DestroyObjects()
    {
        if (poolItemList == null) return;

        int count = poolItemList.Count;
        for (int i = 0; i < count; i++)
        {
            GameObject.Destroy(poolItemList[i].hitParticle);
        }
        poolItemList.Clear();
    }

    //현재 비활성화 상태인 오브젝트 하나를 활성화 상태로 만들어
    //사용하는 함수입니다.
    public GameObject ActivatePoolItem()
    {
        if (poolItemList == null) return null;

        //만약 현재 가진 오브젝트가 모두 사용 중이라면
        //새로운 오브젝트를 하나 생성합니다.
        if (maxCount == acctiveCount)
        {
            InstantiateObject();
        }

        int count = poolItemList.Count;
        for (int i = 0; i < count; i++)
        {
            PoolItem poolItem = poolItemList[i];
            if (poolItem.isActive == false)
            {
                acctiveCount++;
                poolItem.isActive = true;
                poolItem.hitParticle.gameObject.SetActive (true);

                return poolItem.hitParticle.gameObject;
            }
        }
        return null;
    }

    //사용이 완료된 오브젝트를 비활성화 상태로 설정
    //근데 안 해도 알아서 비활성화 되는 중;;
    public void DeactivatePoolItem(GameObject removeObject)
    {
        if(poolItemList==null||removeObject==null) return;

        int count =poolItemList.Count;
        for (int i = 0; i < count; i++)
        {
            PoolItem poolItem = poolItemList[i];
            if (poolItem.hitParticle == removeObject)
            {
                acctiveCount--;
                poolItem.isActive=false;
                poolItem.hitParticle.gameObject.SetActive (false);
                return;
            }
        }
    }
}
