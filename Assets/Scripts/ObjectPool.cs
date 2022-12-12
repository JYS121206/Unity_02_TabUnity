using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    //[Unity Basic Skills] 06. �޸� Ǯ (MemoryPool)
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

    //������Ʈ�� �ϳ� ���� �� maxCount�� �� ���� �߰��մϴ�.
    //������Ʈ�� ���� �� SetActive(false) ���°� �Ǹ�
    //bool isActive ���� false�� �˴ϴ�.
    //������ �� �𸣰���
    //������ ������Ʈ�� ����Ʈ�� �߰��մϴ�.
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

    //���� ���� ���� ��� ������Ʈ�� ���� (Ȱ��/��Ȱ�� ����)
    //���� �Ѿ �� ����� �����Դϴ�.
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

    //���� ��Ȱ��ȭ ������ ������Ʈ �ϳ��� Ȱ��ȭ ���·� �����
    //����ϴ� �Լ��Դϴ�.
    public GameObject ActivatePoolItem()
    {
        if (poolItemList == null) return null;

        //���� ���� ���� ������Ʈ�� ��� ��� ���̶��
        //���ο� ������Ʈ�� �ϳ� �����մϴ�.
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

    //����� �Ϸ�� ������Ʈ�� ��Ȱ��ȭ ���·� ����
    //�ٵ� �� �ص� �˾Ƽ� ��Ȱ��ȭ �Ǵ� ��;;
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
