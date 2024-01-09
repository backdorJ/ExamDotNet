using System.Text;
using System.Text.Json;
using DND.Domain.BattleResultsDTO;
using DND.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DND.UI.Controllers;

public class BattleController : Controller
{
    private readonly HttpClient _client;

    public BattleController(HttpClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Открыть представление
    /// </summary>
    /// <returns>Представление</returns>
    [HttpGet]
    public IActionResult Battle()
        => View();
    
    /// <summary>
    /// Сюда приходит ответ с формы
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> BattleAsync(
        string name,
        int health,
        int attackModifier,
        int attackPerRound,
        int damageDiceThrowNumber,
        int damageWithDice,
        int damageModifier,
        int armorClass)
    {
        var player = new Entity
        {
            Name = name,
            Health = health,
            ArmorClass = armorClass,
            AttackPerRound = attackPerRound,
            AttackModifier = attackModifier,
            DamageModifier = damageModifier,
            DamageWithDice = damageWithDice,
            DamageDiceThrowsNumber = damageDiceThrowNumber
        };
        var playerToJson = JsonSerializer.Serialize(player);
        
        // var requestMessage = new HttpRequestMessage();
        // requestMessage.Method = HttpMethod.Post;
        // requestMessage.RequestUri = new Uri($"https://localhost:7254/api/BattleLogic??appellantJson={playerToJson}");
        //
        // using var response = await _client.SendAsync(requestMessage);
        // var battleResult =  JsonSerializer.Deserialize<BattleResult>(await response.Content.ReadAsStringAsync())!;
        // battleResult.IsFinish = true;
        
        // Create a StringContent with the JSON data    
        var content = new StringContent(playerToJson, Encoding.UTF8, "application/json");

        // Send the HTTP POST request with the JSON data in the request body
        using var response = await _client.PostAsync("https://localhost:7254/api/BattleLogic", content);

        // Deserialize the response content to BattleResult
        var battleResult = JsonSerializer.Deserialize<BattleResult>(await response.Content.ReadAsStringAsync())!;
        battleResult.IsFinish = true;
        
        return View(battleResult);
    }
}