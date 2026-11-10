using UnityEngine;
using UnityEngine.Events;

public class MapController : MonoBehaviour
{
    [SerializeField]
    private MapPlayerController mapPlayerController;
    [SerializeField]
    private UnityEvent<string> onLevelChosen;
    [SerializeField]
    private UnityEvent onMapStart;

    public void MovePlayer(MapDirection direction)
    {
        if (mapPlayerController.CurrentLevel == null || !mapPlayerController.CanWalk) return;
        CheckLevel(mapPlayerController.CurrentLevel.NextLevel.level, direction);
        CheckLevel(mapPlayerController.CurrentLevel.PrevLevel.level, direction);
    }

    private void CheckLevel(MapLevel level, MapDirection direction)
    {
        if (level == null) return;
        if (level.NextLevel != null && level.NextLevel.direction == direction)
        {
            mapPlayerController.MoveToLevel(level.NextLevel.level);
        }
    }
    public void ChooseLevel()
    {
        if (mapPlayerController.CurrentLevel != null)
        {
            onLevelChosen?.Invoke(mapPlayerController.CurrentLevel.LevelName);
        }
    }
}
