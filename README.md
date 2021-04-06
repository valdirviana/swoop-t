# Swoop Funding - Backend Engineer Coding Test

We would like you to design and implement an API that returns a list of entities from the UK registrar of companies: Companies House. You can find documentation on how to retrieve data at https://developer.companieshouse.gov.uk/api/docs. You will need to register an account and generate an API key within your account.

We would recommend inspecting the results for the following Companies House entities, to give you an idea of returned data and its structure:

https://beta.companieshouse.gov.uk/company/11163382 (the company ‘Swoop Finance Limited’)

https://beta.companieshouse.gov.uk/company/01624297/officers (appointed officers at ‘Microsoft UK Limited’)

NOTE: We would expect you to spend between 3-4 hours on this test, however the emphasis should be on providing a quality solution with sound architecture - so as long as the main building blocks are in place, we will happily review any partially completed test of good quality; and potentially discuss any missing implementation in a technical interview thereafter.

## Business Requirements
The API must provide the following functionality:

1. The number of results returned to a calling client should be set in a configuration file and set to 5.
2. The API should retrieve a company by company number.
3. The API should retrieve a collection of companies by company name.
4. The API should retrieve a company partially matched by a name, and having a specific officer.
5. The API should retrieve a collection of officers within a company whom are [optionally] active or inactive, AND/OR [optionally] of a specific age.

For each method, the entity returned should exhibit the following properties (using the most appropriate data type):

Company
* Name
* Registration number
* Age of company (in years)
* Address

Officer
* Name
* Date of Birth
* Age
* Role

## Technical Requirements
1. The solution must be written in C#.
2. You must create tests to demonstrate the solution works as intended.
3. The solution must be stored in an online git repository.
4. The solution must be standalone and build successfully when pulled from the repository. You do not need to create a client for the API.
5. The solution must log some debug information, and all warnings/errors.
6. Once an API endpoint is called, any subsequent calls to the endpoint with the same parameters must retrieve the results from cache/storage without retrieving the data from Companies House again - the cache should last 1 hour (configurable). The caching must persist across application restarts.
7. We’re not sure at this stage which mechanism we prefer for caching, so ensure that your solution allows for different adapters to be supplied, without the need to re-compile your solution.
8. The solution must return to the UI appropriate results for successful and non-successful scenarios. It should also handle and log exceptions (which may contain sensitive information and/or vulnerabilities).

## Technical Requirements - Bonus
Provide a client library which provides the ability to call a SINGLE endpoint on the API which returns a collection of officers within a company, having a specific age. The code for using your client library might look like this:

~~~~
var settings = new CodeTestApiClientSettings { Endpoint = “https://localhost/codetest/api” };
var client = new CodeTestApiClient(settings);
var officers = client.GetOfficers(<your parameters>);
~~~~

## Hints & Tips
* We are looking for clean, functional code that is robust and testable.
* Feel free to use whatever third-party packages you feel are appropriate.

## Submitting your solution

Please push your changes to the `master branch` of this repository. You can push one or more commits. <br>

Once you are finished with the task, please click the `Complete task` link on <a href="https://app.codescreen.dev/#/codescreenteste2e7f4f3-044d-430b-9aff-0f4c02e005ae" target="_blank">this screen</a>.