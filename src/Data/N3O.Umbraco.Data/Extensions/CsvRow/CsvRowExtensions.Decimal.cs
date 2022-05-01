using N3O.Umbraco.Data.Models;
using OurDataTypes = N3O.Umbraco.Data.Lookups.DataTypes;

namespace N3O.Umbraco.Data.Extensions {
    public static partial class CsvRowExtensions {
        public static decimal? GetDecimal(this CsvRow csvRow, string heading) {
            return GetDecimal(csvRow, CsvSelect.For(heading));
        }

        public static decimal? GetDecimal(this CsvRow csvRow, int index) {
            return GetDecimal(csvRow, CsvSelect.For(index));
        }

        public static decimal? GetDecimal(this CsvRow csvRow, CsvSelect select) {
            return csvRow.ParseField(select,
                                     (parser, field) => parser.Decimal.Parse(field, OurDataTypes.Decimal.GetClrType()));
        }
    }
}