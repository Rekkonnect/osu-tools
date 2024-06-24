using Garyon.Extensions;

namespace OsuRealDifficulty.UI.WinForms.Controls;

internal class SingleItemSelectionChangedListView : ListView
{
    private readonly ItemSelectionChangedEventManager _eventManager = new();

    public event EventHandler<IReadOnlyList<MergedEventArgs>>? CombinedItemSelectionChanged;

    public SingleItemSelectionChangedListView()
    {
        DoubleBuffered = true;

        Application.Idle += HandleItemSelections;
    }

    private void HandleItemSelections(object? sender, EventArgs e)
    {
        var unconsumed = _eventManager.HandleUnconsumedEvents();
        if (unconsumed.Count > 0)
        {
            CombinedItemSelectionChanged?.Invoke(this, unconsumed);
        }
    }

    protected override void OnItemSelectionChanged(ListViewItemSelectionChangedEventArgs e)
    {
        _eventManager.Register(e);
        base.OnItemSelectionChanged(e);
    }

    public record MergedEventArgs(
        ListViewItemSelectionChangedEventArgs? Deselection,
        ListViewItemSelectionChangedEventArgs? Selection);

    private class ItemSelectionChangedEventManager
    {
        private List<MergedEventArgs> _unconsumedEvents = new();
        private ListViewItemSelectionChangedEventArgs? _pendingDeselection;

        public void Register(ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected is false)
            {
                _pendingDeselection = e;
                var merge = new MergedEventArgs(_pendingDeselection, null);
                _unconsumedEvents.Add(merge);
            }
            else
            {
                if (_pendingDeselection is not null)
                {
                    var merge = new MergedEventArgs(_pendingDeselection, e);
                    if (_unconsumedEvents.Count > 0)
                    {
                        _unconsumedEvents.RemoveLast();
                    }
                    _unconsumedEvents.Add(merge);
                    _pendingDeselection = null;
                }
                else
                {
                    var merge = new MergedEventArgs(null, e);
                    _unconsumedEvents.Add(merge);
                }
            }
        }

        public IReadOnlyList<MergedEventArgs> HandleUnconsumedEvents()
        {
            if (_unconsumedEvents.Count is 0)
                return [];

            var result = _unconsumedEvents;
            _unconsumedEvents = new();
            return result;
        }
    }
}
