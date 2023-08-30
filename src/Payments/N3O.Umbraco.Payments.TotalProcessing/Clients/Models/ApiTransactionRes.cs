using Newtonsoft.Json;

namespace Payments.TotalProcessing.Clients.Models;

public class ApiTransactionRes {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("paymentBrand")]
    public string PaymentBrand { get; set; }

    [JsonProperty("recurringType")]
    public string RecurringType { get; set; }

    [JsonProperty("result")]
    public Result Result { get; set; }

    [JsonProperty("resultDetails")]
    public ResultDetails ResultDetails { get; set; }
    
    [JsonProperty("card")]
    public CardRes Card { get; set; }

    [JsonProperty("customer")]
    public CustomerRes Customer { get; set; }

    [JsonProperty("customParameters")]
    public CustomParametersRes CustomParameters { get; set; }

    [JsonProperty("risk")]
    public Risk Risk { get; set; }

    [JsonProperty("buildNumber")]
    public string BuildNumber { get; set; }

    [JsonProperty("timestamp")]
    public string Timestamp { get; set; }

    [JsonProperty("ndc")]
    public string Ndc { get; set; }

    [JsonProperty("standingInstruction")]
    public StandingInstruction StandingInstruction { get; set; }
}