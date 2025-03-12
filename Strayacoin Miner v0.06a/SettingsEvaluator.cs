namespace Strayacoin_Miner_v0._06a
{
    
public class SettingsEvaluator
    {
        private readonly Dictionary<string, Func<ISettingEvaluator<object>>> evaluators;

        public SettingsEvaluator()
        {
            evaluators = new Dictionary<string, Func<ISettingEvaluator<object>>>
            {
                { "WalletExecutable", () => new WalletExecutableEvaluator() as ISettingEvaluator<object> },
                { "CliExecutable", () => new CliExecutableEvaluator() as ISettingEvaluator<object> },
                { "ConfigFileWallet", () => new ConfigFileWalletEvaluator() as ISettingEvaluator<object> },
                { "ConfigFileAppData", () => new ConfigFileAppDataEvaluator() as ISettingEvaluator<object> },
                { "PaymentAddress", () => new PaymentAddressEvaluator() as ISettingEvaluator<object> },
                { "MiningCores", () => new MiningCoresEvaluator() as ISettingEvaluator<object> }
                // Add more entries for other properties
            };
        }

        public T Evaluate<T>(string propertyName, object propertyValue)
        {
            if (evaluators.TryGetValue(propertyName, out var evaluatorFactory))
            {
                var evaluator = evaluatorFactory();
                return (T)evaluator.Evaluate(propertyValue);
            }
            return default; // Default to the default value of T for properties without specific evaluation logic
        }
    }
}

