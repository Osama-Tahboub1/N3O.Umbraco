using N3O.Umbraco.Data.Models;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace N3O.Umbraco.Data;

public interface IExcelWorkbook {
    void AddWorksheet(IExcelTable table);
    ExcelWorksheetWriter AddWorksheet();
    void FormatAsTable(bool enabled);
    void PasswordProtect(string password);
    Task SaveAsync(Stream stream, CancellationToken cancellationToken = default);
}
