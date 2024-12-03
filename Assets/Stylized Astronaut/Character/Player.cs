using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject astronautPrefab; // Префаб астронавта.
    public Transform spawnPoint; // Точка, где появится астронавт.
    public float moveSpeed = 2f; // Скорость движения вперед.

    // Публичные переменные для настройки времени
    public float firstSpawnDelay = 2f; // Задержка перед первым появлением астронавта.
    public float spawnInterval = 5f; // Интервал между всеми последующими созданиями.

    private GameObject instantiatedAstronaut; // Ссылка на текущий созданный объект.

    void Start()
    {
        // Запуск корутины, которая сначала ждет задержку перед первым спавном, а затем выполняет регулярный спавн.
        StartCoroutine(SpawnAstronautCoroutine());
    }

    void Update()
    {
        if (instantiatedAstronaut != null)
        {
            // Двигаем созданный объект вперед по его локальной оси Z.
            instantiatedAstronaut.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    private System.Collections.IEnumerator SpawnAstronautCoroutine()
    {
        // Сначала ждем время до первого появления астронавта.
        yield return new WaitForSeconds(firstSpawnDelay);

        // Создаем первый астронавт.
        if (astronautPrefab != null && spawnPoint != null)
        {
            instantiatedAstronaut = Instantiate(astronautPrefab, spawnPoint.position, spawnPoint.rotation);
        }

        // Теперь запускаем спавн астронавтов с одинаковым интервалом.
        while (true)
        {
            // Ждем заданный интервал перед созданием нового астронавта.
            yield return new WaitForSeconds(spawnInterval);

            // Создаем новый астронавт.
            if (astronautPrefab != null && spawnPoint != null)
            {
                instantiatedAstronaut = Instantiate(astronautPrefab, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}
