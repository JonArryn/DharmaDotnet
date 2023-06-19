using System.Reflection;

namespace DharmaServerDotnetApi.Helpers;

public class Mapper {

    private static readonly Dictionary<(Type fromClass, Type toClass), List<(MethodInfo Get, MethodInfo Set)>> _cache = new();

    public static UToType Map<TFromType, UToType>( TFromType fromObject )
            where TFromType : class, new()
            where UToType : class, new() {

        var key = (fromType: fromObject.GetType(), toType: typeof(UToType));

        if (!_cache.ContainsKey( key )) {
            PopulateCacheKey( key );
        }

        var result = new UToType();
        var cachedProps = _cache[key];

        foreach (var entry in cachedProps) {

            var fromPropValue = entry.Get.Invoke( fromObject,
                    null );

            entry.Set.Invoke( result,
                    new[]{ fromPropValue, } );
        }

        return result;
    }

    public static void PopulateCacheKey( (Type fromClass, Type toClass) key ) {
        var fromProps = key.fromClass.GetProperties();
        var toProps = key.toClass.GetProperties();

        List<(MethodInfo, MethodInfo)> entry = new();

        foreach (var fromProp in fromProps) {
            var propToMap = toProps.FirstOrDefault( prop => prop.Name == fromProp.Name );

            if (propToMap is null) {
                continue;
            }

            entry.Add( (fromProp.GetMethod, propToMap.SetMethod) );

        }

        _cache[key] = entry;
    }

}