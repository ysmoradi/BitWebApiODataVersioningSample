using Bit.OData.Contracts;

[assembly: ODataModule("MyApp")]
[assembly: ODataModule("MyAppV2")]

public class ODataConfig
{
    public const string Version = "ApiV2";
}
