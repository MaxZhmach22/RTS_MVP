using System.Threading.Tasks;

public class GatheringPoinCommandExecutor : CommandExecutorBase<IGatheringPoint>
{
    public override async Task ExecuteSpecificCommand(IGatheringPoint command)
    {
        GetComponent<MainBuilding>().GatheringPoint = command.GatheringPoint;
    }
}