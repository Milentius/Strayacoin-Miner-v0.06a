General Overview of Strayacoin Miner Classes
Overview
The Strayacoin Miner project is designed to provide an efficient and user-friendly mining experience for Strayacoin. This document provides a general overview of the different classes in the project and their purposes. Detailed documentation for each class will be provided in separate .md files.
Classes
1. Program
•	Namespace: Strayacoin_Miner_v0._06a
•	Description: The entry point of the application. It initializes the necessary components and starts the mining process.
•	Key Responsibilities:
•	Initialize the AsciiTableDrawer and other components.
•	Set up the console window size.
•	Start the UI rendering process.
2. UI_Renderer
•	Namespace: Strayacoin_Miner_v0._06a
•	Description: Responsible for rendering the user interface of the miner. It uses the AsciiTableDrawer to draw various UI elements.
•	Key Responsibilities:
•	Render the main UI layout.
•	Render experimental visual blocks.
•	Use additional AsciiTableDrawer components for enhanced UI elements.
3. AsciiTableDrawer
•	Namespace: Ascii_Table_Drawer
•	Description: A utility class for drawing ASCII tables and UI elements in the console. It provides various methods for drawing rows, borders, and separators.
•	Key Responsibilities:
•	Draw rows with text and borders.
•	Draw top and bottom borders.
•	Draw separators and option lists.
•	Display progress bars and user input prompts.
4. StrayacoinConfig
•	Namespace: Strayacoin_Miner_v0._06a
•	Description: Manages the configuration settings for the miner. It handles loading, saving, and validating configuration settings.
•	Key Responsibilities:
•	Load and save configuration settings from/to a JSON file.
•	Validate configuration settings.
•	Provide access to various configuration properties such as device ID, wallet paths, and mining settings.
5. SettingsEvaluator
•	Namespace: Strayacoin_Miner_v0._06a
•	Description: Evaluates various settings to ensure they meet the required criteria. It uses different evaluators for different settings.
•	Key Responsibilities:
•	Evaluate settings using specific evaluators.
•	Provide a mechanism to add and manage evaluators for different settings.
6. ISettingEvaluator<T>
•	Namespace: Strayacoin_Miner_v0._06a
•	Description: An interface for evaluating settings. It defines a generic method for evaluating a setting value.
•	Key Responsibilities:
•	Define a method for evaluating a setting value.
7. WalletExecutableEvaluator, CliExecutableEvaluator, ConfigFileWalletEvaluator, ConfigFileAppDataEvaluator, PaymentAddressEvaluator, MiningCoresEvaluator
•	Namespace: Strayacoin_Miner_v0._06a
•	Description: Specific evaluators for different settings. Each class implements the ISettingEvaluator<T> interface to evaluate a specific setting.
•	Key Responsibilities:
•	Evaluate specific settings such as wallet executable path, CLI executable path, configuration files, payment address, and mining cores.
Contributing
If you are interested in contributing to the Strayacoin Miner project, please refer to the detailed documentation for each class provided in separate .md files. Feel free to open issues or submit pull requests with your contributions.
License
This project is licensed under the MIT License. See the LICENSE file for details.
Contact
For any questions or support, please contact the project maintainers at support@strayacoin.org.