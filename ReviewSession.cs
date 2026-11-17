using System;

public class ReviewSession
{
    public int Id { get; private set; }
    public int MinReleaseYear { get; private set; }
    public double ProposedRating { get; private set; }
    public Game? TargetGame { get; private set; }
    public bool IsCompleted { get; private set; }

    public ReviewSession(int id, int minReleaseYear, double proposedRating)
    {
        Id = id;
        MinReleaseYear = minReleaseYear < 1950 ? 1950 : minReleaseYear;

        if (proposedRating < 0.0) ProposedRating = 0.0;
        else if (proposedRating > 10.0) ProposedRating = 10.0;
        else ProposedRating = proposedRating;

        TargetGame = null;
        IsCompleted = false;
    }

    public bool TryStart(Game game)
    {
        if (IsCompleted)
        {
            return false;
        }
        if (TargetGame != null)
        {
            return false;
        }
        if (game.ReleaseYear < MinReleaseYear)
        {
            return false;
        }

        TargetGame = game;
        return true;
    }

    public bool TryFinish()
    {
        if (IsCompleted)
        {
            return false;
        }

        Game? game = TargetGame;
        if (game == null)
        {
            return false;
        }
        if (game.ReleaseYear < MinReleaseYear)
        {
            return false;
        }

        game.UpdateRating(ProposedRating);
        IsCompleted = true;
        return true;
    }

    public string GetInfo()
    {
        string gameText = TargetGame != null ? TargetGame.Title : "игра не выбрана";
        string doneText = IsCompleted ? "да" : "нет";
        return $"Сессия №{Id} оценка {ProposedRating} игра {gameText} завершено: {doneText}";
    }
}
