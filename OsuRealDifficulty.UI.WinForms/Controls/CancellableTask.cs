namespace OsuRealDifficulty.UI.WinForms.Controls;

public record CancellableTask(Task Task, CancellationTokenSource CancellationTokenSource);
