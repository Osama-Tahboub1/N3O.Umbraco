namespace N3O.Umbraco.Lookups;

public class Country : LookupContent<Country> {
    public override string Id {
        get => Iso2Code;
        set { }
    }

    public string Iso2Code => GetValue(x => x.Iso2Code);
    public string Iso3Code => GetValue(x => x.Iso3Code);
    public string DiallingCode => GetValue(x => x.DiallingCode);
    public bool LocalityOptional => GetValue(x => x.LocalityOptional);
    public bool PostalCodeOptional => GetValue(x => x.PostalCodeOptional);
}
