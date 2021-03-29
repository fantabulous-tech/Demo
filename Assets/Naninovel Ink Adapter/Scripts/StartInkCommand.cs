using JetBrains.Annotations;
using UniRx.Async;

namespace Naninovel.Commands {
    [CommandAlias("startInkStory"), UsedImplicitly]
    public class StartInkCommand : Command {
        public override UniTask ExecuteAsync(CancellationToken cancellationToken = default) {
            NaninovelInkAdapter.StartStory();
            return UniTask.CompletedTask;
        }
    }
}