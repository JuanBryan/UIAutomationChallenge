tags:api
# Validition of Country
    All API TESTING FOR THE CHALLENGE

## GET country and validate each of them individually

tags:countryValidation

#### Test steps
* Given the user gets "BASE_API_URL" countries 
#### Assertions
* Then the user validate if the code "alpha2Code" and the Country "US" exists and have the data content
    |name                     |alpha3Code |
    |-------------------------|-----------|
    |United States of America |USA        |

* Then the user validate if the code "alpha2Code" and the Country "DE" exists and have the data content

    |name                     |alpha3Code |
    |-------------------------|-----------|
    |Germany                  |DEU        |

* Then the user validate if the code "alpha2Code" and the Country "GB" exists and have the data content
    |name                                                 |alpha3Code |
    |-----------------------------------------------------|-----------|
    |United Kingdom of Great Britain and Northern Ireland |GBR        |


## GET information for inexistent countries and validate the response

tags: countryValidationInexistentCountries

#### Test steps
* Given the user gets "BASE_API_URL" countries 
#### Assertions
* Then the user validate if the code "alpha2Code" and the Country "US1" not exists and returns error code "404"
* Then the user validate if the code "alpha2Code" and the Country "DE1" not exists and returns error code "404"
* Then the user validate if the code "alpha2Code" and the Country "GB1" not exists and returns error code "404"


## validate new country addition using POST

tags: newcountryValidation

#### Test steps
* Given the user wanna register a new countries "BASE_API_URL"  
#### Assertions
* Then  the user validate a new country addition using POST
    |name                     |alpha2Code |alpha3Code |
    |-------------------------|-----------|-----------|
    |New country name         |NC         |NCN        |