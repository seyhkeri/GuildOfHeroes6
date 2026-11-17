// // Probe.Run();

// Hero yaroslav = new Hero("Ярослав", 100);
// Hero anastasia = new Hero("Анастасия", 90);
// Hero artem = new Hero("Артём", 120);
// Hero alexander = new Hero("   Александр   ", 150);
// Hero sergey = new Hero("Сергей", 110);

// alexander.TakeDamage(10);
// alexander.Heal(10);

// Guild guild = new Guild("Гильдия героев");
// guild.AddHero(yaroslav);
// guild.AddHero(anastasia);
// guild.AddHero(artem);
// guild.AddHero(alexander);
// guild.AddHero(sergey);

// Console.WriteLine($">>> {guild.Name}: участников {guild.MemberCount} <<<");
// Console.WriteLine();

// QuestBoard board = new QuestBoard(guild);

// Quest floatQuest = new Quest(101, "Вернуть поплавок", 100, 30);
// Console.WriteLine($"Поручение добавлено: {board.AddQuest(floatQuest)}");
// Console.WriteLine($">>> №{floatQuest.Id}: {floatQuest.Title} <<<");

// Console.WriteLine($"Назначение Сергея: {board.TryAssign(101, " сЕрГеЙ ")}");
// Hero? assigned = floatQuest.AssignedHero;
// if (assigned != null) {
//     Console.WriteLine($"Исполнитель: {assigned.Name}");
// }
// Console.WriteLine($"Опыт после назначения: {sergey.Experience}");

// Console.WriteLine($"Завершение: {board.TryComplete(101)}");
// Console.WriteLine($"Опыт после завершения: {sergey.Experience}");
// Console.WriteLine($"Повторное завершение: {board.TryComplete(101)}");
// Console.WriteLine($"Опыт после повтора: {sergey.Experience}");

// Console.WriteLine();
// Console.WriteLine(floatQuest.GetInfo());
// Console.WriteLine(sergey.GetInfo());

GameCatalog catalog = new GameCatalog("Каталог Игр");

Game persona = new Game("Persona 3 Reload", "JRPG", 2024, 10.0);
Game zelda = new Game("The Legend Of Zelda: Breath Of The Wild", "Adventure", 2017, 10.0);
Game cyberpunk = new Game("Cyberpunk 2077", "RPG", 2020, 8.5);

catalog.AddGame(persona);
catalog.AddGame(zelda);
catalog.AddGame(cyberpunk);

ReviewSession session = new ReviewSession(1, 2018, 9.5);

Console.WriteLine($"Старт обзора на Zelda: {session.TryStart(zelda)}");
Console.WriteLine($"Рейтинг Zelda после отказа: {zelda.Rating}");

Console.WriteLine($"Старт обзора на Cyberpunk 2077: {session.TryStart(cyberpunk)}");
Console.WriteLine($"Рейтинг Cyberpunk после старта: {cyberpunk.Rating}");

Console.WriteLine($"Повторный старт на Persona 3: {session.TryStart(persona)}");

Console.WriteLine($"Завершение сессии №{session.Id}: {session.TryFinish()}");

Console.WriteLine($"Повторное завершение сессии №{session.Id}: {session.TryFinish()}");

Console.WriteLine();
Console.WriteLine(session.GetInfo());
Game? updatedGame = catalog.FindGameByTitle("cyberpunk 2077");
if (updatedGame != null) {
    Console.WriteLine($"Проверка в каталоге {updatedGame.Title}, актуальный рейтинг {updatedGame.Rating}");
}