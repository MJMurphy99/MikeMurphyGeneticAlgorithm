using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

//GA that controls the speed of the rockets over generations
//Comments from GeneticPlatformController.cs carry over to here, they are very similar at their core
public class GeneticRocketSpeedController : MonoBehaviour
{
    public int populationSize = 5;
    public GameObject rocketPrefab;
    public List<GameObject> population;
    public int mutationrate;

    private float timeOnLevelTimer;

    //used to keep a sorted list of the different speed values of the rockets in a numeric order
    private List<GameObject> sortedList;

    public float chartFloat = 0;
    public int checker = 0;
    public int skillLevelInt = 0;
    public int currentGenerationInt = 0;

    public Vector3 [] rocketSpawnPoint = new Vector3[5];

    // Start is called before the first frame update
    void Start()
    {
        InitialiseRocketSpeed();
        //InvokeRepeating("BreedRockets", 1, 1);
    }

    private void InitialiseRocketSpeed()
    {
        for (int i = 0; i < populationSize; i++)
        {
            GameObject rocket = Instantiate(rocketPrefab, rocketSpawnPoint[i], Quaternion.identity);
            RocketSpeedDNA rocketSpeed = rocket.GetComponent<RocketSpeedDNA>();

            rocketSpeed.rocketSpeedDNA = Random.Range(2f, 3f);

            population.Add(rocket);

            Debug.Log(rocketSpeed.rocketSpeedDNA.ToString());

        }
        Debug.Log(currentGenerationInt);
    }

    
    public void BreedRockets()
    {

        timeOnLevelTimer = 0;

        List<GameObject> newPopulation = new List<GameObject>();

        if (timeOnLevelTimer > 15 && DeathFloorScript.deathByCollider == false)
        {
            sortedList = population.OrderByDescending(o => o.GetComponent<RocketSpeedDNA>().rocketSpeedDNA).ToList();
            skillLevelInt = 1;
        }
        else if (timeOnLevelTimer <= 15 || DeathFloorScript.deathByCollider == true)
        {
            sortedList = population.OrderBy(o => o.GetComponent<RocketSpeedDNA>().rocketSpeedDNA).ToList();
            skillLevelInt = 2;
        }
        population.Clear();

        for (int i = 0; i < sortedList.Count; i++)
        {
            population.Add(Breed(sortedList[i], sortedList[i], rocketSpawnPoint[i]));
        }

        for (int i = 0; i < sortedList.Count; i++)
        {
            Destroy(sortedList[i]);
        }

        currentGenerationInt++;

        Debug.Log(currentGenerationInt);
        checker = 0;
        chartFloat = 0;

    }

    private GameObject Breed(GameObject parent1, GameObject parent2, Vector3 rocketSpawnPos)
    {
        DeathFloorScript.deathByCollider = false;
        GameObject offspring = Instantiate(rocketPrefab, rocketSpawnPos, Quaternion.identity);
        RocketSpeedDNA offspringDNA = offspring.GetComponent<RocketSpeedDNA>();

        RocketSpeedDNA dna1 = parent1.GetComponent<RocketSpeedDNA>();
        RocketSpeedDNA dna2 = parent2.GetComponent<RocketSpeedDNA>();

        if (mutationrate <= Random.Range(0, 100))
        {
            offspringDNA.rocketSpeedDNA = Random.Range(0, 10) < 5 ? dna1.rocketSpeedDNA : dna2.rocketSpeedDNA;
        }
        else
        {
            if (skillLevelInt == 1)
            {
                offspringDNA.rocketSpeedDNA = Random.Range(3, 4f);
            }
            else
            {
                offspringDNA.rocketSpeedDNA = Random.Range(1.5f, 2f);
            }

        }

        chartFloat = chartFloat + offspringDNA.rocketSpeedDNA;
        checker++;
        if(checker >=5)
        Debug.Log(chartFloat / 5);

        return offspring;

    }

}

