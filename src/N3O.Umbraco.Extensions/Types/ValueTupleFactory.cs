using System;

namespace N3O.Umbraco;

public static class ValueTupleFactory {
    public static object Create(Func<(Type, object)> item1, Func<(Type, object)> item2) {
        var (item1Type, item1Value) = item1();
        var (item2Type, item2Value) = item2();

        var valueTupleType = typeof(ValueTuple<,>).MakeGenericType(item1Type, item2Type);
        var valueTuple = Activator.CreateInstance(valueTupleType, item1Value, item2Value);

        return valueTuple;
    }
    
    public static object Create(Func<(Type, object)> item1,
                                Func<(Type, object)> item2,
                                Func<(Type, object)> item3) {
        var (item1Type, item1Value) = item1();
        var (item2Type, item2Value) = item2();
        var (item3Type, item3Value) = item3();

        var valueTupleType = typeof(ValueTuple<,,>).MakeGenericType(item1Type, item2Type, item3Type);
        var valueTuple = Activator.CreateInstance(valueTupleType, item1Value, item2Value, item3Value);

        return valueTuple;
    }
    
    public static object Create(Func<(Type, object)> item1,
                                Func<(Type, object)> item2,
                                Func<(Type, object)> item3,
                                Func<(Type, object)> item4) {
        var (item1Type, item1Value) = item1();
        var (item2Type, item2Value) = item2();
        var (item3Type, item3Value) = item3();
        var (item4Type, item4Value) = item4();

        var valueTupleType = typeof(ValueTuple<,,,>).MakeGenericType(item1Type, item2Type, item3Type, item4Type);
        var valueTuple = Activator.CreateInstance(valueTupleType, item1Value, item2Value, item3Value, item4Value);

        return valueTuple;
    }
}
