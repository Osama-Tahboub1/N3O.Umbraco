using N3O.Umbraco.Constants;
using N3O.Umbraco.Lookups;
using System.Globalization;

namespace N3O.Umbraco.Localization;

public class NumberFormat : NamedLookup {
    private readonly string _cultureCode;

    public NumberFormat(string id,
                        string name,
                        string cultureCode,
                        string decimalSeparator,
                        string thousandsSeparator)
        : base(id, name) {
        _cultureCode = cultureCode;
        DecimalSeparator = decimalSeparator;
        ThousandsSeparator = thousandsSeparator;
    }

    public string DecimalSeparator { get; }
    public string ThousandsSeparator { get; }

    public CultureInfo GetCultureInfo() {
        return ((CultureInfo) CultureInfo.GetCultureInfo(_cultureCode).Clone());
    }
    
    public NumberFormatInfo GetNumberFormatInfo() {
        var numberFormatInfo = GetCultureInfo().NumberFormat;
        
        return numberFormatInfo;
    }
}

public class NumberFormats : StaticLookupsCollection<NumberFormat> {
    public static readonly NumberFormat International = new("international", "UK/US Style", "en-GB", DecimalSeparators.Point, ThousandsSeparators.Comma);
    public static readonly NumberFormat EU1 = new("eu1", "European Style 1", "fr-FR", DecimalSeparators.Comma, ThousandsSeparators.Space);
    public static readonly NumberFormat EU2 = new("eu2", "European Style 2", "es-ES", DecimalSeparators.Comma, ThousandsSeparators.Point);
}
