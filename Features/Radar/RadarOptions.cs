using Microsoft.Extensions.Options;

namespace XperienceCommunity.Locator;

public class RadarOptions
{
    public string? SecretKey { get; set; }
    
    public string? PublicKey { get; set; }
    
    public bool UseTestEnvironment { get; set; }
}

public class ValidateRadarOptions : IValidateOptions<RadarOptions>
{
    public ValidateOptionsResult Validate(string? name, RadarOptions options)
    {
       
        if(string.IsNullOrWhiteSpace(options.SecretKey))
            return ValidateOptionsResult.Fail($"{nameof(RadarOptions.SecretKey)} is required");
        
        if(string.IsNullOrWhiteSpace(options.PublicKey))
            return ValidateOptionsResult.Fail($"{nameof(RadarOptions.PublicKey)} is required");

        if (options.UseTestEnvironment && (!options.SecretKey.Contains("_test_", StringComparison.OrdinalIgnoreCase) ||
                                           !options.PublicKey.Contains("_test_", StringComparison.OrdinalIgnoreCase)))
            return ValidateOptionsResult.Fail("Test Key is required to use test environment.");
        
        return ValidateOptionsResult.Success;
    }
}