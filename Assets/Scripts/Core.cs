using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Core : MonoBehaviour
{
    [SerializeField] private List<Sprite> carList = new List<Sprite>();
    [SerializeField] private List<Transform> upSpawnPointList = new List<Transform>();
    [SerializeField] private List<Transform> downSpawnPointList = new List<Transform>();
    [SerializeField] private GameObject catObject , carPrefab , gamePanel , pausePanel , gameOverPanel , startPanel;
    private int completeRoadCount;

    public void Button(string status)
    {
        if (status == "up")
        {
            if (catObject.transform.position.y > 3)
            {
                catObject.transform.DOMoveY(3.3f,0.5f).SetEase(Ease.OutElastic);
            }
            else
            {
                catObject.transform.DOMoveY(catObject.transform.position.y+1f , 0.5f).SetEase(Ease.OutElastic);
            }
        }
        else if(status == "down")
        {
            if (catObject.transform.position.y < -0.9f)
            {
                catObject.transform.DOMoveY(-1.2f,0.5f).SetEase(Ease.OutElastic);
            }
            else
            {
                catObject.transform.DOMoveY(catObject.transform.position.y - 1f, 0.5f).SetEase(Ease.OutElastic);
            }
        }
        else if (status == "left")
        {
            if (catObject.transform.position.x < -2)
            {
                catObject.transform.DOMoveY(-2.2f, 0.5f).SetEase(Ease.OutElastic);
            }
            catObject.transform.DOMoveY(catObject.transform.position.x - 0.92f, 0.5f).SetEase(Ease.OutElastic);
        }
        else if (status == "right")
        {
            if (catObject.transform.position.x < -0.9f)
            {
                catObject.transform.DOMoveY(-1.2f,0.5f).SetEase(Ease.OutElastic);
            }
            else
            {
                catObject.transform.DOMoveY(catObject.transform.position.y + 0.92f, 0.5f).SetEase(Ease.OutElastic);
            }
        }
    }

    public void CompleteRoad()
    {
        completeRoadCount += 1;
        catObject.transform.position = new Vector3(-2.2f,0,0);
    }

    private int SpawnCar(int counter)
    {
            var tempDownCar = Instantiate(carPrefab,downSpawnPointList[Random.RandomRange(0,downSpawnPointList.Count)]);
            tempDownCar.transform.DOMoveY(11f,2f/completeRoadCount).OnComplete(()=>
            {
                Destroy(tempDownCar);
            });
        return SpawnCar(counter);
    }

    public void CarCrash()
    {
        gamePanel.SetActive(false);
        catObject.transform.DOLocalJump(catObject.transform.position,0.2f,1,0.5f).OnComplete(()=>
        {
            gameOverPanel.SetActive(true);
        });
    }
}
