namespace OsuRealDifficulty;

public partial class MapAnnotationList : List<IMapAnnotation>
{
    public void SortAscendingly()
    {
        Sort(AscendingOffsetsTypesMapAnnotationComparer.Instance);
    }

    public bool AreEqualSorted(MapAnnotationList list, bool sort)
    {
        int count = Count;
        if (count != list.Count)
        {
            return false;
        }

        if (sort)
        {
            SortAscendingly();
            list.SortAscendingly();
        }

        for (int i = 0; i < count; i++)
        {
            var x = this[i];
            var y = list[i];

            // Assuming that no map annotations leave IEquatable<T> undefined
            if (!x.Equals(y))
            {
                return false;
            }
        }

        return true;
    }
}
