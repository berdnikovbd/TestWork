/// <summary>
/// Получить <see cref="Comparer{T}"/> для <see cref="KeyValuePair{int, string}"/> для сравнения пар по ключу, затем по значению.
/// </summary>
/// <returns>
/// <see cref="Comparer{T}"/> для <see cref="KeyValuePair{int, string}"/> для сравнения пар по ключу, затем по значению.
/// </returns>
public static Comparer<KeyValuePair<int, string>> GetKeyValueComparer()
{
    var comparer = Comparer<KeyValuePair<int, string>>.Create((first, second) =>
    {
        if (first.Key == second.Key)
        {
            return first.Value.CompareTo(second.Value);
        }

        return first.Key.CompareTo(second.Key);
    });

    return comparer;
}

/// <summary>
/// Добавить пару ключ-значение в список <paramref name="list"/> отсортированный по ключу и значению.
/// </summary>
/// <param name="list">Целевой список.</param>
/// <param name="key">Добавляемый в список ключ.</param>
/// <param name="value">Добавляемое в список значение.</param>
/// <remarks>
/// Целевой список поддерживает повторяющиеся ключи.
/// </remarks>
/// <exception cref="ArgumentNullException"/>
public static void AddPair(ref KeyValuePair<int, string>[] array, int key, string value)
{
    if (array == null)
    {
        throw new ArgumentNullException("array");
    }

    KeyValuePair<int, string>[] newArray;
    var addingPair = new KeyValuePair<int, string>(key, value);
    var pairsComparer = GetKeyValueComparer();

    if (array.Length == 0)
    {
        newArray = new KeyValuePair<int, string>[1];
        newArray[0] = addingPair;
        array = newArray;

        return;
    }

    if (pairsComparer.Compare(addingPair, array[0]) <= 0)
    {
        newArray = new KeyValuePair<int, string>[array.Length + 1];
        newArray[0] = addingPair;
        array.CopyTo(newArray, 1);
        array = newArray;

        return;
    }

    if (pairsComparer.Compare(addingPair, array[array.Length - 1]) >= 0)
    {
        newArray = new KeyValuePair<int, string>[array.Length + 1];
        newArray[newArray.Length - 1] = addingPair;
        array.CopyTo(newArray, 0);
        array = newArray;

        return;
    }

    // Возвращенное отрицательное число от BinarySeatch — это побитовая инверсия индекса первого элемента, превышающего по значению addingPair.
    var insertingPosition = ~Array.BinarySearch(array, addingPair, pairsComparer);

    newArray = new KeyValuePair<int, string>[array.Length + 1];
    newArray[insertingPosition] = addingPair;
    Array.Copy(array, newArray, insertingPosition);
    Array.Copy(array, insertingPosition, newArray, insertingPosition + 1, array.Length - insertingPosition);
    array = newArray;
}