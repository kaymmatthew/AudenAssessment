# AudenAssessment
The tools used: A. Visual studio 2019 B. Specflow with C# C. Nunit framework D. Visual studio Git extension
What i did: A. Created a framework with the above mentioned tools from scratch to automate auden loan calculator
Why i used the above mentioned tools: A. Ease of use b. Easy to understand c. page object architecture 3. Allows for reusability 4. Saves time
The framework structure: Framework consist of a. DriverHelper directory b. Features directory c. Hooks directory d. PageObject directory e. Steps f. Conditionalwait g. Settings h. Settingsreader
Driver helper holds the instance of driver which is used throughout the entire project
Feature file allows me to document all my scenario steps using the Ghekin syntax (Given, When, Then). It allows me to write more meaningful test steps that everyone can understand
Hooks allows me to instanciate the setup and teardown of the project framework
PageObject allows me to document all my web elements which are unique for that page in one class i.e ShortTermLoanPage used in this framework. These elements are used by my driver to interact with the page
Steps class binds my feature file to my methods or functions, which then allows me to manipulate the elements found on the page from my page object in the way i see fit.
Conditional wait is just a basic Thread.Sleep used for demonstration purposed to allow the test run as smooth as possible when required.However this can be implemented much better to wait for specific elements in the future
Settings.json is a file that hold data such as 'Url' used for this framework
Settings reader allows me to use a builder class to read data from the settings.json file


All the above mentioned has been included to create and maintain a well structured framework which other could potentially use. Although the framework can be much better however for the purpose of the assessment i have made it a little bit easier to understand.



Thank you for the opportunity, looking forward to get some feedbacks
