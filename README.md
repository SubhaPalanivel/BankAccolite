# bankproject_accolite

## Tech Stacks:

This test automation framework uses the following tech stacks:

* Programming language: C#
* Testing framework: MS Test framework with HttPWebRequest and HttpWebResponse
* Other tools and libraries: MSTEST, Newtonsoft.Json, System.Net

## Test Coverage:

### Create and Delete Account:

* Succeful Account Creation of single user with single account
* Succeful Account Creation of single user with multiple account
* Delete available account
* Delete not existing account - Error Case

#### Known Gaps:
* Account Creation with invalid details  - Error Case
* Delete available account with amount exists  - Error Case

### Money Deposit and Withdraw Cases

* Deposit Money into Existing Account
* Deposit Money into Not existing account  - Error Case
* Minimum and Maximum Limit- Success + Error Case
* Withdraw Money from Existing Account
* Withdraw Money from Not existing account  - Error Case
* Withdraw Limit

#### Known Gaps:
* Parallel Deposit and Withdraw use cases from same account
