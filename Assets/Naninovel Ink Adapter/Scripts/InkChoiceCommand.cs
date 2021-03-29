using UniRx.Async;

namespace Naninovel.Commands {
    [CommandAlias("inkChoice")]
    public class InkChoiceCommand : Command {
        [ParameterAlias(NamelessParameterAlias)]
        public IntegerParameter ChoiceIndex;

        public override UniTask ExecuteAsync(CancellationToken cancellationToken = default) {
            NaninovelInkAdapter.Choose(ChoiceIndex);
            return UniTask.CompletedTask;
        }
    }
}